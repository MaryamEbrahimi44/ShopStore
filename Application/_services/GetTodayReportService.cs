using Application.Dto;
using Application.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application._services
{
    public partial class GetTodayReportService: IGetTodayReportService
    {
        
            private readonly IMongoDbContext<Domain.Visitors.Visitor> _mongoDbContext;
            private readonly IMongoCollection<Domain.Visitors.Visitor> visitorMongoCollection;
            public GetTodayReportService(IMongoDbContext<Domain.Visitors.Visitor> mongoDbContext)
            {
                _mongoDbContext = mongoDbContext;
                visitorMongoCollection = _mongoDbContext.GetCollection();
            }
            public ResultTodayReportDto Execute()
        {
            DateTime start = DateTime.Now.Date;
            DateTime end = DateTime.Now.AddDays(1);

            var TodayPageViewCount = visitorMongoCollection.AsQueryable()
                .Where(p => p.Time >= start && p.Time <= end).LongCount();
            var TodayVisitorCount = visitorMongoCollection.AsQueryable()
                .Where(p => p.Time >= start && p.Time <= end).GroupBy(p => p.VisitorId).LongCount();
            var AllPageViewCount = visitorMongoCollection.AsQueryable().LongCount();
            var AllVisitorCount = visitorMongoCollection.AsQueryable().GroupBy(p => p.VisitorId).LongCount();
            //نمودار روزانه
            VisitCountDto VisitPerHour = GetVisitorPerHour(start, end);
            //نمودار ماهانه
            VisitCountDto VisitPerDay = GetVisitorPerDay();
            //لیست ازدید کنندگان
            var Visitors=visitorMongoCollection.AsQueryable()
                .OrderByDescending(p => p.Time)
                .Take(10)
                .Select(p=> new VisitorsDto
                {
                    Id = p.Id,
                    Browser = p.Browser,
                    CurrentLink = p.CurrentLink,
                    Ip = p.Ip,
                    OperationSystem = p.OperationSystem,
                    IsSpider=p.Device.IsSpider,
                    RefferLink= p.RefferLink,
                    Time= p.Time
                })
                .ToList();
            return new ResultTodayReportDto
            {
                Visitors=Visitors,
                GeneralState = new GeneralStateDto
                {
                    TotalVisitors = AllVisitorCount,

                    TotalPageViews = AllPageViewCount,
                    PageViewsPerVisit = GetAvg(AllPageViewCount, AllVisitorCount),
                    VisitPerDay = VisitPerDay,
                },
                Today = new TodayDto
                {
                    PageViews = AllPageViewCount,
                    Visitors = TodayVisitorCount,
                    ViewsPerVisitor = GetAvg(TodayPageViewCount, TodayVisitorCount),
                    VisitPerHour = VisitPerHour
                }

            };

            VisitCountDto GetVisitorPerDay()
            {
                DateTime MonthStart = DateTime.Now.Date.AddDays(-30);
                DateTime MonthEnd = DateTime.Now.Date.AddDays(1);
                var month_pageVieList = visitorMongoCollection.AsQueryable()
                    .Where(p => p.Time >= MonthStart && p.Time <= MonthEnd)
                    .Select(p => new { p.Time }).ToList();
                VisitCountDto VisitPerDay = new VisitCountDto()
                {
                    Display = new string[31],
                    Value = new int[31]
                };
                for (int i = 0; i <= 30; i++)
                {
                    var currentDay = DateTime.Now.AddDays(i * (-1));
                    VisitPerDay.Display[i] = i.ToString();
                    VisitPerDay.Value[i] = month_pageVieList.Where(p => p.Time.Date == currentDay.Date).Count();

                }

                return VisitPerDay;
            }

            VisitCountDto GetVisitorPerHour(DateTime start, DateTime end)
            {
                var TodayPageViewList = visitorMongoCollection.AsQueryable().Where(
                    p => p.Time >= start && p.Time <= end)
                    .Select(p => new { p.Time }).ToList();
                VisitCountDto VisitPerHour = new VisitCountDto()
                {
                    Display = new string[24],
                    Value = new int[24]
                };
                for (int i = 0; i <= 23; i++)
                {
                    VisitPerHour.Display[i] = $" {i}";
                    VisitPerHour.Value[i] = TodayPageViewList.Where(p => p.Time.Hour == i).Count();

                }

                return VisitPerHour;
            }
        }
        private float GetAvg(long VisitPage, long Visitor)
        {
            if (Visitor == 0)
            {
                return 0;
            }
            else
            {
                return VisitPage / Visitor;
            }
        }
    }
}
