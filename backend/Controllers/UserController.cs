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
using WineSales.Domain.ModelConverters;
using WineSales.Domain.Exceptions;
using WineSales.Data.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace WineSales.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("/api/v1/users")]

    public class UserController : Controller
    {
        private readonly IUserInteractor _userInteractor;
        private readonly IMapper _mapper;
        private readonly UserConverter _userConverter;

        public UserController(IUserInteractor userInteractor, 
                              IMapper mapper, 
                              UserConverter userConverter)
        {
            _userInteractor = userInteractor;
            _mapper = mapper;
            _userConverter = userConverter;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UserDTO>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<UserDTO>>(_userInteractor.GetAll()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Create(LoginDTO user)
        {
            try
            {
                var createdUser = _userInteractor
                    .CreateUser(_mapper.Map<UserBL>(user));

                return Ok(_mapper.Map<LoginDTO>(createdUser));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Patch(int id, UserBaseDTO user)
        {
            try
            {
                var updatedUser = _userInteractor
                    .UpdateUser(_userConverter.ConvertUser(id, user));
                return updatedUser != null ? Ok(_mapper.Map<UserDTO>(updatedUser)) : NotFound();
            }
            catch (UserException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedUser = _userInteractor.DeleteUser(id);
            return deletedUser != null ? Ok(_mapper.Map<UserDTO>(deletedUser)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var user = _userInteractor.GetByID(id);
            return user != null ? Ok(_mapper.Map<UserDTO>(user)) : NotFound();
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Login(LoginDetailsDTO login)
        {
            var result = _userInteractor.AuthorizeUser(_mapper.Map<LoginDetailsBL>(login));
            return result != null ? Ok(_mapper.Map<UserDTO>(result)) : NotFound();
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Register(LoginDTO login)
        {
            var user = new LoginDTO
            {
                Login = login.Login,
                Password = login.Password,
                Role = login.Role,
                RoleId = login.RoleId
            };

            return Create(user);
        }
    }
}
