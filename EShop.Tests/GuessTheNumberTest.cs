using EShop.FolderForTesting;

namespace EShop.Tests;

public static class GuessTheNumberTest
{
    //Naming Convention - ClassName_MethodName_ExpectedResult
    [Fact]
    public static void ScopeOfTestsMethods_GuessTheNumber_ReturnsString()
    {
        try
        {
            //Arrange - Go get your variables, whatever you need, you classes, go get functions

            int num = 5;
            ScopeOfTestsMethods testsMethods = new ScopeOfTestsMethods();
            
            //Act - Execute this function
            
            string result = testsMethods.GuessTheNumber(num);

            //Assert - Whatever ever is returned is it what you want. 

            if (result == "Oh, Yesss")
            {
                Console.WriteLine("PASSED: ScopeOfTestsMethods_GuessTheNumber_ReturnsString");
            }
            else
            {
                Console.WriteLine("FAILED: ScopeOfTestsMethods_GuessTheNumber_ReturnsString");
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}