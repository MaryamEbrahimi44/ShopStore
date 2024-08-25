using Application.Dto;

namespace Application._services
{
    public partial class GetTodayReportService
    {
        public class TodayDto
        {
            public long PageViews { get; set; }
            public long Visitors { get; set; }
            public float ViewsPerVisitor { get; set; }
            public VisitCountDto   VisitPerHour { get; set; }

        }
    }
}
