using AutoMapper;
using Store.Model.Models;
using Store.Web.ViewModels;

namespace Store.Web.Mappings
{
    internal class DomainToViewModelMappingProfile:Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Gadget, GadgetViewModel>();
        }
    }
}