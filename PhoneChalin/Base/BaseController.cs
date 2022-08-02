using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneChalin.Repositories.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneChalin.Base
{
    [Route("/[controller]")]
    [Controller]
    public class BaseController<TModel, TRepository, TPrimaryKey> : Controller
        where TModel : class
        where TRepository : IGeneralRepository<TModel, TPrimaryKey>
    {
        TRepository Repository;

        public BaseController(TRepository repository)
        {
            this.Repository = repository;
        }

        [HttpGet("Get")]
        public async Task<JsonResult> Get()
        {
            var result = await Repository.Get();

            //if (result.Count() != 0)
            //    return Ok(new { status = 200, message = "Success Get All Data", data = result });
            //else
            //    return NotFound(new { status = 404, message = "Data Not Fasdound" });
            return Json(result);
        }

        [HttpGet("Get/{Id}")]
        public async Task<JsonResult> Get(TPrimaryKey Id)
        {
            var result = await Repository.Get(Id);

            //if (result != null)
            //    return Ok(new { status = 200, message = "Success Get Data By Id", data = result });
            //else
            //    return NotFound(new { status = 404, message = "Data Not asdasdFound" });

            return Json(result);
        }

        [HttpPost("Add")]
        [ValidateAntiForgeryToken]
        public JsonResult Post([FromBody] TModel model)
        {
            var result = Repository.Post(model);

            //if (result > 0)
            //    return Ok(new { status = 200, data = result });
            //else
            //    return BadRequest(new { status = 400, message = "Request is invalid" });

            return Json(result);
        }

        [HttpPut("Edit")]
        public JsonResult Put([FromBody] TModel model)
        {
            var result = Repository.Put(model);

            //if (result > 0)
            //    return Ok(new { status = 200, data = result });
            //else
            //    return BadRequest(new { status = 404, message = "Request is invalid" });

            return Json(result);
        }

        [HttpDelete("Delete/{Id}")]
        public JsonResult Delete(TPrimaryKey Id)
        {
            var result = Repository.Delete(Id);

            //if (result > 0)
            //    return Ok(new { status = 200, data = result });
            //else
            //    return BadRequest(new { status = 400, message = "Request is invalid" });

            return Json(result);
        }

    }
}
