using Application.Interfaces;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class OrdersController : Controller
    {
                         
        private readonly ICustomerOrderService customerOrdersService;
        private readonly UserManager<User> userManager;

        public OrdersController(ICustomerOrderService customerOrdersService
            , UserManager<User> userManager)
        {
            this.customerOrdersService = customerOrdersService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(User).Result;
            var orders = customerOrdersService.GetMyOrder(user.Id);
            return View(orders);
        }
    }
}
