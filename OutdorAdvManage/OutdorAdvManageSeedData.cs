using OutdorAdvManage.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace OutdorAdvManage.Data
{
    enum ConstuctuionTypes
    {
        Пано,
        Наружняя
    }

    enum ContentTypes
    {
        Реклама
    }
    public class OutdorAdvManageData : DropCreateDatabaseAlways<OutdorAdvManageEntities>
    {
        List<Contract> Contracts;
        List<Resolution> Resolutions;
        List<AdvertisingConstruction> Constructions;
        List<Counterparty> Counterpartys;
        List<ContractPermition> ContractPermitions;
        Owner city;



        protected override void Seed(OutdorAdvManageEntities context)
        {


            //Counterparty
            Counterpartys = GetCounterparty();
         

            //Owner
            city = new Owner
            {
                Сounterparty = Counterpartys[0],
                Start = DateTime.MinValue,
                Finish = DateTime.MaxValue,
                Construction = null
            };

            //Contract
            Contracts = GetContracts();
          
            //AdvertisingConstruction
            Constructions = GetAdvertisingConstructions();


            ContractPermitions = GetContractPermitions();

            //Resolution
            Resolutions = GetResolutions();
       

            //IssuancePermit

            context.Owners.Add(city);
            Counterpartys.ForEach(x => context.Counterpartys.Add(x));
            Contracts.ForEach(x => context.Contracts.Add(x));
            Constructions.ForEach(x => context.AdvertisingConstructions.Add(x));
            Resolutions.ForEach(x => context.Resolutions.Add(x));
            GetIssuancePermits().ForEach(x => context.IssuancePermits.Add(x));
           ContractPermitions.ForEach(x => context.ContractPermitions.Add(x));


            //Photo

            context.Commit();
         
        }

        private List<ContractPermition> GetContractPermitions()
        {
            var list = new List<ContractPermition>
            ();
            for (int i = 0; i < 6; i++)
            {
                list.Add(new ContractPermition() { Number =i,Time= new DateTime(2018,i+1,i+1)});
            }
            return list;
        }

        private List<Resolution> GetResolutions()
        {
            var list = new List<Resolution>();
            for (int i = 0; i < 6; i++)
            {
                list.Add(new Resolution
             {
                 Construction = Constructions[i],
                 AdvertisingContent = ContentTypes.Реклама.ToString(),
                 ContractPermitions = ContractPermitions[i],
                 Owner = city,
                 Сounterparty = Counterpartys[i],
                 Start = new DateTime(2018, 1, i+1),
                 Finish = new DateTime(2018, 10, i+1),
                 Number = i,
                 Time = new DateTime(2018,i+1,i+1),
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
                    Contract = Contracts[0],
                    IsStateDutyPaid = false,
                    IssueDate = new DateTime(2017,1,1),
                    Received = false,
                    Resolution = Resolutions[0],
                },
                new IssuancePermit
                {
                    Contract = Contracts[1],
                    IsStateDutyPaid = true,
                    IssueDate = new DateTime(2017,3,1),
                    Received = true,
                    Resolution = Resolutions[1],

                },
                new IssuancePermit
                {
                    Contract = Contracts[2],
                    IsStateDutyPaid = true,
                    IssueDate = new DateTime(2018,4,1),
                    Received = false,
                    Resolution = Resolutions[2],
                },
                new IssuancePermit
                {
                    Contract = Contracts[3],
                    IsStateDutyPaid = true,
                    IssueDate = new DateTime(2018,9,1),
                    Received = false,
                    Resolution = Resolutions[3],
                },
                new IssuancePermit
                {
                    Contract = Contracts[4],
                    IsStateDutyPaid = false,
                    IssueDate = new DateTime(2018,10,1),
                    Received = false,
                    Resolution = Resolutions[4],
                },
                new IssuancePermit
                {
                    Contract = Contracts[5],
                    IsStateDutyPaid = true,
                    IssueDate = new DateTime(2018,11,1),
                    Received = false,
                    Resolution = Resolutions[5],
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
                   Size = new System.Drawing.Size(50,30),
                   TypeContsruction = ConstuctuionTypes.Наружняя.ToString()
                },
                 new AdvertisingConstruction
                {
                   NumberInSheme = 11,
                   NumberSides = 2,
                   Size = new System.Drawing.Size(30,50),
                   TypeContsruction = ConstuctuionTypes.Наружняя.ToString()
                },
                  new AdvertisingConstruction
                {
                   NumberInSheme = 12,
                   NumberSides = 1,
                   Size = new System.Drawing.Size(10,60),
                   TypeContsruction = ConstuctuionTypes.Наружняя.ToString()
                }, new AdvertisingConstruction
                {
                   NumberInSheme = 13,
                   NumberSides = 1,
                   Size = new System.Drawing.Size(10,60),
                   TypeContsruction = ConstuctuionTypes.Пано.ToString()
                }, new AdvertisingConstruction
                {
                   NumberInSheme = 14,
                   NumberSides = 1,
                   Size = new System.Drawing.Size(10,60),
                   TypeContsruction = ConstuctuionTypes.Пано.ToString()
                }, new AdvertisingConstruction
                {
                   NumberInSheme = 15,
                   NumberSides = 1,
                   Size = new System.Drawing.Size(10,60),
                   TypeContsruction = ConstuctuionTypes.Пано.ToString()
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