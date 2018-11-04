using OutdorAdvManage.Data.Infrastructure;
using OutdorAdvManage.Data.Repositories;
using OutdorAdvManage.Model.Models;
using System;
using System.Collections.Generic;

namespace Store.Service
{
    public interface IСounterpartyService
    {
        IEnumerable<Counterparty> GetCounterparties(string name = null);

        Counterparty GetCounterparty(string name);

        void CreateCounterparty(Counterparty category);

        void SaveCounterparty();
        IEnumerable<Counterparty> GetAll();
    }

    public class СounterpartyService : IСounterpartyService
    {
        private readonly ICounterpartyRepository counterpartyRepository;

        private readonly IUnitOfWork unitOfWork;

        public СounterpartyService(ICounterpartyRepository counterpartyRepository, IUnitOfWork unitOfWork)
        {
            this.counterpartyRepository = counterpartyRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public void CreateCounterparty(Counterparty counterparty)
        {
            counterpartyRepository.Add(counterparty);
        }

        public IEnumerable<Counterparty> GetAll()
        {
            return counterpartyRepository.GetAll();
        }

        public IEnumerable<Counterparty> GetCounterparties(string name = null)
        {
            throw new NotImplementedException();
        }

        public Counterparty GetCounterparty(string name)
        {
            throw new NotImplementedException();
        }

        public void SaveCounterparty()
        {
            unitOfWork.Commit(); 
        }




        #endregion ICategoryService Members
    }
}