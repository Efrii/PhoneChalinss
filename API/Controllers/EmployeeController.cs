using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class EmployeeController : BaseController<Employee, EmployeeRepository, int>
    {
        EmployeeRepository employeeRepository;

        public EmployeeController(EmployeeRepository repository) : base(repository)
        {
            this.employeeRepository = repository;
        }
    }
}
