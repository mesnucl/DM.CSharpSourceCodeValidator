using System;
using System.Collections.Generic;
using System.Text;

namespace DM.CSharpSourceCodeValidator.Models
{
    public class ValidationError
    {
        public int LineNumberBegin { get; set; }
        public int LineNumberEnd { get; set; }
        public string ErrorMessage { get; set; }

    }
}
