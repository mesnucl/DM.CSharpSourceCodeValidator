using DM.CSharpSourceCodeValidator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DM.CSharpSourceCodeValidator.Contracts
{
    // Specific .Net langauge is omitted from the name as other .Net langauge could be the implementation in the future.
    public interface SourceCodeValidator
    {
        SourceCodeValidationResult ValidateSourceCode(string sourceCode,string newCompilationAssemblyName);
    }
}
