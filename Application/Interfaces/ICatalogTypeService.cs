using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICatalogTypeService
    {
        public BasedDto<CatalogTypeDto> Add(CatalogTypeDto catalogType);
        public BasedDto Remove(int Id);
        public BasedDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType);
        public BasedDto<CatalogTypeDto> FindById(int Id);
        public PaginatedItemDto<CatalogTypeListDto> GetList(int? parentId,int page, int pageSize);
    }
}
