
using System.Collections.Generic;
using System.Linq;

namespace DM.CSharpSourceCodeValidator.Models.Extensions
{
    public static class SourceCodeValidationResultExtensions
    {
        public static int GetNumberOfLinesWithError(this SourceCodeValidationResult sourceCodeValidationResult)
            => sourceCodeValidationResult.ValidationErrors
                    .Select(validationError => validationError.LineNumberBegin)
                    .Distinct()
                    .Count();
        public static IEnumerable<int> GetLineNumberForLinesWithErrors(this SourceCodeValidationResult sourceCodeValidationResult)
             => sourceCodeValidationResult.ValidationErrors
                    .Select(validationError => validationError.LineNumberBegin)
                    .Distinct();
        public static IEnumerable<string> GetErrorMessages(this SourceCodeValidationResult sourceCodeValidationResult)
             => sourceCodeValidationResult.ValidationErrors
                    .Select(validationError => validationError.ErrorMessage)
                    .Distinct();
        public static IEnumerable<KeyValuePair<int, string>> GetErrorMessageAndLineNumber(this SourceCodeValidationResult sourceCodeValidationResult)
            => sourceCodeValidationResult.ValidationErrors
                .Select(validationError=> 
                        new KeyValuePair<int,string>(validationError.LineNumberBegin,validationError.ErrorMessage)
                );

            
        
    }
}
