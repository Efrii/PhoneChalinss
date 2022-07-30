using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    //[Authorize(Roles = "Manajer")]
    public class SmartphoneController : BaseController<Smartphone, SmartphoneRepository, int>
    {
        SmartphoneRepository repository;

        public SmartphoneController(SmartphoneRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [Route("Getall")]
        [HttpGet]
        public ActionResult<List<Smartphone>> GetAll()
        {
            var result = repository.GetAllJoin();

            if (result.Count() != 0)
                return Ok(new { status = 200, message = "Success Get All Data", data = result });
            else
                return NotFound(new { status = 404, message = "Data Not Found" });
        }
    }
}
