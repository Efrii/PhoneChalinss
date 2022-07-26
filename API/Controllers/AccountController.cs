using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using API.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountRepository accountRepository;
        IConfiguration config;

        public AccountController(AccountRepository accountRepository, IConfiguration config)
        {
            this.accountRepository = accountRepository;
            this.config = config;
        }

        [Route("Login")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] Login login)
        {
            var result = accountRepository.GetLogin(login.Username, login.Password);
            var claims = new List<Claim>();

            if (result != null)
            {
                claims.Add(new Claim("Id", result.Id.ToString()));
                claims.Add(new Claim("Username", result.Username));

                foreach (var item in result.UserRoles)
                {
                    claims.Add(new Claim("roles", item.Role.RoleEmployee));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtConfig:secret"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    config["JwtConfig:Issuer"],
                    config["JwtConfig:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: signIn
                    );
                var idToken = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { status = 200, data = result, token = idToken });

            } else
            {
                return BadRequest(new { status = 400, message = "Request is invalid" });
            }
        }

        [Route("ChangePassword")]
        [HttpPut]
        [Authorize]
        public ActionResult<int> ChangePassword(User user)
        {
            var result = accountRepository.ChangePassword(user);

            if (result > 0)
                return Ok(new { status = 200, data = result });
            else
                return BadRequest(new { status = 400, message = "Request is invalid" });
        }

        [Route("Register")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<int> Register(Register register)
        {
            var result = accountRepository.Register(register);

            if (result > 0)
                return Ok(new { status = 200, data = result });
            else
                return BadRequest(new { status = 400, message = "Request is invalid"});
        }

        [Route("ForgetPassword")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<int> ForgetPassword(User user)
        {
            return BadRequest();
        }
    }
}
