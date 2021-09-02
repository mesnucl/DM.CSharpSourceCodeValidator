using DM.CSharpSourceCodeValidator.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DM.CSharpSourceCodeValidator.Implementation.tests
{
    public class BaseTest
    {
        public SourceCodeValidator GetSourceCodeValidator()
                => CSharpSourceCodeValidatorFactory.GetCSharpSourceCodeValidator();



        public string getInvalidSourceCodeAsString()
        {
            // Ensure that testfiles are copied to debug library on test runs
            var pathToTestFile = Path.Combine(Environment.CurrentDirectory, @"TestFiles\PersonInvalid.testfile");
            
            return File.ReadAllText(pathToTestFile);
        }
        public string getValidSourceCodeAsString() {
            // Ensure that testfiles are copied to debug library on test runs
            var pathToTestFile = Path.Combine(Environment.CurrentDirectory, @"TestFiles\PersonValid.testfile");

            return File.ReadAllText(pathToTestFile);
        }

    }
}
