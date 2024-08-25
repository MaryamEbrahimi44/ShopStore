using Application.Dto;

namespace Application._services
{
    public partial class GetTodayReportService
    {
        public class ResultTodayReportDto
        {
            public GeneralStateDto GeneralState { get; set; }
            public TodayDto Today { get; set; }
            public List<VisitorsDto>  Visitors{ get; set; }


        }
    }
}
