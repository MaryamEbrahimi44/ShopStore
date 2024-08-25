using Application.Dto;

namespace Application._services
{
    public partial class GetTodayReportService
    {
        public class GeneralStateDto
        {
            public long TotalPageViews { get; set; }
            public long TotalVisitors { get; set; }
            public float PageViewsPerVisit { get; set; }
            public VisitCountDto VisitPerDay { get; set; }
        }
    }
}
