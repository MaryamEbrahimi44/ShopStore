using Application._services;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.Models.ViewComponents
{
    public class GetMenueCategories:ViewComponent
    {
        private readonly IGetMenueItemService getMenueItemService;

        public GetMenueCategories(IGetMenueItemService getMenueItemService)
        {
            this.getMenueItemService = getMenueItemService;
        }
        public IViewComponentResult Invoke()
        {
            var data = getMenueItemService.Execute();
            return View(viewName: "GetMenueCategories", model: data);
        }
    }
}
