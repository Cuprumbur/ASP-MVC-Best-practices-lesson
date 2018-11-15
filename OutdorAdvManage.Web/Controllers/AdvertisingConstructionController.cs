using OutdorAdvManage.Data.Infrastructure;
using OutdorAdvManage.Model.Models;
using Store.Service;
using System.Web.Mvc;

namespace OutdorAdvManage.Web.Controllers
{
    public class AdvertisingConstructionController : Controller

    {
        private IAdvConstructionService advertisingConstructionService;
        private IUnitOfWork unitOfWork;

        public AdvertisingConstructionController(IAdvConstructionService advertisingConstructionService, IUnitOfWork unitOfWork)
        {
            this.advertisingConstructionService = advertisingConstructionService;
            this.unitOfWork = unitOfWork;
        }

        // GET: AdvertisingConstruction
        public ActionResult Index()
        {
            var items = advertisingConstructionService.GetAll();
            return View(items);
        }

        // GET: AdvertisingConstruction
        public ActionResult Sheme()
        {
            var items = advertisingConstructionService.GetAll();
            return View(items);
        }

        // GET: AdvertisingConstruction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdvertisingConstruction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvertisingConstruction/Create
        [HttpPost]
        public ActionResult Create(AdvertisingConstruction advertisingConstruction)
        {
            try
            {
                advertisingConstructionService.Create(advertisingConstruction);
                advertisingConstructionService.SaveCounterparty();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdvertisingConstruction/Edit/5
        public ActionResult Edit(int id)
        {
            var construction = advertisingConstructionService.GetById(id);
            return View(construction);
        }

        // POST: AdvertisingConstruction/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AdvertisingConstruction construction)
        {
            try
            {
                var val = advertisingConstructionService.GetById(id);
                val.Description = construction.Description;
                val.Latitude = construction.Latitude;
                val.Longitude = construction.Longitude;
                val.NumberInSheme = construction.NumberInSheme;
                val.NumberSides = construction.NumberSides;
                val.TypeContsruction = construction.TypeContsruction;
                advertisingConstructionService.Update(val);
                advertisingConstructionService.SaveCounterparty();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdvertisingConstruction/Delete/5
        public ActionResult Delete(int id)
        {
            var construction = advertisingConstructionService.GetById(id);
            return View(construction);
        }

        // POST: AdvertisingConstruction/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AdvertisingConstruction construction)
        {
            try
            {
                var val = advertisingConstructionService.GetById(id);
                advertisingConstructionService.Delete(val);
                advertisingConstructionService.SaveCounterparty();
                return View("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}