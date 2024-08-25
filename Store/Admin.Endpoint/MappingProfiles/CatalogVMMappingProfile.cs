
using Admin.Endpoint.Pages.ViewModels;
using Application.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.EndPoint.MappingProfiles
{
    public class CatalogVMMappingProfile:Profile
    {
        public CatalogVMMappingProfile()
        {
            CreateMap<CatalogTypeDto, CatalogTypeViewModel>().ReverseMap();
        }
    }
}
