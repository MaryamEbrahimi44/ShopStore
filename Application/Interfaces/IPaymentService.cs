using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPaymentService
    {
        PaymentOfOrderDto PaymentForOrder(int orderId);
        PaymentDto GetPayment(Guid Id);
        bool VerifyPayment(Guid Id, string Authority,long RefId);

    }
}
