using Data;
using Domain;
using NSubstitute;

namespace B.Domain.UnitTest;

public class TutorialDomainTest
{
    [Fact]
    public void Create_ValidData_ReturnTrue()
    {
        //Arrange
        Tutorial tutorial = new Tutorial()
        {
            Title = "Math",
            Year = 2023,
            Author = "Author 1"
        };
        var tutorialData = Substitute.For<ITutorialData>();
        TutorialDomain tutorialDomain = new TutorialDomain(tutorialData);
        //Set a return value:
        tutorialData.GetByTitle(tutorial.Title).Returns(false);
        tutorialData.create(tutorial).Returns(true);
        
        //Act
        var actualResult=  tutorialDomain.create(tutorial);

        //Assert
        Assert.True(actualResult);
        //Assert.Equal(true,actualResult);
    }
}