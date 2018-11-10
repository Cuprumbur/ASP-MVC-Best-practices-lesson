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

        void SaveResolution();
        void Create(Resolution resolution);
        Resolution GetById(int id);
        void Update(Resolution resolution);
        void Delete(Resolution resolution);
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

        public void Create(Resolution resolution)
        {
            resolutionRepository.Add(resolution);
        }

        public void Delete(Resolution resolution)
        {
            resolutionRepository.Delete(resolution);
        }

        #region ICategoryService Members

        public IEnumerable<Resolution> GetAll()
        {
            return resolutionRepository.GetAll();
        }

        public Resolution GetById(int id)
        {
            return resolutionRepository.GetById(id);
        }

        public void SaveResolution()
        {
            unitOfWork.Commit(); 
        }

        public void Update(Resolution resolution)
        {
            resolutionRepository.Update(resolution);
        }

        #endregion ICategoryService Members
    }
}