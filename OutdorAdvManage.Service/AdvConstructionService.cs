using OutdorAdvManage.Data.Infrastructure;
using OutdorAdvManage.Data.Repositories;
using OutdorAdvManage.Model.Models;
using System;
using System.Collections.Generic;

namespace Store.Service
{
    public interface IAdvConstructionService
    {
        void CreateCounterparty(AdvertisingConstruction advertisingConstruction);
        IEnumerable<AdvertisingConstruction> GetAll();
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

        public void CreateCounterparty(AdvertisingConstruction advertisingConstruction)
        {
            advertisingConstructionRepository.Add(advertisingConstruction);
        }

        public IEnumerable<AdvertisingConstruction> GetAll()
        {
            return advertisingConstructionRepository.GetAll(); ;

        }

        #region ICategoryService Members

        public void SaveCounterparty()
        {
            unitOfWork.Commit(); 
        }




        #endregion ICategoryService Members
    }
}