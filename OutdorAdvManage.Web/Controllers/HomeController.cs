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
            MainViewModel mainViewModel;
            IEnumerable<Resolution> resolutions;

            resolutions = resolutionService.GetAll();

            mainViewModel = new MainViewModel();
            mainViewModel.Datas = new List<ViewModels.Data>();

            foreach (var item in resolutions)
            {
                mainViewModel.Datas.Add(new ViewModels.Data()
                {
                    Company = item.Сounterparty?.NameCompany ?? "NULL!!!",
                    Id = item.Number,
                    Description = item.AdvertisingConstruction?.TypeContsruction ?? "NULL!!!",
                    Start = item.Start,
                    Finish = item.Finish
                });
            }

            return View(mainViewModel);
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