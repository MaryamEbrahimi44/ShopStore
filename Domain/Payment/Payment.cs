using Domain.Attributes;
using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Payment
{
    [Auditable]
    public class Payment
    {
        public Guid Id { get; set; }
        public int Amount {  get;private set; }
        public bool IsPay { get; private set; } = false;
        public DateTime? DatePay { get; private set; } = null;
        //این دوتا از سمت درگاه برگشت داده میشن
        public string  Authority { get; private set; }
        public long RefId { get; private set; } = 0;
        //اگه خواستیم کیف پول بذاریم تو برناممون،order  رو nullable  میکنیم
        public Order Order { get; private set; }
        public int OrderId { get; private set; }
        public Payment(int amount, int orderId)
        {
                Amount= amount;
            OrderId= orderId;
        }
        public void PaymentIsDone(string authority,long refId)
        {
            IsPay = true;
            DatePay = DateTime.Now;
            Authority = authority;
            RefId = refId;
        }
    }
}
