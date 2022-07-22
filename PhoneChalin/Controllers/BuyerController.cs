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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneChalin.Controllers
{
    public class BuyerController : Controller
    {
        BuyerRepository buyerRepository;

        public BuyerController(BuyerRepository buyerRepository)
        {
            this.buyerRepository = buyerRepository;
        }

        #region Get
        [HttpGet]
        public ActionResult Index()
        {
            var buyers = buyerRepository.Get();

            if (buyers != null)
            {
                return View(buyers);
            }
            return RedirectToAction("Catalog", "Smartphone");
        }
        #endregion Get

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Buyer buyers)
        {
            if (ModelState.IsValid)
            {
                var result = buyerRepository.Post(buyers);
                if (result > 0)
                    return RedirectToAction("Index", "Buyer");
            }
            return View();
        }
        #endregion Create

        #region Edit
        [HttpGet("/Buyer/Edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            var result = buyerRepository.Get(Id);

            if(result != null)
            {
                return View(result);
            }
            return RedirectToAction("Index", "Buyer");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Buyer buyers)
        {
            if (ModelState.IsValid)
            {
                var result = buyerRepository.Put(buyers);

                if(result > 0)
                {
                    return RedirectToAction("Index", "Buyer");
                }
            }
            return View();
        }
        #endregion Edit

        #region Delete
        [HttpGet("/buyer/detail/{Id}")]
        public IActionResult Delete(int Id)
        {
            var result = buyerRepository.Get(Id);

            if(result != null)
            {
                return View(result);
            }
            return RedirectToAction("Index", "Buyer");
        }

        [HttpGet("/buyer/delete/{Id}")]
        public IActionResult DeleteAction(int Id)
        {
            var result = buyerRepository.Delete(Id);
            if(result > 0)
                return RedirectToAction("Index", "Buyer");
            return View();
        }
        #endregion Delete
    }
}
