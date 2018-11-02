﻿using AutoMapper;
using Store.Model.Models;
using Store.Web.ViewModels;

namespace Store.Web.Mappings
{
    internal class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<GadgetFormViewModel, Gadget>()
                            .ForMember(g => g.Name, map => map.MapFrom(vm => vm.GadgetTitle))
                            .ForMember(g => g.Description, map => map.MapFrom(vm => vm.GadgetDescription))
                            .ForMember(g => g.Price, map => map.MapFrom(vm => vm.GadgetPrice))
                            .ForMember(g => g.Image, map => map.MapFrom(vm => vm.File.FileName))
                            .ForMember(g => g.CategoryID, map => map.MapFrom(vm => vm.GadgetCategory));
        }
    }
}