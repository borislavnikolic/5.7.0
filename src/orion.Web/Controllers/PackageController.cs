using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Runtime.Validation;
using Microsoft.AspNetCore.Mvc;
using orion.PackageApplication;
using orion.PackageApplication.DTO;
using orion.Web.ViewModel;

namespace orion.Web.Controllers
{
    public class PackageController : orionControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageServie)
        {
            _packageService = packageServie;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var output = await _packageService.GetAllPackages();

            var viewmodel = new PackageViewModel(output);
            return View(viewmodel);
        }


        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [DisableValidation]
        public async Task<IActionResult> Create(InputCreatePackage input)
        {
            if(ModelState.IsValid)
            {
                 await _packageService.InsertPackage(input);
                 return RedirectToAction("Index");
            }
            return View(input);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var package = await _packageService.GetPackage(id);
            return View(package);
        }
        [HttpPost]
        public async Task<IActionResult> Update(InputCreatePackage input)
        {
            if (ModelState.IsValid)
            {
                await _packageService.UpdatePackage(input);
                return RedirectToAction("Index");
            }
            return View(input);
        }
        [HttpDelete]
        public async Task<JsonResult> Delete(int id)
        {
            bool ok = await _packageService.DeletePackage(id);
            return Json(new { Success = ok == true ? 1 : 0 });
            //return RedirectToAction("Index");
        }
    }
}
