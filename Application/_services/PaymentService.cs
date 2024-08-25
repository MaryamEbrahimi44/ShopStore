using Application.Dto;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Payment;
using Microsoft.Extensions.Primitives;

namespace Application._services
{
    public class PaymentService : IPaymentService
    {
        private readonly IDatabaseContext context;
        private readonly IIdentityDatabaseContext identityContext;

        public PaymentService(IDatabaseContext context,IIdentityDatabaseContext identityContext)
        {
            this.context = context;
            this.identityContext = identityContext;
        }

        public PaymentDto GetPayment(Guid Id)
        {
            var payment=context.Payments
                .Include(p=>p.Order)
                .ThenInclude(p=>p.OrderItems)
                .SingleOrDefault(p=>p.Id == Id);


            var user = identityContext.Users.SingleOrDefault(p => p.Id ==payment.Order.UserId.ToString());


            string description=$"پرداخت سفارش شماره {payment.OrderId}"+Environment.NewLine;
            description += "محصولات" + Environment.NewLine;
            foreach(var item in payment.Order.OrderItems.Select(p => p.ProductName))
            {
                description += $"-{item}";
            }


            PaymentDto paymentDto = new PaymentDto()
            {
                Amount=payment.Order.TotalPrice(),
                Email=user.Email,
                PhoneNumber=user.PhoneNumber,
                UserId=user.Id,
                Id=payment.Id,
                Description=description
            };
            return paymentDto;
        }

        public PaymentOfOrderDto PaymentForOrder(int orderId)
        {
            var order=context.Orders
                .Include(p=>p.OrderItems)
                .SingleOrDefault(p=>p.Id == orderId);
            if (order == null)
                throw new Exception("error");
            var payment=context.Payments.SingleOrDefault(p=>p.OrderId == order.Id);
            if (payment == null)
            {
                payment = new Payment(order.TotalPrice (),order.Id);
                context.Payments.Add(payment);
                context.SaveChanges();  
            }
            return new PaymentOfOrderDto()
            {
                Amount = payment.Amount,
                PaymentId = payment.Id,
                PaymentMethod = order.PaymentMethod
            };

        }
       public bool VerifyPayment(Guid Id, string Authority, long RefId) 
        { 
            var payment=context.Payments
                .Include(p=>p.Id==Id)
                .SingleOrDefault(p=>p.Id==Id);

            if (payment == null)
            {
                throw new Exception("payment not found");
            }
            payment.Order.PaymentDone();
            payment.PaymentIsDone(Authority, RefId);
            context.SaveChanges();
            return true;

        }
    }
}
