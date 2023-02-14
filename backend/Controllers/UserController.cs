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

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(List<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<UserDTO>>(_userInteractor.GetAll()));
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Create(UserPasswordDTO user)
        {
            try
            {
                var createdUser = _userInteractor
                    .CreateUser(_mapper.Map<UserBL>(user));

                return Ok(_mapper.Map<UserPasswordDTO>(createdUser));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [Authorize]
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
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

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedUser = _userInteractor.DeleteUser(id);
            return deletedUser != null ? Ok(_mapper.Map<UserDTO>(deletedUser)) : NotFound();
        }

        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var user = _userInteractor.GetByID(id);
            return user != null ? Ok(_mapper.Map<UserDTO>(user)) : NotFound();
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(TokenDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Login(LoginDetailsDTO loginDetailsDTO)
        {
            var user = _userInteractor.AuthorizeUser(_mapper.Map<LoginDetailsBL>(loginDetailsDTO));

            if (user == null)
            {
                return NotFound("Такого пользователя не существует");
            }

            var identity = GetIdentity(user);
            var now = DateTime.UtcNow;

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var tokenDto = new TokenDTO
            {
                AccessToken = encodedJwt,
                Username = identity.Name
            };

            return Json(tokenDto);
        }

        private ClaimsIdentity GetIdentity(UserBL user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Register(LoginDTO login)
        {
            var user = new UserPasswordDTO
            {
                Login = login.Login,
                Password = login.Password,
                Role = "user"
            };

            return Create(user);
        }
    }
}
