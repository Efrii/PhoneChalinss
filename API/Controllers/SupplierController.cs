using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Base;
using API.Models;
using API.Repositories.Data;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    [Authorize(Roles = "Staff")]
    public class SupplierController : BaseController<Supplier, SupplierRepository, int>
    {
        SupplierRepository repositor;

        public SupplierController(SupplierRepository repository) : base(repository)
        {
            this.repositor = repository;
        }
    }
}
