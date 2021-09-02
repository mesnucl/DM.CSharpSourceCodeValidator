using System.Collections.Generic;

namespace DM.CSharpSourceCodeValidator.Models
{
    public class SourceCodeValidationResult
    {
        public bool IsAvalidCompilation { get; private set; }

        public List<ValidationError> ValidationErrors { get; private set;}
       
        public SourceCodeValidationResult(bool isAvalidCompilation, List<ValidationError> validationErrors  = null)
        {
            this.IsAvalidCompilation = isAvalidCompilation;
            this.ValidationErrors = validationErrors ?? new List<ValidationError>();
        }

    }
}
