using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneChalin.Context;
using PhoneChalin.Models;
using PhoneChalin.Repositories.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneChalin.Controllers
{
    public class SupplierController : Controller
    {
        SupplierRepository supplierRepository;

        public SupplierController(SupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        #region Get
        [HttpGet]
        public IActionResult Index()
        {
            var buyers = supplierRepository.Get();

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
        public IActionResult Create(Supplier suppliers)
        {
            if (ModelState.IsValid)
            {
                var result = supplierRepository.Post(suppliers);
                if (result > 0)
                    return RedirectToAction("Index", "Supplier");
                return View();
            }

            return View();
        }
        #endregion Create

        #region Edit
        [HttpGet("/supplier/edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            var suppliers = supplierRepository.Get(Id);
            if (suppliers != null)
            {
                return View(suppliers);
            }
            return RedirectToAction("Index", "Supplier");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Supplier suppliers)
        {
            if (ModelState.IsValid)
            {
                var result = supplierRepository.Put(suppliers);
                if (result > 0)
                    return RedirectToAction("Index", "Supplier");
                return View();
            }

            return RedirectToAction("Index", "Supplier");
        }

        #endregion Edit

        #region Delete
        [HttpGet("/supplier/detail/{Id}")]
        public IActionResult Delete(int Id)
        {
            var suppliers = supplierRepository.Get(Id);
            if (suppliers != null)
            {
                return View(suppliers);
            }
            return RedirectToAction("Index", "Supplier");
        }

        [HttpGet("/supplier/delete/{Id}")]
        public IActionResult DeleteAction(int Id)
        {
            var result = supplierRepository.Delete(Id);
            if (result > 0)
                return RedirectToAction("Index", "Supplier");
            return View();
        }

        #endregion Delete
    }
}
