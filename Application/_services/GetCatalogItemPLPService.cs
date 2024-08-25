using Application.Dto;
using Application.Interfaces;
using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application._services
{
    public class GetCatalogItemPLPService : IGetCatalogItemPLPService
    {
        private readonly IDatabaseContext context;
        private readonly IUriComposerService uriComposerService;

        public GetCatalogItemPLPService(IDatabaseContext context
            , IUriComposerService uriComposerService)
        {
            this.context = context;
            this.uriComposerService = uriComposerService;
        }
        public PaginatedItemDto<CatalogPLPDto> Execute(CatalogPLPRequestDto request)
        {
            int rowCount = 0;
            var query = context.CatalogItems
                .Include(p => p.CatalogItemImages)
                .OrderByDescending(p => p.Id)
                .AsQueryable();


            if (request.BrandId != null)
            {
                query = query.Where(p => request.BrandId.Any(b => b == p.CatalogBrandId));
            }

            if (request.CatalogTypeId != null)
            {
                query = query.Where(p => p.CatalogTypeId == request.CatalogTypeId);
            }

            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                query = query.Where(p => p.Name.Contains(request.SearchKey)
                || p.Description.Contains(request.SearchKey));
            }

            if (request.AvailableStock == true)
            {
                query = query.Where(p => p.AvailableStock > 0);
            }


            if (request.SortType == SortType.BestSelling)
            {
                query = query.Include(p => p.OrderItems)
                    .OrderByDescending(p => p.OrderItems.Count());
            }

           
            if (request.SortType == SortType.MostVisited)
            {
                query = query
                    .OrderByDescending(p => p.VisitCount);
            }

            if (request.SortType == SortType.Newest)
            {
                query = query
                    .OrderByDescending(p => p.Id);
            }

            if (request.SortType == SortType.Cheapest)
            {
                query = query
                    
                    .OrderBy(p => p.Price);
            }

            if (request.SortType == SortType.MostExpensive)
            {
                query = query
                  
                    .OrderByDescending(p => p.Price);
            }

            var data=query.PagedResult(request.page, request.pageSize, out rowCount)
                .Select(p => new CatalogPLPDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Rate = 4,
                    Image = uriComposerService
                    .ComposeImageUri(p.CatalogItemImages.FirstOrDefault().Src),
                    AvailableStock = p.AvailableStock
                }).ToList();
            return new PaginatedItemDto<CatalogPLPDto>(request.page, request.pageSize, rowCount, data);
        }
    }
}
