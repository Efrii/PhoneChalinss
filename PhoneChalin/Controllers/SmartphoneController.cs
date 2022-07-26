using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhoneChalin.Models;
using PhoneChalin.Repositories.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneChalin.Controllers
{
    public class SmartphoneController : Controller
    {
        SmartphoneRepository smartphoneRepository;
        SupplierRepository supplierRepository;
        Uri baseAddress = new Uri("https://localhost:42573/api/");
        HttpClient client;

        // Constructor for SmartphoneController Using Parameter Repository
        public SmartphoneController(SmartphoneRepository smartphoneRepository, SupplierRepository supplierRepository)
        {
            this.smartphoneRepository = smartphoneRepository;
            this.supplierRepository = supplierRepository;
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        #region Catalog
        [HttpGet]
        public IActionResult Catalog()
        {
            // Authorization
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue($"Bearer", HttpContext.Session.GetString("Token"));

            IEnumerable<Smartphone> smartphones = null;

            var responseTask = client.GetAsync("smartphone");
            responseTask.Wait();
            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;
                var parsedObject = JObject.Parse(readTask);
                var dataOnly = parsedObject["data"].ToString();

                smartphones = JsonConvert.DeserializeObject<List<Smartphone>>(dataOnly);
            }
            else
            {
                smartphones = Enumerable.Empty<Smartphone>();
                ModelState.AddModelError(string.Empty, "Server Error " + result.StatusCode.ToString());
            }

            return View(smartphones);
        }
        #endregion Catalog

        #region Get Using Join
        [HttpGet]
        public IActionResult Index()
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue($"Bearer", HttpContext.Session.GetString("Token"));

            IEnumerable<Smartphone> smartphones = null;

            var responseTask = client.GetAsync("smartphone/getall");
            responseTask.Wait();
            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;
                var parsedObject = JObject.Parse(readTask);
                var dataOnly = parsedObject["data"].ToString();

                ViewData["Smartphone/Index"] = "Smartphone/Index";
                smartphones = JsonConvert.DeserializeObject<List<Smartphone>>(dataOnly);
            }
            else
            {
                return RedirectToAction("Catalog", "Smartphone");
            }

            return View(smartphones);
        }
        #endregion Get Using Join

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            var data = supplierRepository.Get();

            if(data != null)
            {
                var suppliers = new SelectList(data, "IdSupplier", "NameSupplier");
                if (suppliers.Count() > 0)
                {
                    ViewBag.Suppliers = suppliers;
                }
                return View();
            } else
            {
                return RedirectToAction("Index", "Smartphone");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Smartphone smartphones)
        {
            if (ModelState.IsValid)
            {
                var result = smartphoneRepository.Post(smartphones);
                if (result > 0)
                    return RedirectToAction("Index", "Smartphone");
            }
            return Create();
        }

        #endregion Create

        #region Delete
        [HttpGet("/smartphone/detail/{Id}")]
        public IActionResult Delete(int Id)
        {
            var smartphones = smartphoneRepository.Get(Id);
            if (smartphones != null)
            {
                return View(smartphones);
            }
            return RedirectToAction("Index", "Smartphone");
        }

        [HttpGet("/smartphone/delete/{Id}")]
        public IActionResult DeleteAction(int Id)
        {
            var result = smartphoneRepository.Delete(Id);
            if (result > 0)
                return RedirectToAction("Index", "Smartphone");
            return View();
        }
        #endregion Delete

        #region Edit
        [HttpGet("/smartphone/edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            var data = supplierRepository.Get();

            if(data != null)
            {
                var suppliers = new SelectList(data, "IdSupplier", "NameSupplier");
                if (suppliers.Count() > 0)
                {
                    ViewBag.Suppliers = suppliers;
                }

                var smartphones = smartphoneRepository.Get(Id);
                if (smartphones != null)
                {
                    return View(smartphones);
                }
                return View();
            } else
            {
                return RedirectToAction("Index", "Smartphone");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Smartphone smartphones)
        {
            if (ModelState.IsValid)
            {
                var result = smartphoneRepository.Put(smartphones);
                if (result > 0)
                    return RedirectToAction("Index", "Smartphone");
            } 
            return Edit(smartphones.IdSmartphone);
        }

        #endregion Edit

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
