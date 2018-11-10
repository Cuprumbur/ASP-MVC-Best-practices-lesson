using OutdorAdvManage.Model.Models;
using Store.Service;
using System.Linq;
using System.Web.Mvc;

namespace OutdorAdvManage.Web.Controllers
{
    public class ResolutionController : Controller
    {
        private IResolutionService resolutionService;

        public ResolutionController(IResolutionService resolutionService)
        {
            this.resolutionService = resolutionService;
        }

        // GET: Resolution
        public ActionResult Index()
        {
            var resolutions = resolutionService.GetAll();
            return View(resolutions);
        }

        // GET: Resolution/Details/5
        public ActionResult Details(int id)
        {
            Resolution resolution = resolutionService.GetById(id);
            return View(resolution);
        }

        // GET: Resolution/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resolution/Create
        [HttpPost]
        public ActionResult Create(Resolution resolution)
        {
            try
            {
                resolutionService.Create(resolution);
                resolutionService.SaveResolution();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resolution/Edit/5
        public ActionResult Edit(int id)
        {
            var res = resolutionService.GetById(id);
            return View(res);
        }

        // POST: Resolution/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Resolution resolution)
        {
            try
            {
                var res = resolutionService.GetById(id);
                // it HARD, use view model adn automapper
                res.AdvertisingConstructionId = resolution.AdvertisingConstructionId;
                res.AdvertisingContent = resolution.AdvertisingContent;
                res.ContractPermitionId = resolution.ContractPermitionId;
                res.Finish = resolution.Finish;
                res.Number = resolution.Number;
                res.OwnerId = resolution.OwnerId;
                res.Start = resolution.Start;
                res.СounterpartyId = resolution.СounterpartyId;

                resolutionService.Update(res);
                resolutionService.SaveResolution();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resolution/Delete/5
        public ActionResult Delete(int id)
        {
            var res = resolutionService.GetById(id);
            return View(res);
        }

        // POST: Resolution/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Resolution resolution)
        {
            try
            {
                // TODO: Add delete logic here
                var res = resolutionService.GetById(id);
                resolutionService.Delete(res);
                resolutionService.SaveResolution();
                var count = resolutionService.GetAll()?.Count();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}