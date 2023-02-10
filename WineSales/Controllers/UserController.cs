using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WineSales.Domain.DTO;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.Models;
using WineSales.Domain.Interactors;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using WineSales.Data.Repositories;

namespace WineSales.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("/api/v1/users")]
    public class UserController : Controller
    {
        private readonly IUserInteractor userInteractor;
        private readonly IMapper mapper;
        //private readonly UserConverters userConverters;

        public UserController(IUserInteractor userInteractor, IMapper mapper)//, UserConverters userConverters)
        {
            this.userInteractor = userInteractor;
            this.mapper = mapper;
            //this.userConverters = userConverters;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDTO>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(mapper.Map<IEnumerable<UserDTO>>(userInteractor.GetAll()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserIdPasswordDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Add(UserPasswordDTO userDTO)
        {
            try
            {
                var addedUser = userInteractor.CreateUser(mapper.Map<UserBL>(userDTO));
                return Ok(mapper.Map<UserPasswordDTO>(addedUser));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedUser = userInteractor.DeleteUser(id);
            return deletedUser != null ? Ok(mapper.Map<UserDTO>(deletedUser)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var user = userInteractor.GetByID(id);
            return user != null ? Ok(mapper.Map<UserDTO>(user)) : NotFound();
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginDetailsDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Login(LoginDetailsDTO loginDTO)
        {
            var result = userInteractor.AuthorizeUser(mapper.Map<LoginDetailsBL>(loginDTO));
            return result != null ? Ok(mapper.Map<LoginDetailsDTO>(result)) : NotFound();
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(UserIdPasswordDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Register(LoginDTO loginDTO)
        {
            var userDto = new UserPasswordDTO
            {
                Login = loginDTO.Login,
                Password = loginDTO.Password,
                Role = "user"
            };

            return Add(userDto);
        }
    }
}

