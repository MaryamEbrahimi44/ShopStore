using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    [Auditable]
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }=DateTime.Now;
        public Address Address { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Order(int userId,Address address,List<OrderItem> orderItems,PaymentMethod paymentMethod )
        {
            UserId = userId;
            Address = address;
            PaymentMethod = paymentMethod;
            OrderItems = orderItems;
                
        }
        public Order()
        {
                
        }
        public int TotalPrice()
        {
            return OrderItems.Sum(p => p.UnitPrice * p.Units);
        }
        public void PaymentDone()
        {
            PaymentStatus=PaymentStatus.Paid;
        }
        public void OrderDelivered()
        {
            OrderStatus=OrderStatus.Delivered;
        }
        public void OrderReturned()
        {
            OrderStatus = OrderStatus.Returned;
        }
        public void OrderCancelled()
        {  
            OrderStatus = OrderStatus.Cancelled; 
        }

    }
    public class Address
    {
        public string State { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string PostalAddress { get; private set; }
        public int UserId { get; private set; }
        public string ReceiverName { get; private set; }
        public Address(string city, string state, string zipCode, string postalAddress, int userId, string receiverName)
        {
          
            State = state;
            City = city;
            ZipCode = zipCode;
            PostalAddress = postalAddress;
            UserId = userId;
            ReceiverName = receiverName;

        }

    }
    public enum PaymentMethod
    {
        OnlinePayment=0,
        PaymentOnTheSpot=1
    }
    public enum PaymentStatus
    {
        WaitingForPayment=0,
        Paid=1
    }
    public enum OrderStatus
    {
        Processing=0,
        Delivered=1,
        //مرجوعی
        Returned=2,
        Cancelled=3
    }
}
