using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application._services.GetTodayReportService;

namespace Application.Interfaces
{
    public interface IGetTodayReportService
    {
        ResultTodayReportDto Execute();
    }
}
