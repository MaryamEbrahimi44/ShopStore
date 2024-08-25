using Application.Interfaces;
using AutoMapper;
using Domain.Baskets;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application._services
{
    public class OrderService : IOrderService
    {
        private readonly IDatabaseContext Context;
        private readonly IMapper mapper;
        private readonly IUriComposerService uriComposerService;

        public OrderService(IDatabaseContext Context,IMapper mapper, IUriComposerService uriComposerService)
        {
            this.Context = Context;
            this.mapper = mapper;
            this.uriComposerService = uriComposerService;
        }
        public int CreateOrder(int BasketId, int useraddressId, PaymentMethod paymentMethod)
        {
            var basket = Context.Baskets
                .Include(p => p.Items)
                .SingleOrDefault(p => p.Id == BasketId);

            int[] ids=basket.Items.Select(p=>p.CatalogItemId).ToArray();

            var catalogItems = Context.CatalogItems
                .Include(p=>p.CatalogItemImages)
                .Where(p => ids.Contains(p.Id));
            var orderItems = basket.Items.Select(basketItem =>
            {
                var catalogItem = catalogItems.First(c => c.Id == basketItem.CatalogItemId);
                var orderItem = new OrderItem(catalogItem.Id,catalogItem.Price,basketItem.Quantity, catalogItem.Name, uriComposerService.ComposeImageUri(catalogItem?.CatalogItemImages?.FirstOrDefault()?.Src??""));
                return orderItem;
            }).ToList();
            var userAddress=Context.UserAddresses.SingleOrDefault(p=>p.Id== useraddressId);
            var address=mapper.Map<Address>(userAddress);
            var order = new Order(int.Parse(basket.BuyerId), address, orderItems, paymentMethod);
            Context.Orders.Add(order);
            //بعد از اینکه خرید رو انجام داد، سبد خرید رو حذف میکنیم
            Context.Baskets.Remove(basket);
            Context.SaveChanges();
            return order.Id;
            
            
        }
    }
}
