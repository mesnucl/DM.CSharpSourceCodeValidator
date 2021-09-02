using System;

namespace DM.CSharpSourceCodeValidator.Models
{
    public class SourceCodeValidationResult
    {
        public bool IsAvalidCompilation { get; private set; }

        public int ErrorLine { get; private set; }


        public SourceCodeValidationResult(bool isAvalidCompilation,int errorLine = -1)
        {
            this.IsAvalidCompilation = isAvalidCompilation;
            this.ErrorLine = errorLine;
        }

    }
}
