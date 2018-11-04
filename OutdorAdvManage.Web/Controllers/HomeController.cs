using AutoMapper;
using OutdorAdvManage.Model.Models;
using OutdorAdvManage.Web.ViewModels;
using Store.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OutdorAdvManage.Web.Controllers
{
    public class HomeController : Controller

    {
        private readonly IСounterpartyService сounterpartyService;

        public HomeController(IСounterpartyService сounterpartyService)
        {
            this.сounterpartyService = сounterpartyService;
        }

        public ActionResult Index()
        {
            CounterpartyViewModel counterpartyViewModel;
            IEnumerable<Counterparty> counterparties;

            counterparties = сounterpartyService.GetAll();


            counterpartyViewModel = new CounterpartyViewModel
            {
                NameCompany = counterparties.Last().NameCompany
            };
            
//            counterpartyViewModels = Mapper.Map<IEnumerable<Counterparty>, IEnumerable<CounterpartyViewModel>>(counterparties);

            return View(counterpartyViewModel);
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
                var counterparty= Mapper.Map<CounterpartyViewModel, Counterparty>(CounterpartyViewModel);
                сounterpartyService.CreateCounterparty(counterparty);


            сounterpartyService.SaveCounterparty();
            
            return RedirectToAction("Index");
        }
    }
}