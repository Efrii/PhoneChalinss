using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneChalin.Models;
using PhoneChalin.Repositories.Data;
using PhoneChalin.ViewModels;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using API.Middleware;
using API.Services;
using API.Models;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneChalin.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository accountRepository;
        IConfiguration config;
        Uri baseAddress = new Uri("https://localhost:42573/api/");
        HttpClient client;

        public AccountController(AccountRepository accountRepository, IConfiguration config)
        {
            this.accountRepository = accountRepository;
            this.config = config;
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Auth([FromBody] User login)
        {
            var postTask = client.PostAsJsonAsync<User>("Account/Login", login);
            postTask.Wait();

            //var jwt = new JwtService(config);
            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;
                var parsedObject = JObject.Parse(readTask);
                var token = parsedObject["token"].ToString();

                var d = parsedObject["data"].ToString();
                var datas = JsonConvert.DeserializeObject<User>(d);
                //var idToken = jwt.GenerateSecurityToken(datas);

                List<RoleVM> userRole = new List<RoleVM>();
                foreach (var item in datas.UserRoles)
                {
                    RoleVM role = new RoleVM()
                    {
                        RoleEmployee = item.Role.RoleEmployee
                    };

                    userRole.Add(role);
                    HttpContext.Session.SetString("Role", item.Role.RoleEmployee);
                }

                HttpContext.Session.SetString("Id", datas.Id.ToString());
                HttpContext.Session.SetString("Username", datas.Username);
                HttpContext.Session.SetString("Email", datas.Email);
                HttpContext.Session.SetString("Token", token);

                return Json(new {
                    status = result.StatusCode,
                    data = new {
                        id = datas.Id,
                        username = datas.Username,
                        email = datas.Email,
                        role = userRole },
                    token = token
                });

            } else
            {
                return Json(new { status = result.StatusCode, message = result.RequestMessage});
            }
            
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Register()
        {
            //var roles = accountRepository.GetRole();
            //if (roles.Count() > 0)
            //{
            //    return View(roles);
            //}
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Register register)
        {

            var d = Json(register);

            //if (ModelState.IsValid)
            //{
            //    var postTask = client.PostAsJsonAsync<Register>("Account/Register", register);
            //    postTask.Wait();

            //    var result = postTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("Catalog", "Smartphone");
            //    }
            //    else
            //    {
            //        TempData["loginInvalid"] = "Login Failed";
            //        return View();
            //    }
            //}
            return d;
        }
    }
}
