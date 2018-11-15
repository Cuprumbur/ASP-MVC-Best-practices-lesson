using OutdorAdvManage.Data.Infrastructure;
using OutdorAdvManage.Data.Repositories;
using OutdorAdvManage.Model.Models;
using System.Collections.Generic;

namespace Store.Service
{
    public interface IAdvConstructionService
    {
        IEnumerable<AdvertisingConstruction> GetAll();

        void Create(AdvertisingConstruction advertisingConstruction);

        void Update(AdvertisingConstruction advertisingConstruction);

        void Delete(AdvertisingConstruction advertisingConstruction);

        AdvertisingConstruction GetById(int id);

        void SaveCounterparty();
    }

    public class AdvConstructionService : IAdvConstructionService
    {
        private readonly IAdvertisingConstructionRepository advertisingConstructionRepository;

        private readonly IUnitOfWork unitOfWork;

        public AdvConstructionService(IAdvertisingConstructionRepository advertisingConstructionRepository, IUnitOfWork unitOfWork)
        {
            this.advertisingConstructionRepository = advertisingConstructionRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ICategoryService Members

        public void Create(AdvertisingConstruction advertisingConstruction)
        {
            advertisingConstructionRepository.Add(advertisingConstruction);
        }

        public void Delete(AdvertisingConstruction advertisingConstruction)
        {
            advertisingConstructionRepository.Delete(advertisingConstruction);
        }

        public IEnumerable<AdvertisingConstruction> GetAll()
        {
            return advertisingConstructionRepository.GetAll(); ;
        }

        public AdvertisingConstruction GetById(int id)
        {
            return advertisingConstructionRepository.GetById(id);
        }


        public void SaveCounterparty()
        {
            unitOfWork.Commit();
        }

        public void Update(AdvertisingConstruction advertisingConstruction)
        {
            advertisingConstructionRepository.Update(advertisingConstruction);
        }

        #endregion ICategoryService Members
    }
}