using System;
using System.Linq;
using ShopManagement.Domain.Visitors;

namespace ShopManagement.Infrastructure.EfCore.Visitors.SaveVisitorInfo
{

    public class SaveVisitorInfoService : ISaveVisitorInfoService
    {
        private readonly ShopContext _context;

        public SaveVisitorInfoService(ShopContext context)
        {
            _context = context;
        }

        public bool ExistRefreshPage(string currentLen, string referLink, string ip)
        {
            return _context.Visitors.Any(x =>
                x.ReferrerLink == referLink && x.CurrentLink == currentLen && x.Ip == ip &&
                x.Time > DateTime.Now.AddMinutes(-10));

        }

        public void Execute(RequestSaveVisitorInfoDto request)
        {
            var add = new Visitor()
            {
                Browser = new VisitorVersion()
                {
                    Family = request.Browser.Family,
                    Version = request.Browser.Version,
                },
                CurrentLink = request.CurrentLink,
                Device = new Device()
                {
                    Brand = request.Device.Brand,
                    Family = request.Device.Family,
                    IsSpider = request.Device.IsSpider,
                    Model = request.Device.Model,
                },
                Ip = request.Ip,
                Method = request.Method,
                OperationSystem = new VisitorVersion()
                {
                    Family = request.OperationSystem.Family,
                    Version = request.OperationSystem.Version,
                },
                PhysicalPath = request.PhysicalPath,
                Protocol = request.Protocol,
                ReferrerLink = request.ReferrerLink,
                VisitorId = request.VisitorId,
                Time = request.Time,
            };
            _context.Visitors.Add(add);
            _context.SaveChanges();
        }
    }
}