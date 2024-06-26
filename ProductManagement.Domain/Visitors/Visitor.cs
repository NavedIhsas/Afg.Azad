using System;

namespace ShopManagement.Domain.Visitors
{
    public class Visitor
    {

        public long Id { get; set; }
        public string Ip { get; set; }
        public string CurrentLink { get; set; }
        public string ReferrerLink { get; set; }
        public string Method { get; set; }
        public string Protocol { get; set; }
        public string PhysicalPath { get; set; }

        public DateTime Time { get; set; }
        public string VisitorId { get; set; }
        public VisitorVersion Browser { get; set; }
        public VisitorVersion OperationSystem { get; set; }
        public Device Device { get; set; }
    }
}
