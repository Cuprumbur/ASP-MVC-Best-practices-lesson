using AutoMapper;
using Store.Model.Models;
using Store.Service;
using Store.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Web.Controllers
{
    public class HomeController : Controller

    {
        private readonly ICategoryService categoryService;
        private readonly IGadgetService gadgetService;

        public HomeController(ICategoryService categoryService, IGadgetService gadgetService)
        {
            this.categoryService = categoryService;
            this.gadgetService = gadgetService;
        }

        public ActionResult Index(string category = null)
        {
            IEnumerable<CategoryViewModel> viewModelsGadgets;
            IEnumerable<Category> categories;

            categories = categoryService.GetCategories(category).ToList();

            viewModelsGadgets = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
                 
            return View(viewModelsGadgets);
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

        public ActionResult  Filter(string category, string gadgetName)
        {
            IEnumerable<GadgetViewModel> viewModelsGadgets;
            IEnumerable<Gadget> gadgets;

            gadgets = gadgetService.GetCategegoryGadgets(category, gadgetName);
            viewModelsGadgets = Mapper.Map<IEnumerable<Gadget>, IEnumerable<GadgetViewModel>>(gadgets);

            return View(viewModelsGadgets);
        }

        public ActionResult Create(GadgetFormViewModel newGadget)
        {
            if (newGadget?.File != null)
            {
                var gadget = Mapper.Map<GadgetFormViewModel, Gadget>(newGadget);
                gadgetService.CreateGadget(gadget);

                string gadgetPicture = System.IO.Path.GetFileName(newGadget.File.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/images/"), gadgetPicture);
                newGadget.File.SaveAs(path);

                gadgetService.SaveGadget();
            }

            var category = categoryService.GetCategory(newGadget.GadgetCategory);
            return RedirectToAction("Index", new { category = category.Name });
        }
        
    }
}