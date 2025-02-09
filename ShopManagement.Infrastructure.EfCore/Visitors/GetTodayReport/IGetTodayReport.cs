﻿using System;

namespace ShopManagement.Infrastructure.EfCore.Visitors.GetTodayReport;

public interface IGetTodayReport
{
    ResultToDayReportDto Execute();

}

public class VisitorsDto
{
    public long Id { get; set; }
    public string Ip { get; set; }
    public string CurrentLink { get; set; }
    public string ReferrerLink { get; set; }
    public string Browser { get; set; }
    public string OperationSystem { get; set; }
    public bool IsSpider { get; set; }
    public DateTime Time { get; set; }
    public string VisitorId { get; set; }
}