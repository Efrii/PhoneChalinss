using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhoneChalin.Base;
using PhoneChalin.Models;
using PhoneChalin.Repositories.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneChalin.Controllers
{
    [Route("[controller]")]
    [Authorize(Roles = "Manajer")]
    public class SmartphoneController : BaseController<Smartphone, SmartphoneRepository, int>
    {
        SmartphoneRepository smartphoneRepository;

        public SmartphoneController(SmartphoneRepository repository) : base(repository)
        {
            this.smartphoneRepository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        #region Get Using Join
        [HttpGet("getall")]
        public async Task<JsonResult> getall()
        {
            var data = await smartphoneRepository.getall();

            if (data != null)
            {
                return Json(data);
            }

            return Json(data);
        }
        #endregion Get Using Join

       
    }
}
