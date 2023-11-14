using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Domain;
using Learnin_center_xw53.Filter;
using Learnin_center_xw53.Request;
using Learnin_center_xw53.Response;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("admin,account")]
    public class TutorialController : ControllerBase
    {
        private ITutorialDomain _tutorialDomain;
        private ITutorialData _tutorialData;
        private IMapper _mapper;   
        private TelemetryClient _telemetry;
        
        public TutorialController(ITutorialDomain tutorialDomain,ITutorialData tutorialData,IMapper mapper,TelemetryClient telemetry)
        {
            _tutorialDomain = tutorialDomain;
            _tutorialData = tutorialData;
            _mapper = mapper;
            _telemetry = telemetry;
        }
        
        
        /// <summary>
        /// get all Tuturials stored .
        /// </summary>
        /// <returns>All actived categerories without filters</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Get   
        ///
        /// </remarks>
        // GET: api/Tutorial
        [HttpGet]
        [Produces("application/json")]
        
        public async Task<List<TutorialResponse>> GetAsync()
        {
            ///TutorialSQLData tutorialData = new TutorialSQLData();

            //tutorialData.GetAll();
            //return new string[] { "value1", "value2" };
            var tutorials=   await _tutorialData.GetALL();
            
           var response= _mapper.Map<List<Tutorial>, List<TutorialResponse>>(tutorials);

           return response;
        }

        // GET: api/Tutorial/5
        [HttpGet("{id}", Name = "Get")]
        public Tutorial Get(int id)
        {
            //TutorialOracleData tutorialSqlData = new TutorialOracleData();
           // return tutorialSqlData.GetAll();

          return _tutorialData.GetById(id);
        }
        
        // GET: api/Tutorial
        [HttpGet("GetQuery")]
        public List<Tutorial> GetByName(string  title, string? author, int year)
        {
            //TutorialOracleData tutorialSqlData = new TutorialOracleData();
            // return tutorialSqlData.GetAll();

            
            ///TutorialRequest -> Tutotorial(data)   Mapper
            ///
            ///
            Tutorial tutorial = new Tutorial()
            {
                Title = title,
                Year = year,
                Author = author
            };
            
            return _tutorialData.GetFilteredData(tutorial);
        }
        // POST: api/Tutorial
        /// <response code="201">Returns the newly created tutorial</response>
        /// <response code="400">If the tutorial is null or missing required fields</response>
        /// <response code="500">Unexcpected error</response>

        [HttpPost]
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] TutorialRequest  tutorialRequest)
        {
            throw new Exception("test error");
  
          // TutorialDomain tutorialDomain = new TutorialDomain();
          /* Tutorial tutorial = new Tutorial()
           {
               Title = tutorialRequest.Title,
               Year = tutorialRequest.Year,
               Author = tutorialRequest.Author,
               CategoryId = tutorialRequest.CategoryId
            };*/

          try
          {
              if (!ModelState.IsValid)
              {              
                  _telemetry.TrackTrace("Post_badrequest");
                  return BadRequest();
              }

              var tutorial = _mapper.Map<TutorialRequest, Tutorial>(tutorialRequest);
              _telemetry.TrackEvent("Post");
              return   Created("/Post",_tutorialDomain.create(tutorial));
              // return tutorialDomain.Create(value);
          }
          catch (Exception e)
          {
              _telemetry.TrackException(e);
              return StatusCode(500);
          }
        }

        // PUT: api/Tutorial/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] TutorialRequest  tutorialRequest)
        {           
            Tutorial tutorial = new Tutorial()
            {
                Title = tutorialRequest.Title,
                Year = tutorialRequest.Year,
                Author = tutorialRequest.Author,
                CategoryId = tutorialRequest.CategoryId
            };
           
            return _tutorialDomain.update(tutorial,id);
        }

        // DELETE: api/Tutorial/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _tutorialDomain.delete(id);
        }
    }
}
