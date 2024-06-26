using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShopManagement.Infrastructure.EfCore.Visitors.GetTodayReport
{
    public class GetTodayReport : IGetTodayReport
    {
        private readonly ShopContext _context;

        public GetTodayReport(ShopContext context)
        {
            _context = context;
        }

        public ResultToDayReportDto Execute()
        {
            var start = DateTime.Now.Date;
            var end = DateTime.Now.AddDays(1);

            var todayPageViewsCount = _context.Visitors.AsQueryable()
                .Where(x => x.Time >= start && x.Time < end)
                .LongCount();

            var todayVisitorPageCount = _context.Visitors.AsQueryable()
                .Where(x => x.Time >= start && x.Time < end)
                .GroupBy(x => x.VisitorId).LongCount();

            var pageViewsCount = _context.Visitors.AsQueryable().LongCount();
            var visitorPageCount = _context.Visitors.AsQueryable().GroupBy(x => x.VisitorId).LongCount();

            var todayPageViewsList = _context.Visitors.AsQueryable().Where(x => x.Time >= start && x.Time < end)
                .Select(x => new { x.Time }).ToList();


            var visitors = _context.Visitors.AsQueryable()
                .OrderByDescending(x => x.Time)
                .Select(x => new VisitorsDto()
                {
                    Id = x.Id,
                    Time = x.Time,
                    Browser = x.Browser.Family,
                    CurrentLink = x.CurrentLink,
                    OperationSystem = x.OperationSystem.Family,
                    VisitorId = x.VisitorId,
                    Ip = x.Ip,
                    IsSpider = x.Device.IsSpider,
                    ReferrerLink = x.ReferrerLink,
                }).AsNoTracking().ToList();


            var visitPerHours = new VisitCountDto()
            {
                Display = new string[24],
                Value = new int[24],
            };
            for (var i = 0; i <= 23; i++)
            {
                visitPerHours.Display[i] = $"{i}-h";
                visitPerHours.Value[i] = todayPageViewsList.Count(x => x.Time.Hour == i);
            }


            var startMount = DateTime.Now.AddDays(-30);
            var endMount = DateTime.Now.AddDays(1);

            var mountPageViewsList = _context.Visitors.AsQueryable()
                .Where(x => x.Time >= startMount && x.Time < endMount)
                .Select(x => new { x.Time }).AsNoTracking().ToList();

            var visitPerDay = new VisitCountDto()
            {
                Display = new string[31],
                Value = new int[31],
            };

            for (int i = 0; i <= 30; i++)
            {
                var currentDay = DateTime.Now.AddDays(i * -1);
                visitPerDay.Display[i] = i.ToString();
                visitPerDay.Value[i] = mountPageViewsList.Count(x => x.Time.Date == currentDay.Date);
            }

            var result = new ResultToDayReportDto()
            {
                GeneralStat = new GeneralStatsDto()
                {
                    TotalPageViews = pageViewsCount,
                    TotalVisitors = visitorPageCount,
                    PageViewsPerVisit = GetAvg(pageViewsCount, visitorPageCount),
                    VisitPerDay = visitPerDay,
                },
                ToDay = new ToDayDto()
                {
                    Visitors = todayVisitorPageCount,
                    PageViews = todayPageViewsCount,
                    PageViewsPerVisit = GetAvg(todayPageViewsCount, todayVisitorPageCount),
                    Visitor = visitPerHours,
                },
                Visitors = visitors,
            };
            return result;
        }

        private static float GetAvg(long visitPage, long visitor)
        {
            if (visitor == 0) return 0;
            else return visitPage / visitor;
        }
    }
}
