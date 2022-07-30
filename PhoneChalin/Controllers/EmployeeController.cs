﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneChalin.Base;
using PhoneChalin.Models;
using PhoneChalin.Repositories.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneChalin.Controllers
{
    public class EmployeeController : BaseController<Employee, EmployeeRepository, int>
    {
        EmployeeRepository EmployeeRepository;

        public EmployeeController(EmployeeRepository repository) : base(repository)
        {
            this.EmployeeRepository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
