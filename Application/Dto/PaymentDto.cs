using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class PaymentDto
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
      
    }
}
