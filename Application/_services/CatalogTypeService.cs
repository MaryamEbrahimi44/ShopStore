using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Common;
using Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application._services
{
    public class CatalogTypeService : ICatalogTypeService
    {
        private readonly IMapper mapper;
        private readonly IDatabaseContext context;


        public CatalogTypeService(IDatabaseContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }



        public BasedDto<CatalogTypeDto> Add(CatalogTypeDto catalogType)
        {
            var model = mapper.Map<CatalogType>(catalogType);
            context.CatalogTypes.Add(model);
            context.SaveChanges();
            return new BasedDto<CatalogTypeDto>(mapper.Map<CatalogTypeDto>(model), true, null);

        }

        public BasedDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType)
        {
            var model=context.CatalogTypes.SingleOrDefault(p=>p.Id==catalogType.Id);
            mapper.Map(catalogType,model);
            context.SaveChanges();
            //ترتیبشون درست نیست داره ارور میده
            return new BasedDto<CatalogTypeDto>(mapper.Map<CatalogTypeDto>(model) ,
                true,
                new List<string> { $"تایپ {model.Type}با موفقیت ویرایش شد.."});
        }

        public BasedDto<CatalogTypeDto> FindById(int Id)
        {
            var data = context.CatalogTypes.Find(Id);
            var result=mapper.Map<CatalogTypeDto>(data);

            return new BasedDto<CatalogTypeDto>( result, true, null);
        }

        public PaginatedItemDto<CatalogTypeListDto> GetList(int? parentId, int page, int pageSize)
        {
            int totalCount = 0;
            var model = context.CatalogTypes
                .Where(p => p.ParentCatalogTypeId == parentId)
                .PagedResult(
                page, pageSize, out totalCount);
            var result = mapper.ProjectTo<CatalogTypeListDto>(model).ToList();
            return new PaginatedItemDto<CatalogTypeListDto>(page, pageSize, totalCount, result);
        }

        public BasedDto Remove(int Id)
        {
            var catalogtype = context.CatalogTypes.Find(Id);
            context.CatalogTypes.Remove(catalogtype);
            context.SaveChanges();
            return new BasedDto(
          true,
          new List<string> { $"تایپ با موفقیت ویرایش شد.." });
        }
    }
}
