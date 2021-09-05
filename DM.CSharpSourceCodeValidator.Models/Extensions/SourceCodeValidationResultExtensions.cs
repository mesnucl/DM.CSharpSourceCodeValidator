
using System.Linq;

namespace DM.CSharpSourceCodeValidator.Models.Extensions
{
    public static class SourceCodeValidationResultExtensions
    {
        public static int GetNumberOfLinesWithError(this SourceCodeValidationResult sourceCodeValidationResult)
            => sourceCodeValidationResult.ValidationErrors
                    .Select(validationResult => validationResult.LineNumberBegin)
                    .Distinct()
                    .Count();
            
        
    }
}
