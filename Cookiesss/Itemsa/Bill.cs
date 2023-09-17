using System;


namespace Cookiesss.Itemsa
{   public class Bill
    {
        public List<Items> Items { get; set; }
        public string Id { get; set; }
        public double Total { get; set; }
        public double Tax { get; set; }
    }
}

