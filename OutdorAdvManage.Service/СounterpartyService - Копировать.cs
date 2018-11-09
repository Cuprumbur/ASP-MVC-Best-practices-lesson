using OutdorAdvManage.Data.Infrastructure;
using OutdorAdvManage.Data.Repositories;
using OutdorAdvManage.Model.Models;
using System;
using System.Collections.Generic;

namespace Store.Service
{
    public interface IResolutionService
    {
        IEnumerable<Resolution> GetAll();

        void SaveCounterparty();
    }

    public class ResolutionService : IResolutionService
    {
        private readonly IResolutionRepository resolutionRepository;

        private readonly IUnitOfWork unitOfWork;

        public ResolutionService(IResolutionRepository resolutionRepository, IUnitOfWork unitOfWork)
        {
            this.resolutionRepository = resolutionRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Resolution> GetAll()
        {
            return resolutionRepository.GetAll();
        }

        public void SaveCounterparty()
        {
            unitOfWork.Commit(); 
        }
        
        #endregion ICategoryService Members
    }
}