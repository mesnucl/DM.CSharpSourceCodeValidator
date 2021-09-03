﻿
using DM.CSharpSourceCodeValidator.Contracts;
using DM.CSharpSourceCodeValidator.Models;
using System.Linq;
using Xunit;

namespace DM.CSharpSourceCodeValidator.Implementation.tests.Compound
{
    public class CSharpSourceCodeValidator : BaseTest
    {

        [Fact]
        public void ValidateSourceCode_WithInvalidSourceCode_TestValidationIsFalse() {

            SourceCodeValidator sut = GetSourceCodeValidator();
            string sourceCode = getInvalidSourceCodeAsString();

            SourceCodeValidationResult result = sut.ValidateSourceCode(sourceCode, "testAssembly");


            Assert.False(result.IsAvalidCompilation);
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
            string sourceCode = getInvalidSourceCodeAsString();

            SourceCodeValidationResult result = sut.ValidateSourceCode(sourceCode, "testAssembly");

           
            Assert.Equal(9, result.ValidationErrors.First().LineNumberBegin);
        }

        [Fact]
        public void ValidateSourceCode_ReturnsErrorLineEnd9WithInvalidSourceCode_TestValidationHasErrorLineENDAtLine9()
        {
            SourceCodeValidator sut = GetSourceCodeValidator();
            string sourceCode = getInvalidSourceCodeAsString();

            SourceCodeValidationResult result = sut.ValidateSourceCode(sourceCode, "testAssembly");


            Assert.Equal(9, result.ValidationErrors.First().LineNumberEnd);
        }


    }
}
