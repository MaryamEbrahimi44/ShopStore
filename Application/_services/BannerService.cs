using Application.Dto;
using Application.Interfaces;
using Domain.Banners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application._services
{
    public class BannerService:IBannerService
    {
        private readonly IDatabaseContext context;

        public BannerService(IDatabaseContext context)
        {
            this.context = context;
        }

        public void AddBanner(BannerDto banner)
        {
            context.Banners.Add(new Banner
            {
                Image = banner.Image,
                IsActive = banner.IsActive,
                Link = banner.Link,
                Name = banner.Name,
                Position = banner.Position,
                Priority = banner.Priority,
            });
            context.SaveChanges();
        }

        public List<BannerDto> GetBanners()
        {
            var banners = context.Banners
                .Select(p => new BannerDto
                {
                    Image = p.Image,
                    IsActive = p.IsActive,
                    Link = p.Link,
                    Name = p.Link,
                    Position = p.Position,
                    Priority = p.Priority,
                }).ToList();
            return banners;
        }
    }

}
