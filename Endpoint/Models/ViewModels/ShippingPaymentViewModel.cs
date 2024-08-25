using Application.Dto;

namespace Endpoint.Models.ViewModels
{
    public class ShippingPaymentViewModel
    {
        public BasketDto Basket { get; set; }
        public List<UserAddressDto> UserAddress { get; set; }
    }
}
