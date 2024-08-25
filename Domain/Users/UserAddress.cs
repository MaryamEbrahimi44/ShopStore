using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    [Auditable]
    public class UserAddress
    {
        public int Id { get;private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string PostalAddress { get; private set; }
        public int UserId { get; private set; }
        public string ReceiverName { get; private set; }
        public UserAddress(string city,int id, string state,string zipCode,string postalAddress,int userId, string receiverName)
        {
            Id = id;
            City= city;
            State = state;
            ZipCode = zipCode;
            PostalAddress = postalAddress;
            UserId = userId;
            ReceiverName = receiverName;

        }
        public UserAddress()
        {
                
        }

    }
}
