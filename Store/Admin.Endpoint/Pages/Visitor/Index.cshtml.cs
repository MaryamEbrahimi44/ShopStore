using Application.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Application._services.GetTodayReportService;

namespace Admin.Endpoint.Pages.Visitor
{
    public class IndexModel : PageModel
    {
        private readonly IGetTodayReportService _getTodayReportService;
        public ResultTodayReportDto ResultTodayReport;
        public IndexModel(IGetTodayReportService getTodayReportService)
        {
                _getTodayReportService = getTodayReportService;
        }
        public void OnGet()
        {
            ResultTodayReport = _getTodayReportService.Execute();



        }
    }
}
