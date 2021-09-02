using System;
using System.Collections.Generic;
using System.Text;

namespace DM.CSharpSourceCodeValidator.Models
{
    public class ValidationError
    {
        public int LineNumber { get; set; }
        public string ErrorMessage { get; set; }

    }
}
