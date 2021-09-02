using DM.CSharpSourceCodeValidator.Contracts;
using DM.CSharpSourceCodeValidator.Models;
namespace DM.CSharpSourceCodeValidator.Implementation
{
    internal class CSharpSourceCodeValidator : SourceCodeValidator
    {

        public SourceCodeValidationResult ValidateSourceCode(string sourceCode, string newCompilationAssemblyName)
            => new DynamicCSharpCompiler().Compile(sourceCode, newCompilationAssemblyName);

    }
}
