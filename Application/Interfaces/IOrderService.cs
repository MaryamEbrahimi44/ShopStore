using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        int CreateOrder(int BankId, int useraddressId, PaymentMethod paymentMethod);
    }
}
