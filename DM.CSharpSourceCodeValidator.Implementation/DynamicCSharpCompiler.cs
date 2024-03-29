﻿
using DM.CSharpSourceCodeValidator.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System.IO;
using System.Linq;

namespace DM.CSharpSourceCodeValidator.Implementation
{
    internal class DynamicCSharpCompiler
    {
        //TODO refactor method
        public SourceCodeValidationResult Compile(string CSharpSourceCode, string newCompilationAssemblyName)
        {
            using (var peStream = new MemoryStream())
            {
                var compiledCode = GenerateCode(CSharpSourceCode, newCompilationAssemblyName).Emit(peStream);

                if (!compiledCode.Success)
                {       //TODO refactor
                    var failures = compiledCode.Diagnostics.Where(diagnostic => diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error);
                    var validationResult = new SourceCodeValidationResult(false);

                    failures.ToList()
                        .ForEach(failure => {
                            validationResult.ValidationErrors.Add(
                                new ValidationError
                                {
                                    ErrorMessage = failure.GetMessage(),
                                    LineNumberBegin = failure.Location.GetLineSpan().StartLinePosition.Line+1, // The error line from the compiler is zero based. probably more intuitive to start from 1
                                    LineNumberEnd = failure.Location.GetLineSpan().EndLinePosition.Line+1
                                }
                               );
                    });
                    return validationResult;
                }
                else
                    return new SourceCodeValidationResult(true);
            }
        }
        //TODO refactor method
        private CSharpCompilation GenerateCode(string sourceCode, string newCompilationAssemblyName)
        {
            var codeString = SourceText.From(sourceCode);
            #warning Source code validation is set to version 7.3
            var options = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp7_3);

            var parsedSyntaxTree = SyntaxFactory.ParseSyntaxTree(codeString, options);
            //TODO Make included reference dynamic
            var references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
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
