# A project to validate whether  C# source code is valid or not.

## How to use.
1. Call the CSharpSourceCodeValidatorFactory located in the assembly "DM.CSharpSourceCodeValidator.Implementation.tests".
   It is the only public class in the assembly.
2. The returned SourceCode validator interface have the method ValidateSourceCode which takes 2 parameters.
   A string that should contain the source code and another string that for the preffered name of the compiled assembly.
3. Call ValidateSourceCode method and a SourceCodeValidationResult will be returned. which contains a boolean property
   that indicates wheter the code was valid or not. And 2 int properties with number of the line where the error starts
   and a number of where the error ends.
   
 ## Issues
 - Currently the langauge version of the source code to be compiled is hardcoded to be C# 7.3. That means features above C# 7.3 
   will fail validation. 
- There is a need for more tests. Both compounds and unit test.
- All tests have only been performed on a Windows platform.
- There is still alot of decoupling and refactoring to be done.

