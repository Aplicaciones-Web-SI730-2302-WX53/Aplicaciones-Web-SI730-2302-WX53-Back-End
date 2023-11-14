using System.Runtime.InteropServices.JavaScript;
using API.Controllers;
using AutoMapper;
using Data;
using Domain;
using Learnin_center_xw53.Response;
using NSubstitute;

namespace A.API.UnitTest;

public class TutorialControllerTest
{
    
    //NombreFuncion_ValoresENtrada_ReturnRetorno
    [Fact]
    public async void  GetAsync_LisTutorialResponse()
    {
        //AAAasync
        //Arrange  configurar dependencias
        
        var tutorialDomainMock = Substitute.For<ITutorialDomain>();
        var tutorialDataMock = Substitute.For<ITutorialData>();
        var mapperMock = Substitute.For<IMapper>();

        var tutorialController = new TutorialController(tutorialDomainMock,tutorialDataMock,mapperMock);
        
        //Mocke GetALL
        List<Tutorial> tutorials = new List<Tutorial>();
        tutorials.Add(new Tutorial(){Title = "Fake 1"});
        tutorials.Add(new Tutorial(){Title = "Fake 2"});
        tutorials.Add(new Tutorial(){Title = "Fake 3"});
        tutorialDataMock.GetALL().Returns(tutorials);
        
        //Mock Mapper.Map
        List<TutorialResponse> tutorialResponses = new List<TutorialResponse>();
        tutorialResponses.Add(new TutorialResponse(){Title = "Fake 1"});
        tutorialResponses.Add(new TutorialResponse(){Title = "Fake 2"});
        tutorialResponses.Add(new TutorialResponse(){Title = "Fake 3"});
        mapperMock.Map<List<Tutorial>, List<TutorialResponse>>(tutorials).Returns(tutorialResponses);
        
        //Act ejecutamos la funcion a probar
        var result = await tutorialController.GetAsync();

        //Assert -- verificamos
        const int EXPECTED_RESULT = 3;
        
        Assert.NotNull(result);
        Assert.Equal(EXPECTED_RESULT,result.Count());
    }
}