using DM.CSharpSourceCodeValidator.Contracts;
using DM.CSharpSourceCodeValidator.Models;
using DM.CSharpSourceCodeValidator.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DM.CSharpSourceCodeValidator.Implementation.tests.Compound_Tests
{
    public class SourceCodeValidationResultExtension :CompoundBaseTest
    {
        public SourceCodeValidationResultExtension(ITestOutputHelper output)
            :base(output){}

        [Fact]
        public void GetNumberOfLinesWithError_ValidateTheCorrectNumberOfErrorsLineisProvide_IntValue2IsReturned()
        {
            

            SourceCodeValidator sut = GetSourceCodeValidator();
            string sourceCode = getInvalidSourceCodeWithSingleErrorLineAsString();

            SourceCodeValidationResult result = sut.ValidateSourceCode(sourceCode, "testAssembly");

            Assert.Equal(2, result.GetNumberOfLinesWithError());

        }
    }
}
