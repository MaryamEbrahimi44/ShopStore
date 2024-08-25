using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application._services
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly IDatabaseContext context;

        public CustomerOrderService(IDatabaseContext context)
        {
            this.context = context;
        }

        public List<MyOrderDto> GetMyOrder(string userId)
        {


            var orders = context.Orders
                .Include(p => p.OrderItems)
                .Where(p => p.UserId == int.Parse(userId))
                .OrderByDescending(p => p.Id)
                .Select(p => new MyOrderDto
                {
                    Id = p.Id,
                    Date = context.Entry(p).Property("InsertTime").CurrentValue.ToString(),
                    OrderStatus = p.OrderStatus,
                    PaymentStatus = p.PaymentStatus,
                    Price = p.TotalPrice()

                }).ToList();
            return orders;
        }
    }
}