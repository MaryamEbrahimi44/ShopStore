using Application._services;
using Application.Dto;
using Application.Interfaces;
using Domain.Orders;
using Domain.Users;
using Endpoint.Models.ViewModels;
using Endpoint.Utilitis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {

        private readonly IBasketService basketService;
        private readonly SignInManager<User> signInManager;
        private readonly IUserAddressService userAddressService;
        private readonly IOrderService orderService;
        private readonly IPaymentService paymentService;
        private string userId = null;
        public BasketController(IBasketService basketService
            , SignInManager<User> signInManager
            , IUserAddressService userAddressService
            ,IOrderService orderService
            ,IPaymentService paymentService)
        {
            this.basketService = basketService;
            this.signInManager = signInManager;
            this.userAddressService = userAddressService;
            this.orderService = orderService;
            this.paymentService = paymentService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var data = GetOrSetBasket();
            return View(data);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(int CatalogitemId, int quantity = 1)
        {
            var basket = GetOrSetBasket();
            basketService.AddItemToBasket(basket.Id, CatalogitemId, quantity);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult RemoveItemFromBasket(int ItemId)
        {
            basketService.RemoveItemFromBasket(ItemId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult setQuantity(int basketItemId, int quantity)
        {
            return Json(basketService.SetQuantities(basketItemId, quantity));
        }


        private BasketDto GetOrSetBasket()
        {
            if (signInManager.IsSignedIn(User))
            {
                return basketService.GetOrCreateBasketForUser(User.Identity.Name);
            }
            else
            {
                SetCookiesForBasket();
                return basketService.GetOrCreateBasketForUser(userId);
            }
        }

        private void SetCookiesForBasket()
        {
            string basketCookieName = "BasketId";
            if (Request.Cookies.ContainsKey(basketCookieName))
            {
                userId = Request.Cookies[basketCookieName];
            }
            if (userId != null) return;
            userId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true };
            cookieOptions.Expires = DateTime.Today.AddYears(2);
            Response.Cookies.Append(basketCookieName, userId, cookieOptions);


        }
        public IActionResult ShippingPayment()
        {
            ShippingPaymentViewModel model = new ShippingPaymentViewModel();
            string userId = ClaimUtility.GetUserId(User);
            model.Basket = basketService.GetBasketForUser(userId);
            model.UserAddress = userAddressService.GetAddress(int.Parse(userId));

            return View(model);
        }
        [HttpPost]
        public IActionResult ShippingPayment(int Address, PaymentMethod PaymentMethod)
        {
            string userId = ClaimUtility.GetUserId(User);
            var basket = basketService.GetBasketForUser(userId);
            int orderId=orderService.CreateOrder(basket.Id,Address,PaymentMethod);
            if (PaymentMethod == PaymentMethod.OnlinePayment)
            {
                //ثبت پرداخت

                var payment=paymentService.PaymentForOrder(orderId);

                //ارسال به درگاه پرداخت


                return RedirectToAction("Index", "Pay", new {PaymentId=payment.PaymentId});
            }
            else
            
            {
                return RedirectToAction("Index", "Orders", new { area = "customers" });
            }

        }
        public IActionResult checkout() 
        {
            return View();
        }
    }
}
