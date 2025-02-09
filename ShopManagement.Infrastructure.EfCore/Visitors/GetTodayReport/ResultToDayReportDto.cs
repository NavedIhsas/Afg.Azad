﻿using System.Collections.Generic;

namespace ShopManagement.Infrastructure.EfCore.Visitors.GetTodayReport
{

    public class ResultToDayReportDto
    {
        public GeneralStatsDto GeneralStat { get; set; }
        public ToDayDto ToDay { get; set; }
        public List<VisitorsDto> Visitors { get; set; }

    }
}