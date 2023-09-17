using System;
using System.Collections.Generic;
using Cookiesss.Itemsa;

namespace Cookiesss.Itemsa
{
    public class BillContainer
    { 
        public List<Bill> ListBill { get; set; }
        public string BillContainerId { get; set; }
        public double TotalRevenue { get; set; }
        public double TaxRevenue { get; set; }
        public double NetIncome { get; set; }

        public string Id { get; set; }
    }
}

