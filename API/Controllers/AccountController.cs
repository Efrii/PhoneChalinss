using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using API.Repositories.Data;
using API.Services;
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
        [EnableCors]
        [AllowAnonymous]
        public ActionResult Post(User user)
        {
            var result = accountRepository.GetLogin(user.Username, user.Password);
            //var jwt = new JwtService(config);
            if (result != null)
            {
                //var idToken = jwt.GenerateSecurityToken(result);

                //return Ok(new { status = 200, data = result, token = idToken});
                return Ok(new { status = 200, data = result});

            } else
            {
                return BadRequest(new { status = 400, message = "Username or Password is invalid" });
            }
        }

        [Route("Register")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<int> Register(Register register)
        {
            var result = accountRepository.Register(register);

            if (result == 1)
            {
                return Ok(new { status = 200, data = result });
            }
            else if (result == 2)
            {
                return Conflict(new { status = 409, message = "Email Sudah Digunakan"});
            }
            else
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

        [Route("ForgetPassword")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<int> ForgetPassword(Register register)
        {
            var result = accountRepository.ResetPassword(register);

            if (result > 1)
            {
                return Ok(new { status = 200, data = result });
            }
            else if (result == 2)
            {
                return Conflict(new { status = 409, message = "Email Sudah Digunakan" });
            }
            else
            {
                return BadRequest(new { status = 400, message = "Request is invalid" });
            }
        }
    }
}
