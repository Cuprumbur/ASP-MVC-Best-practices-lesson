using OutdorAdvManage.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OutdorAdvManage.Data
{
    internal enum ConstuctuionTypes
    {
        Пано,
        Наружняя
    }

    internal enum ContentTypes
    {
        Реклама
    }

    public class OutdorAdvManageData : DropCreateDatabaseAlways<OutdorAdvManageEntities>
    {
        private Owner city;
        private DbSet<Contract> Contracts;
        private DbSet<Resolution> Resolutions;
        private DbSet<AdvertisingConstruction> Constructions;
        private DbSet<Counterparty> Counterpartys;
        private DbSet<ContractPermition> ContractPermitions;

        protected override void Seed(OutdorAdvManageEntities context)
        {
            //Counterparty
            GetCounterparty().ForEach(x => context.Counterpartys.Add(x));
            context.Commit();
            Counterpartys = context.Counterpartys;

            context.Owners.Add(new Owner
            {
                Сounterparty = Counterpartys.Where(x => x.CounterpartyId == 0).FirstOrDefault(),
                Start = new DateTime(2000, 1, 1),
                Finish = new DateTime(2100, 1, 1),
                Construction = null
            });
            //Owner
            context.Commit();
            city = context.Owners.FirstOrDefault();

            //Contract
            GetContracts().ForEach(x => context.Contracts.Add(x));
            context.Commit();
            Contracts = context.Contracts;

            //AdvertisingConstruction
            GetAdvertisingConstructions().ForEach(x => context.AdvertisingConstructions.Add(x));
            context.Commit();
            Constructions = context.AdvertisingConstructions;

            GetContractPermitions().ForEach(x => context.ContractPermitions.Add(x));
            context.Commit();
            ContractPermitions = context.ContractPermitions;

            //Resolution
            GetResolutions().ForEach(x => context.Resolutions.Add(x));
            context.Commit();
            Resolutions = context.Resolutions;

            //IssuancePermit
            GetIssuancePermits().ForEach(x => context.IssuancePermits.Add(x));
            context.Commit();

            //Photo
        }

        private List<ContractPermition> GetContractPermitions()
        {
            var list = new List<ContractPermition>();
            for (int i = 0; i < 6; i++)
            {
                list.Add(new ContractPermition() { Number = i, Time = new DateTime(2018, i + 1, i + 1) });
            }
            return list;
        }

        private List<Resolution> GetResolutions()
        {
            var list = new List<Resolution>();

            for (int i = 1; i <= 6; i++)
            {
                list.Add(new Resolution
                {
                    AdvertisingConstruction = Constructions.Where(x => x.AdvertisingConstructionId == i).FirstOrDefault(),
                    AdvertisingContent = ContentTypes.Реклама.ToString(),
                    ContractPermition = ContractPermitions.Where(x => x.ContractPermitionId == i).FirstOrDefault(),
                    Owner = city,
                    Сounterparty = Counterpartys.Where(x => x.CounterpartyId == i).FirstOrDefault(),
                    Start = new DateTime(2018, 1, i + 1),
                    Finish = new DateTime(2018, 10, i + 1).AddMonths(i),
                    Number = i,
                    Time = new DateTime(2018, i + 1, i + 1),
                });
            }
            return list;
        }

        private List<IssuancePermit> GetIssuancePermits()
        {
            return new List<IssuancePermit>
            {
                new IssuancePermit
                {
                    IsStateDutyPaid = false,
                    IssueDate = new DateTime(2017,1,1),
                    Received = false,
                    Resolution = Resolutions.Where(x=>x.AdvertisingConstructionId == 6).FirstOrDefault(),
                    Contract = Contracts.Where(x=>x.ContractId== 6).FirstOrDefault(),
                },
                new IssuancePermit
                {
                    IsStateDutyPaid = true,
                    IssueDate = new DateTime(2017,3,1),
                    Received = true,
                    Resolution = Resolutions.Where(x=>x.AdvertisingConstructionId == 1).FirstOrDefault(),
                    Contract = Contracts.Where(x=>x.ContractId== 1).FirstOrDefault(),
                },
                new IssuancePermit
                {
                    IsStateDutyPaid = true,
                    IssueDate = new DateTime(2018,4,1),
                    Received = false,
                    Resolution = Resolutions.Where(x=>x.AdvertisingConstructionId == 2).FirstOrDefault(),
                    Contract = Contracts.Where(x=>x.ContractId== 2).FirstOrDefault(),
                },
                new IssuancePermit
                {
                    IsStateDutyPaid = true,
                    IssueDate = new DateTime(2018,9,1),
                    Received = false,
                    Resolution = Resolutions.Where(x=>x.AdvertisingConstructionId == 3).FirstOrDefault(),
                    Contract = Contracts.Where(x=>x.ContractId== 3).FirstOrDefault(),
                },
                new IssuancePermit
                {
                    IsStateDutyPaid = false,
                    IssueDate = new DateTime(2018,10,1),
                    Received = false,
                    Resolution = Resolutions.Where(x=>x.AdvertisingConstructionId == 4).FirstOrDefault(),
                    Contract = Contracts.Where(x=>x.ContractId== 4).FirstOrDefault(),
                },
                new IssuancePermit
                {
                    IsStateDutyPaid = true,
                    IssueDate = new DateTime(2018,11,1),
                    Received = false,
                    Resolution = Resolutions.Where(x=>x.AdvertisingConstructionId ==4).FirstOrDefault(),
                    Contract = Contracts.Where(x=>x.ContractId== 4).FirstOrDefault(),
                },
            };
        }

        private List<AdvertisingConstruction> GetAdvertisingConstructions()
        {
            return new List<AdvertisingConstruction>
            {
                new AdvertisingConstruction
                {
                   NumberInSheme = 10,
                   NumberSides = 1,
                   //Size = new System.Drawing.Size(50,30),
                   TypeContsruction = ConstuctuionTypes.Наружняя.ToString(),
                   Description = "п. Орешково",
                   Geography = AdvertisingConstruction.CreatePoint(51.845854, 107.614861)
                },
                 new AdvertisingConstruction
                {
                   NumberInSheme = 11,
                   NumberSides = 2,
                   //Size = new System.Drawing.Size(30,50),
                   TypeContsruction = ConstuctuionTypes.Наружняя.ToString(),
                   Description = "ДНТ Лесное",
                   Geography = AdvertisingConstruction.CreatePoint(51.871828, 107.649022)
                },
                  new AdvertisingConstruction
                {
                   NumberInSheme = 12,
                   NumberSides = 1,
                   //Size = new System.Drawing.Size(10,60),
                   TypeContsruction = ConstuctuionTypes.Наружняя.ToString(),
                   Description = "Поворот на Восточном",

                   Geography = AdvertisingConstruction.CreatePoint(51.847232, 107.679577)
                }, new AdvertisingConstruction
                {
                   NumberInSheme = 13,
                   NumberSides = 1,
                   //Size = new System.Drawing.Size(10,60),
                   TypeContsruction = ConstuctuionTypes.Пано.ToString(),
                   Description = "Бизнес инкубатор",
                   Geography = AdvertisingConstruction.CreatePoint(51.814452, 107.594605)
                }, new AdvertisingConstruction
                {
                   NumberInSheme = 14,
                   NumberSides = 1,
                   //Size = new System.Drawing.Size(10,60),
                   TypeContsruction = ConstuctuionTypes.Пано.ToString(),
                   Description = "Авторынок",
                   Geography = AdvertisingConstruction.CreatePoint(51.818909, 107.621727)
                }, new AdvertisingConstruction
                {
                   NumberInSheme = 15,
                   NumberSides = 1,
                   //Size = new System.Drawing.Size(10,60),
                   TypeContsruction = ConstuctuionTypes.Пано.ToString(),
                   Description = "20 а Орел",
                   Geography = AdvertisingConstruction.CreatePoint(51.821138, 107.657776)
                },
            };
        }

        private List<Contract> GetContracts()
        {
            return new List<Contract> {
                new Contract
                {
                    NumberContract = "1",
                    Start = new DateTime(2017,1,1),
                    Finish = new DateTime(2017,5,10),
                },
                new Contract
                {
                    NumberContract = "2",
                    Start = new DateTime(2018,1,2),
                    Finish = new DateTime(2018,12,10),
                },
                new Contract
                {
                    NumberContract = "3",
                    Start = new DateTime(2017,1,3),
                    Finish = new DateTime(2019,1,10),
                },
                new Contract
                {
                    NumberContract = "4",
                    Start = new DateTime(2018,2,3),
                    Finish = new DateTime(2019,2,10),
                },
                new Contract
                {
                    NumberContract = "5",
                    Start = new DateTime(2017,1,5),
                    Finish = new DateTime(2020,1,10),
                },
                 new Contract
                {
                    NumberContract = "6",
                    Start = new DateTime(2017,1,6),
                    Finish = new DateTime(2019,5,10),
                },
            };
        }

        private List<Counterparty> GetCounterparty()
        {
            return new List<Counterparty>
            {
                new Counterparty {
                    NameCompany  = @"ООО ""Дюпон-Инвест""",
                    IsLegalEntity = true,
                    FirstName = "Бато",
                    LastName= "Гармаев",
                    Patronymic =  "Будожапович"
                },
                new Counterparty {
                    NameCompany  = @"ИП Андреев",
                    IsLegalEntity = false,
                    FirstName = "Андреев",
                    LastName= "Алексей",
                    Patronymic =  "Алексеевич"
                },
                new Counterparty {
                    NameCompany  = @" ОАО ""Плодоовощ""",
                    IsLegalEntity = true,
                    FirstName = "Матвеев",
                    LastName= "Николай",
                    Patronymic =  "Федорович"
                },
                new Counterparty {
                    NameCompany  = @"ИП Имеева",
                    IsLegalEntity = false,
                    FirstName = "Имеева",
                    LastName= "Анастасия Павловна",
                    Patronymic =  "Алексеевич"
                },
                new Counterparty {
                    NameCompany  = @"ООО ""Реквием""",
                    IsLegalEntity = true,
                    FirstName = "Петров",
                    LastName= "Дмитрий",
                    Patronymic =  "Александрович"
                },
                  new Counterparty {
                    NameCompany  = @"ООО ""Праздник""",
                    IsLegalEntity = true,
                    FirstName = "Васильев",
                    LastName= "Борис",
                    Patronymic =  "Александрович"
                }
            };
        }
    }
}