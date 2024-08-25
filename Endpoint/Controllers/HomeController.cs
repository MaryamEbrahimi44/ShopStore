using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Endpoint.Models;
using Website.Endpoint2.Utilitis.Filters;
using Application.Interfaces;

namespace Endpoint.Controllers
{
    [ServiceFilter(typeof(SaveVisitorFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomePageService homePageService;

        public HomeController(ILogger<HomeController> logger, IHomePageService homePageService)
        {
            _logger = logger;
            this.homePageService = homePageService;
        }

        public IActionResult Index()
        {
            var data = homePageService.GetData();
            return View(data);
        }
        public IActionResult Register()
        {
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
