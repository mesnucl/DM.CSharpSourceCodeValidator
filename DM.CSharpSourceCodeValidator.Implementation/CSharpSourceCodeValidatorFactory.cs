using DM.CSharpSourceCodeValidator.Contracts;

namespace DM.CSharpSourceCodeValidator.Implementation
{
    public  class CSharpSourceCodeValidatorFactory
    {
        public static SourceCodeValidator GetCSharpSourceCodeValidator()
            =>  new CSharpSourceCodeValidator();


    }
}
