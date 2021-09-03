using System;
using System.IO;

namespace DM.CSharpSourceCodeValidator.Implementation.tests
{
    public abstract class BaseTest
    {
       
        public string getInvalidSourceCodeWithSingleErrorLineAsString()
        {
            // Ensure that testfiles are copied to debug library on test runs
            var pathToTestFile = Path.Combine(Environment.CurrentDirectory, @"TestFiles\PersonInvalid.testfile");
            
            return File.ReadAllText(pathToTestFile);
        }
        public string getInvalidSourceCodeWithTwoErrorLineAsString()
        {
            // Ensure that testfiles are copied to debug library on test runs
            var pathToTestFile = Path.Combine(Environment.CurrentDirectory, @"TestFiles\PersonInvalidTwoErrorLines.testfile");

            return File.ReadAllText(pathToTestFile);
        }
        public string getValidSourceCodeAsString() {
            // Ensure that testfiles are copied to debug library on test runs
            var pathToTestFile = Path.Combine(Environment.CurrentDirectory, @"TestFiles\PersonValid.testfile");

            return File.ReadAllText(pathToTestFile);
        }

    }
}
