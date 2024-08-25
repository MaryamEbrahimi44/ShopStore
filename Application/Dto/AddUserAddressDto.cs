using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class AddUserAddressDto
    {
        public string City { get; set; }
        public int UserId { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PostalAddress { get; set; }
        public string ReceiverName { get; set; }
    }
}
