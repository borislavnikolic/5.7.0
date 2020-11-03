using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Runtime.Validation;
using Abp.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using orion.ConcractApplication;
using orion.ConcractApplication.DTO;
using orion.Web.ViewModel;
using orion.Exceptions;
using orion.PackageApplication;
using Abp.Web.Models;
using System.IO;
using orion.Web.Model.ViewModel.Concract;
using System.Runtime.InteropServices.WindowsRuntime;
using DinkToPdf;
using DinkToPdf.Contracts;
using orion.HistoryApplication;

namespace orion.Web.Controllers
{
    public class ConcractController : AbpController
    {
        private readonly IConcractService _concractService;
        private readonly IConcractCreationService _concractCreationService;
        private readonly IPackageService _packageService;
        private readonly IHistoryService _historyService;
        private IConverter _converter;
        public ConcractController(IConcractService concractService, 
            IConcractCreationService concractCreationService,
            IPackageService packageService,
            IHistoryService historyService,
            IConverter converter)
        {
            _concractService = concractService;
            _concractCreationService = concractCreationService;
            _packageService = packageService;
            _converter = converter;
            _historyService = historyService;
        }

    

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var concractActiveStatistic = await _concractService.GetStatusConcractCounts();
            var recentConcracts = await _concractService.GetRecentConcrats();
            var activeConcracts = await _concractService.GetActiveSum();

            var concractModel = new ConcractViewModel(concractActiveStatistic,recentConcracts,activeConcracts);

            return View(concractModel);
        }

        [HttpGet]
        public IActionResult CreateFirst()
        {
            
            return View();
        }

        [HttpPost]
        [DisableValidation]
        public async Task<IActionResult> CreateFirst(ConcractDTO input)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    await _concractCreationService.UserPartCreation(input);
                    HttpContext.Session.SetString("partConcract", JsonConvert.SerializeObject(input));
                    var packages = await _packageService.GetAllPackages();
                    var packageModel = new ConcractPackagesViewModel() { RestPackages = packages };
                    return View("CreateSecond",packageModel);
                }
                catch(UserExistsException exception)
                {
                    ViewBag.ErrorMessageUser = exception.Error;
                    ViewBag.Id = exception.Id;
                    return View(input);
                }
            }
            return View(input);

        }
        [HttpGet]
        public IActionResult CreateSecond()
        {
            return View();
        }

        [HttpPost]
        [WrapResult(WrapOnSuccess = false, WrapOnError = false)]
        public async Task<JsonResult> CreateSecond(List<int> packages)
        {

            var serializedContract = HttpContext.Session.GetString("partConcract");
            var partConcract = JsonConvert.DeserializeObject<ConcractDTO>(serializedContract);

            try
            {
                await _concractCreationService.CreateConcract(packages, partConcract,false);
                return Json(new { Success = 1, Message = "OK" });

            }
            catch (ConcractException exception)
            {
                return Json(new { Success =  0, Message = exception.Error });
            }

        }

        [HttpGet]
        public async Task<IActionResult> EditFirst(int id)
        {
            var concractDTO = await _concractService.GetConcract(id);
            var historiesDTO = await _historyService.ContractHistories(id);
            ViewBag.histories = historiesDTO;
            return View(concractDTO);
        }

        [HttpPost]
        public async Task<IActionResult> EditFirst(ConcractDTO input)
        {
            if (ModelState.IsValid)
            {
                    HttpContext.Session.SetString("partConcract", JsonConvert.SerializeObject(input));
                    var packages = await _packageService.GetChoosenAndRestPackages(input.Id);
                    var packageModel = new ConcractPackagesViewModel() { RestPackages = packages[0],ChoosenPackages = packages[1]};
                    return View("EditSecond", packageModel);    
            }
            return View(input);
        }

        [HttpGet]
        public IActionResult EditSecond()
        {
           return View();
        }

        [HttpPost]
        [WrapResult(WrapOnSuccess = false, WrapOnError = false)]
        public async Task<JsonResult> EditSecond(List<int> packages)
        {

            var serializedContract = HttpContext.Session.GetString("partConcract");
            var partConcract = JsonConvert.DeserializeObject<ConcractDTO>(serializedContract);

            try
            {
                await _concractCreationService.CreateConcract(packages, partConcract,true);
                return Json(new { Success = 1, Message = "OK" });

            }
            catch (ConcractException exception)
            {
                return Json(new { Success = 0, Message = exception.Error });
            }

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _concractCreationService.DeleteConcract(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Copy()
        {
            var concracts = await _concractService.GetConcracts();
            return View(concracts);
        }

        [HttpGet]
        public async Task<IActionResult> CreatePDF(int id)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report"/*,
                Out = @"D:\PDFCreator\Employee_Report.pdf"*/
            };
            var html = await _concractCreationService.GetPDF(id);
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = html,
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file = _converter.Convert(pdf);
            return File(file, "application/pdf");
        }

    }
}
