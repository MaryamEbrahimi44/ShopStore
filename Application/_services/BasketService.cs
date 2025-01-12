﻿using Application.Dto;
using Application.Interfaces;
using Domain.Baskets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application._services
{
    public class BasketService: IBasketService
    {
  
        private readonly IDatabaseContext context;
        private readonly IUriComposerService uriComposerService;

        public BasketService(IDatabaseContext context
            , IUriComposerService uriComposerService)
        {
            this.context = context;
            this.uriComposerService = uriComposerService;
        }

        public void AddItemToBasket(int basketId, int catalogItemId, int quantity = 1)
        {
            var basket = context.Baskets.FirstOrDefault(p => p.Id == basketId);
            if (basket == null)
                throw new Exception("");

            var catalog = context.CatalogItems.Find(catalogItemId);
            basket.AddItem(catalogItemId, quantity, catalog.Price);

            context.SaveChanges();
        }

        public BasketDto GetBasketForUser(string UserId)
        {
            var basket = context.Baskets
              .Include(p => p.Items)
              .ThenInclude(p => p.CatalogItem)
              .ThenInclude(p => p.CatalogItemImages)
              .SingleOrDefault(p => p.BuyerId == UserId);
            if (basket == null)
            {
                return null;
            }
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(item => new BasketItemDto
                {
                    CatalogItemid = item.CatalogItemId,
                    Id = item.Id,
                    CatalogName = item.CatalogItem.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    ImageUrl = uriComposerService.ComposeImageUri(item?.CatalogItem?
                     .CatalogItemImages?.FirstOrDefault()?.Src ?? ""),

                }).ToList(),
            };
        }

        public BasketDto GetOrCreateBasketForUser(string BuyerId)
        {
            var basket = context.Baskets
                .Include(p => p.Items)
                .ThenInclude(p => p.CatalogItem)
                .ThenInclude(p => p.CatalogItemImages)
                .SingleOrDefault(p => p.BuyerId == BuyerId);
            if (basket == null)
            {
                //سبد خرید را ایجاد کنید
                return CreateBasketForUser(BuyerId);
            }
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(item => new BasketItemDto
                {
                    CatalogItemid = item.CatalogItemId,
                    Id = item.Id,
                    CatalogName = item.CatalogItem.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    ImageUrl = uriComposerService.ComposeImageUri(item?.CatalogItem?
                     .CatalogItemImages?.FirstOrDefault()?.Src ?? ""),

                }).ToList(),
            };

        }

        public bool RemoveItemFromBasket(int ItemId)
        {
            var item = context.BasketItems.SingleOrDefault(p => p.Id == ItemId);
            context.BasketItems.Remove(item);
            context.SaveChanges();
            return true;
        }

        public bool SetQuantities(int itemId, int quantity)
        {
            var item = context.BasketItems.SingleOrDefault(p => p.Id == itemId);
            item.SetQuantity(quantity);
            context.SaveChanges();
            return true;
        }

        public void TransferBasket(string anonymousId, string UserId)
        {
            var anonymousBasket = context.Baskets
               .SingleOrDefault(p => p.BuyerId == anonymousId);
            if (anonymousBasket == null) return;
            var userBasket = context.Baskets.SingleOrDefault(p => p.BuyerId == UserId);
            if (userBasket == null)
            {
                userBasket = new Basket(UserId);
                context.Baskets.Add(userBasket);
            }

            foreach (var item in anonymousBasket.Items)
            {
                userBasket.AddItem(item.CatalogItemId, item.Quantity, item.UnitPrice);
            }

            context.Baskets.Remove(anonymousBasket);

            context.SaveChanges();
        }

        private BasketDto CreateBasketForUser(string BuyerId)
        {
            Basket basket = new Basket(BuyerId);
            context.Baskets.Add(basket);
            context.SaveChanges();
            return new BasketDto
            {
                BuyerId = basket.BuyerId,
                Id = basket.Id,
            };
        }
    }

}

