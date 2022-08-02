using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneChalin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/404")]
        public ActionResult Notfound()
        {
            return View();
        }

        [Route("/401")]
        public new IActionResult Unauthorized()
        {
            return View();
        }

        [Route("/400")]
        public IActionResult Badrequest()
        {
            return View();
        }

        [Route("/403")]
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}
