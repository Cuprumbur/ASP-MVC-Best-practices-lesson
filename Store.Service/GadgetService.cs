using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace Store.Service
{
    public interface IGadgetService
    {
        IEnumerable<Gadget> GetGadgets();

        IEnumerable<Gadget> GetCategegoryGadgets(string categeoryName, string gadgetName = null);

        Gadget GetGadget(int id);

        void CreateGadget(Gadget gadget);

        void SaveGadget();
    }

    public class GadgetService : IGadgetService
    {
        private readonly IGadgetRepository gadgetRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public GadgetService(IGadgetRepository gadgetRepository,
            ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.gadgetRepository = gadgetRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IGadgetService Members

        public void CreateGadget(Gadget gadget)
        {
            gadgetRepository.Add(gadget);
        }

        public IEnumerable<Gadget> GetCategegoryGadgets(string categeoryName, string gadgetName = null)
        {
            var category = categoryRepository.GetCategoryByName(categeoryName);
            return category.Gadgets.Where(g => g.Name.ToLower().Contains(gadgetName.ToLower().Trim()));
        }

        public Gadget GetGadget(int id)
        {
            var gadget = gadgetRepository.GetById(id);
            return gadget;
        }

        public IEnumerable<Gadget> GetGadgets()
        {
            var gadgets = gadgetRepository.GetAll();
            return gadgets;
        }

        public void SaveGadget()
        {
            unitOfWork.Commit();
        }

        #endregion IGadgetService Members
    }
}