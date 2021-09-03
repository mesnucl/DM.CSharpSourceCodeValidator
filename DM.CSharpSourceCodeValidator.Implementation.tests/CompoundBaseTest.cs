using DM.CSharpSourceCodeValidator.Contracts;
using Xunit.Abstractions;

namespace DM.CSharpSourceCodeValidator.Implementation.tests
{
    public abstract class CompoundBaseTest : BaseTest
    {
        public CompoundBaseTest(ITestOutputHelper output) : base(output)
        {
        }

        public SourceCodeValidator GetSourceCodeValidator()
               => CSharpSourceCodeValidatorFactory.GetCSharpSourceCodeValidator();
    }
}
