using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookiesss.Itemsa
{
    public  class Calculations
    {
        public double GetBillTotal(List<Items> items)
        {
            double total = 0;
            foreach (var item in items)
            {
                total = total + (item.Price*item.Quantity);
            }
            return total;
        }
        public double GetBillTax(double total)
        {
            return total / 4;
        }
        public double GetBillsTotalRevenue(List<Bill> bills)
        {
            double revenue = 0;

            foreach (var billC in bills)
            {
                revenue = revenue + billC.Total;
            }
            return revenue;
        }
        public double GetBillsTotalNetIncome(List<Bill> bills)
        {
            double netIncome = 0;
            double revenue = GetBillsTotalRevenue(bills);
            double tax = GetBillsTotalTax(bills);
            netIncome = revenue - tax;
            return netIncome;
        }
        public double GetBillsTotalTax(List<Bill> bills)
        {
            double tax = 0;

            foreach (var billC in bills)
            {
                tax = tax + billC.Tax;
            }
            return tax;
        }
    }
}
