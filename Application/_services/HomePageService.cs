using Application.Dto;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application._services
{
    public class HomePageService : IHomePageService
    {
        private readonly IDatabaseContext context;
        private readonly IUriComposerService uriComposerService;
        private readonly IGetCatalogItemPLPService getCatalogIItemPLPService;

        public HomePageService(IDatabaseContext context
            , IUriComposerService uriComposerService
            , IGetCatalogItemPLPService getCatalogIItemPLPService)
        {
            this.context = context;
            this.uriComposerService = uriComposerService;
            this.getCatalogIItemPLPService = getCatalogIItemPLPService;
        }


        public HomePageDto GetData()
        {
            var banners = context.Banners.Where(p => p.IsActive == true)
                .OrderBy(p => p.Priority)
                .ThenByDescending(p => p.Id)
                .Select(p => new BDto
                {
                    Id = p.Id,
                    Image = uriComposerService.ComposeImageUri(p.Image),
                    Link = p.Link,
                    Position = p.Position,
                }).ToList();

            var Bestselling = getCatalogIItemPLPService.Execute(new CatalogPLPRequestDto
            {
                AvailableStock = true,
                page = 1,
                pageSize = 20,
                SortType = SortType.BestSelling
            }).Data.ToList();

            var MostPopular = getCatalogIItemPLPService.Execute(new CatalogPLPRequestDto
            {
                AvailableStock = true,
                page = 1,
                pageSize = 20,
                SortType = SortType.MostPopular
            }).Data.ToList();

            return new HomePageDto
            {
                Banners = banners,
                bestSellers = Bestselling,
                MostPopular = MostPopular,
            };
        }
    }

}
