using Domain;
using Xunit.Sdk;

namespace B.Domain.UnitTest;

public class MathDomainTest
{
    //[Fact]//Happy path
    [Theory]
    [InlineData(1,5 ,6)] //
    [InlineData(3,4,7)]
    [InlineData(8,1,9)]
    public void SumInt_SingleNumber_ReturnSum(int a,int b, int expected)
    {
        //Arrange
        MathDomain mathDomain = new MathDomain();
       // const int expectedResult = 5;
        
        //Act
        var actualResult = mathDomain.SumInt(a, b);
        
        //Assert
        Assert.Equal(expected,actualResult);
    }
    
    [Fact]//Unhappy path
    public void SumInt_MoreThan200_ReturnThrow()
    {
        //Arrange
        MathDomain mathDomain = new MathDomain();
        
        //Act
        Action act = () => mathDomain.SumInt(201, 4);
        
        //Assert //TODO    
        ArgumentException exception = Assert.Throws<ArgumentException>(act) ;
        Assert.Equal("A or B grater than 200", exception.Message);
    }
    
}