using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorksSales.Web.Models
{
    public class SalesSummary
    {
        public double TotalOrders { get; set; }
        public decimal HighestLineTotal { get; set; }
        public decimal FrontBrakesTotal { get; set; }

    }
}