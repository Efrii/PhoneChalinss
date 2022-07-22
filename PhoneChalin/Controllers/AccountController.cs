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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneChalin.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository accountRepository;
        Uri baseAddress = new Uri("https://localhost:42573/api/");
        HttpClient client;

        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
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
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var postTask = client.PostAsJsonAsync<Login>("Account/Login", login);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync().Result;
                    var parsedObject = JObject.Parse(readTask);
                    var dataOnly = parsedObject["token"].ToString();

                    HttpContext.Session.SetString("Token", dataOnly);

                    return RedirectToAction("Catalog", "Smartphone");
                } else
                {
                    TempData["loginInvalid"] = "Login Failed";
                    return View();
                }
            }
            return View();
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
