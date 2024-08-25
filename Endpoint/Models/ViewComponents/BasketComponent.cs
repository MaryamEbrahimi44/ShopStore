using Application.Dto;
using Application.Interfaces;
using Endpoint.Utilitis;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Endpoint.Models.ViewComponents
{
    public class BasketComponent:ViewComponent
    {
        private readonly IBasketService basketService;
        public BasketComponent(IBasketService basketService)
        {
            this.basketService = basketService;
        }
        private ClaimsPrincipal userClaimsPrincipal => ViewContext?.HttpContext?.User;
        public IViewComponentResult Invoke()
        {
            BasketDto basket = null;
            if (User.Identity.IsAuthenticated)
            {
                basket = basketService.GetBasketForUser(ClaimUtility.GetUserId(userClaimsPrincipal));
            }
            else
            {
                string basketCookieName = "BasketId";
                if (Request.Cookies.ContainsKey(basketCookieName))
                {
                    var buyerId = Request.Cookies[basketCookieName];
                    basket = basketService.GetBasketForUser(buyerId);
                }

            }
            return View(viewName: "BasketComponent", model: basket);
        }
    }
}
