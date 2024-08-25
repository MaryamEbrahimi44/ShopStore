using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application._services
{
    public class AddNewCatalogItemService: IAddNewCatalogItemService
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;

        public AddNewCatalogItemService(IDatabaseContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public BasedDto<int> Execute(AddNewCatalogItemDto request)
        {
            var catalogItem = mapper.Map<CatalogItem>(request);
            context.CatalogItems.Add(catalogItem);
            context.SaveChanges();
            return new BasedDto<int>(catalogItem.Id,true, new List<string> { "با موفقیت ثبت شد" });
        }
    }
}
