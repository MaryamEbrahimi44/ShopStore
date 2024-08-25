using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetCatalogItemPLPService getCatalogIItemPLPService;
        private readonly IGetCatalogItemPDPService getCatalogItemPDPService;

        public ProductController(IGetCatalogItemPLPService
            getCatalogIItemPLPService
            , IGetCatalogItemPDPService getCatalogItemPDPService)
        {
            this.getCatalogIItemPLPService = getCatalogIItemPLPService;
            this.getCatalogItemPDPService = getCatalogItemPDPService;
        }
        public IActionResult Index(CatalogPLPRequestDto request)
        {
            var data = getCatalogIItemPLPService.Execute(request);
            return View(data);
        }

        public IActionResult Details(int Id)
        {
            var data = getCatalogItemPDPService.Execute(Id);
            return View(data);
        }
    }
}
