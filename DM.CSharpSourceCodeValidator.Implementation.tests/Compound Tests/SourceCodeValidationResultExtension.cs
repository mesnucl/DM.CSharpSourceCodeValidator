using DM.CSharpSourceCodeValidator.Contracts;
using DM.CSharpSourceCodeValidator.Models;
using DM.CSharpSourceCodeValidator.Models.Extensions;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace DM.CSharpSourceCodeValidator.Implementation.tests.Compound_Tests
{
    public class SourceCodeValidationResultExtension :CompoundBaseTest
    {
        public SourceCodeValidationResultExtension(ITestOutputHelper output)
            :base(output){}

        [Fact]
        public void GetNumberOfLinesWithError_ValidateTheCorrectNumberOfErrorsLineisProvideWithInvalidSourceCode_IntValue2IsReturned()
        {
            SourceCodeValidator sut = GetSourceCodeValidator();
            string sourceCode = getInvalidSourceCodeWithSingleErrorLineAsString();

            SourceCodeValidationResult result = sut.ValidateSourceCode(sourceCode, "testAssembly");

            Assert.Equal(2, result.GetNumberOfLinesWithError());

        }
        [Fact]
        public void GetNumberOfLinesWithError_ValidateTheCorrectNumberOfErrorsLineisProvideWithValidSourceCode_IntValue0IsReturned()
        {
            SourceCodeValidator sut = GetSourceCodeValidator();
            string sourceCode = getValidSourceCodeAsString();

            SourceCodeValidationResult result = sut.ValidateSourceCode(sourceCode, "testAssembly");

            Assert.Equal(0, result.GetNumberOfLinesWithError());

        }
        [Fact]
        public void GetLineNumberForLinesWithErrors_ValidateThatAllErrorLineNumbersAreCorrectWithInvalidSourceCode_Returns8And9() {
            SourceCodeValidator sut = GetSourceCodeValidator();
            string sourceCode = getInvalidSourceCodeWithSingleErrorLineAsString();
            IEnumerable<int> expected = new List<int> { 
                9,10
            };

            SourceCodeValidationResult result = sut.ValidateSourceCode(sourceCode, "testAssembly");

            Assert.Equal(expected, result.GetLineNumberForLinesWithErrors());
        }
        [Fact]
        public void GetLineNumberForLinesWithErrors_ValidateThatNoErrorLinesAreReturnedWithValidSourceCode_ReturnEmptyCollection()
        {
            SourceCodeValidator sut = GetSourceCodeValidator();
            string sourceCode = getValidSourceCodeAsString();

            SourceCodeValidationResult result = sut.ValidateSourceCode(sourceCode, "testAssembly");

            Assert.Empty(result.GetLineNumberForLinesWithErrors());
        }
    }
}
