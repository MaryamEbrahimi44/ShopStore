using Application.Dto;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application._services
{
    public class GetCatalogItemPDPService : IGetCatalogItemPDPService
    {
        private readonly IDatabaseContext context;
        private readonly IUriComposerService uriComposerService;

        public GetCatalogItemPDPService(IDatabaseContext context, IUriComposerService uriComposerService)
        {
            this.context = context;
            this.uriComposerService = uriComposerService;
        }
        public CatalogItemPDPDto Execute(int Id)
        {
            var catalogitem = context.CatalogItems
                .Include(p => p.CatalogItemFeatures)
                .Include(p => p.CatalogItemImages)
                .Include(p => p.CatalogType)
                .Include(p => p.CatalogBrand)
                .SingleOrDefault(p => p.Id == Id);
            catalogitem.VisitCount += 1;
            context.SaveChanges();
            var feature = catalogitem.CatalogItemFeatures
                .Select(p => new PDPFeaturesDto
                {
                    Group = p.Group,
                    Key = p.Key,
                    Value = p.Value
                }).ToList()
                .GroupBy(p => p.Group);

            var similarCatalogItems = context
               .CatalogItems
               .Include(p => p.CatalogItemImages)
               .Where(p => p.CatalogTypeId == catalogitem.CatalogTypeId)
               .Take(10)
               .Select(p => new SimilarCatalogItemDto
               {
                   Id = p.Id,
                   Images = uriComposerService.ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                   Price = p.Price,
                   Name = p.Name
               }).ToList();

            return new CatalogItemPDPDto
            {
                Features = feature,
                SimilarCatalogs = similarCatalogItems,
                Id = catalogitem.Id,
                Name = catalogitem.Name,
                Brand = catalogitem.CatalogBrand.Brand,
                Type = catalogitem.CatalogType.Type,
                Price = catalogitem.Price,
                Description = catalogitem.Description,
                Images = catalogitem.CatalogItemImages.Select(p => uriComposerService.ComposeImageUri(p.Src)).ToList(),

            };


        }
    }
}
