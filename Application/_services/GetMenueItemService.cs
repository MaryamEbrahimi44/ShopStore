using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application._services
{
    public class GetMenueItemService : IGetMenueItemService
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;

        public GetMenueItemService(IDatabaseContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<MenueItemDto> Execute()
        {
            var catalogType = context.CatalogTypes.Include(p => p.ParentCatalogType)
               .ToList();
            var data = mapper.Map<List<MenueItemDto>>(catalogType);
            return data;
        }
    }
}
