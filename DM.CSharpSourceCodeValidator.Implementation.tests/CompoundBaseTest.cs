using DM.CSharpSourceCodeValidator.Contracts;

namespace DM.CSharpSourceCodeValidator.Implementation.tests
{
    public abstract class CompoundBaseTest : BaseTest
    {
        public SourceCodeValidator GetSourceCodeValidator()
               => CSharpSourceCodeValidatorFactory.GetCSharpSourceCodeValidator();
    }
}
