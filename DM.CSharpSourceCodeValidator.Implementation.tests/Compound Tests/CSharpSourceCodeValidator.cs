
using DM.CSharpSourceCodeValidator.Contracts;
using DM.CSharpSourceCodeValidator.Models;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace DM.CSharpSourceCodeValidator.Implementation.tests.Compound
{
    public class CSharpSourceCodeValidator : CompoundBaseTest
    {

        public CSharpSourceCodeValidator(ITestOutputHelper output) :base(output)
        {}

        [Fact]
        public void ValidateSourceCode_WithInvalidSourceCode_TestValidationIsFalse() {

            SourceCodeValidator sut = GetSourceCodeValidator();
            string sourceCode = getInvalidSourceCodeWithSingleErrorLineAsString();

            SourceCodeValidationResult result = sut.ValidateSourceCode(sourceCode, "testAssembly");


            Assert.False(result.IsAvalidCompilation);
        }
        [Fact]
        public void ValidateSourceCode_ValiddateThatOnlyOneValidationErrorIsReturnedWithSingleInvalidLineOfSourceCode_LengthOfValidationErrorsIsOne()
        {
            /*
              It seems that multiple Validation Errors is generated from 1 single line of invalid source code
              This requires some investigation. The Assumption so far have been that 1 line of invalid source code
              would generate 1 Validation error
             */

            SourceCodeValidator sut = GetSourceCodeValidator();
            string sourceCode = getInvalidSourceCodeWithSingleErrorLineAsString();

            SourceCodeValidationResult result = sut.ValidateSourceCode(sourceCode, "testAssembly");

            Assert.Single(result.ValidationErrors);
            
        }
        [Fact]
        public void ValidateSourceCode_WithValidSourceCode_TestValidationIsTrue()
        {
            SourceCodeValidator sut = GetSourceCodeValidator();
            string sourceCode = getValidSourceCodeAsString();

            SourceCodeValidationResult result = sut.ValidateSourceCode(sourceCode, "testAssembly");


            Assert.True(result.IsAvalidCompilation);
        }
        [Fact]
        public void ValidateSourceCode_ReturnsErrorLineStart9WithInvalidSourceCode_TestValidationHasErrorLineStartAtLine9()
        {
            SourceCodeValidator sut = GetSourceCodeValidator();
            string sourceCode = getInvalidSourceCodeWithSingleErrorLineAsString();

            SourceCodeValidationResult result = sut.ValidateSourceCode(sourceCode, "testAssembly");

           
            Assert.Equal(9, result.ValidationErrors.First().LineNumberBegin);
        }

        [Fact]
        public void ValidateSourceCode_ReturnsErrorLineEnd9WithInvalidSourceCode_TestValidationHasErrorLineENDAtLine9()
        {
            SourceCodeValidator sut = GetSourceCodeValidator();
            string sourceCode = getInvalidSourceCodeWithSingleErrorLineAsString();

            SourceCodeValidationResult result = sut.ValidateSourceCode(sourceCode, "testAssembly");


            Assert.Equal(9, result.ValidationErrors.First().LineNumberEnd);
        }

        [Fact]
        public void ValidateSourCode_ReturnCorrectStartLineWithInvalidSourceCodeOnMultipleLines_TestValidationHasErrorLineStartAtLine9() {

            SourceCodeValidator sut = GetSourceCodeValidator();
            string sourceCode = getInvalidSourceCodeWithTwoErrorLineAsString();

            SourceCodeValidationResult result = sut.ValidateSourceCode(sourceCode, "testAssembly");


            Assert.Equal(9, result.ValidationErrors.First().LineNumberBegin);
        }
        [Fact]
        public void ValidateSourCode_ReturnCorrectEndLineWithInvalidSourceCodeOnMultipleLines_TestValidationHasErrorLineEndAtLine11()
        {
            SourceCodeValidator sut = GetSourceCodeValidator();
            string sourceCode = getInvalidSourceCodeWithTwoErrorLineAsString();

            SourceCodeValidationResult result = sut.ValidateSourceCode(sourceCode, "testAssembly");


            Assert.Equal(11, result.ValidationErrors.Last().LineNumberEnd);
        }
    }
}
