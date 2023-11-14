using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Domain;
using Learnin_center_xw53.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserDomain _userDomain;
        private IUserData _userData;
        private IMapper _mapper;
        public UserController(IUserDomain userDomain,IUserData userData,IMapper mapper)
        {
            _userDomain = userDomain;
            _userData = userData;
            _mapper = mapper;
        }
        
        // GET: api/User
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userInput)
        {
            try
            {
                var user = _mapper.Map<UserLoginRequest, User>(userInput);

                var jwt = await _userDomain.Login(user);

                return Ok(jwt);
            }
            catch (Exception ex)
            {
                throw;
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }


        // POST: api/User
        ///[Filter.Authorize("admin")]
        [HttpPost]
        [Route("Signup")]
        public async Task<IActionResult> Signup([FromBody] UserRequest userInput)
        {
            
            var user = _mapper.Map<UserRequest, User>(userInput);
            var id = await _userDomain.Signup(user);
            
            if (id > 0)
                return Ok(id.ToString());
            else
                return BadRequest();
        }

    }
}
