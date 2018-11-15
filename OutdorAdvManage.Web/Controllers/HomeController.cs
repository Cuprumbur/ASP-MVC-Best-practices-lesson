using AutoMapper;
using OutdorAdvManage.Model.Models;
using OutdorAdvManage.Web.ViewModels;
using Store.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OutdorAdvManage.Web.Controllers
{
    public class HomeController : Controller

    {
        private readonly IСounterpartyService сounterpartyService;
        private readonly IResolutionService resolutionService;

        public HomeController(IСounterpartyService сounterpartyService, IResolutionService resolutionService)
        {
            this.сounterpartyService = сounterpartyService;
            this.resolutionService = resolutionService;
        }

        public ActionResult Index()
        {
            IEnumerable<Resolution> resolutions;
            resolutions = resolutionService.GetAll();


            return View(resolutions);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create(CounterpartyViewModel CounterpartyViewModel)
        {
            var counterparty = Mapper.Map<CounterpartyViewModel, Counterparty>(CounterpartyViewModel);
            сounterpartyService.CreateCounterparty(counterparty);

            сounterpartyService.SaveCounterparty();

            return RedirectToAction("Index");
        }
    }
}