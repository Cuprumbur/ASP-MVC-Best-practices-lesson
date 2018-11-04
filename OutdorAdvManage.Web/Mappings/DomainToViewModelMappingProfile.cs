using AutoMapper;
using OutdorAdvManage.Model.Models;
using OutdorAdvManage.Web.ViewModels;

namespace OutdorAdvManage.Web.Mappings
{
    internal class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Counterparty, CounterpartyViewModel>();
        }
    }
}