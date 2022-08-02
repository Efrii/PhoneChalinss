using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneChalin.Base;
using PhoneChalin.Models;
using PhoneChalin.Repositories.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneChalin.Controllers
{
    [Authorize(Roles = "Staff")]
    public class SupplierController : BaseController<Supplier, SupplierRepository, int>
    {
        SupplierRepository Repository;

        public SupplierController(SupplierRepository repository) : base(repository)
        {
            this.Repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
