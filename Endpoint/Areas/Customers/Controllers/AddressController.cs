using Application.Dto;
using Application.Interfaces;
using Endpoint.Utilitis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class AddressController : Controller
    {
        private readonly IUserAddressService userAddressService;

        public AddressController(IUserAddressService userAddressService)
        {
            this.userAddressService = userAddressService;
        }
        public IActionResult Index()
        {
            var address = userAddressService.GetAddress(int.Parse(ClaimUtility.GetUserId(User)));
            return View(address);
        }
        [HttpGet]
        public IActionResult AddNewAddress()
        {
            return View(new AddUserAddressDto());
        }
        [HttpPost]
        public IActionResult AddNewAddress(AddUserAddressDto address)
        {
            int userId=int.Parse(ClaimUtility.GetUserId(User));
            address.UserId = userId;
            userAddressService.AddNewAddress(address);
            return RedirectToAction(nameof(Index));
            
        }
    }
}
