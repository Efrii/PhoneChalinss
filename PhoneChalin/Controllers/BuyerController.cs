using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneChalin.Models;
using PhoneChalin.ViewModels;
using PhoneChalin.Repositories.Data;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhoneChalin.Base;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneChalin.Controllers
{
    public class BuyerController : BaseController<Buyer, BuyerRepository, int>
    {
        BuyerRepository buyerRepository;

        public BuyerController(BuyerRepository buyerRepository) : base(buyerRepository)
        {
            this.buyerRepository = buyerRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
