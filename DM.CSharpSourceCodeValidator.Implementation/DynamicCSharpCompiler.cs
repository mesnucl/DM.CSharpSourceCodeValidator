﻿
using DM.CSharpSourceCodeValidator.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System;
using System.IO;
using System.Linq;

namespace DM.CSharpSourceCodeValidator.Implementation
{
    internal class DynamicCSharpCompiler
    {
        public SourceCodeValidationResult Compile(string CSharpSourceCode, string newCompilationAssemblyName)
        {
            using (var peStream = new MemoryStream())
            {
                var result = GenerateCode(CSharpSourceCode, newCompilationAssemblyName).Emit(peStream);

                if (!result.Success)
                {
                    var failures = result.Diagnostics.Where(diagnostic => diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error);
                    var validationResult = new SourceCodeValidationResult(false);

                    failures.ToList().ForEach(failure => {

                        validationResult.ValidationErrors.Add(
                            new ValidationError
                            {
                                ErrorMessage = failure.GetMessage(),
                                LineNumber = failure.Location.GetLineSpan().StartLinePosition.Line
                            }
                           ); ; 
                    
                    });

                    return validationResult;
                }
                else
                {
                     return new SourceCodeValidationResult(true);
                }
                    
                    //var failures = result.Diagnostics.Where(diagnostic => diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error);

                    //foreach (var diagnostic in failures)
                    //{
                    //    Console.WriteLine(diagnostic.Location.Kind);
                    //    Console.WriteLine(diagnostic.Location.GetLineSpan().ToString());
                    //    Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
                    //}

            }
        }

        private  CSharpCompilation GenerateCode(string sourceCode, string newCompilationAssemblyName)
        {
            var codeString = SourceText.From(sourceCode);
            var options = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp7_3);

            var parsedSyntaxTree = SyntaxFactory.ParseSyntaxTree(codeString, options);

            var references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(System.Runtime.AssemblyTargetedPatchBandAttribute).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo).Assembly.Location),
            };

            return CSharpCompilation.Create(newCompilationAssemblyName,
                new[] { parsedSyntaxTree },
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary,
                    optimizationLevel: OptimizationLevel.Release,
                    assemblyIdentityComparer: DesktopAssemblyIdentityComparer.Default));
        }
    }
}
