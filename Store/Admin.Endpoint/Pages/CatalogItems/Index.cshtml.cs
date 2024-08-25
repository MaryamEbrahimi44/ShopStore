using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.Endpoint.Pages.CatalogItems
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogItemService catalogItemService;

        public IndexModel(ICatalogItemService catalogItemService)
        {
            this.catalogItemService = catalogItemService;
        }
        public PaginatedItemDto<CatalogItemListDto> CatalogItems { get; set; }
        public void OnGet(int page = 1, int pageSize = 100)
        {
            CatalogItems = catalogItemService.GetCatalogList(page, pageSize);
        }
    }
}
