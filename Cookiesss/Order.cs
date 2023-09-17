using System;



using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using PdfSharp.Pdf.Content.Objects;
using System.Data;
using System.Text;
using PdfSharp.Drawing.Layout;
using System.Drawing;

namespace Cookiesss.Itemsa
{
    public class OrderForGoogleStores : FileOperations
    {
        public string SelectID;
        const string FileName = "C:/Users/dama12/source/repos/Cookiesss/Cookiesss/filesBillContainer.json";
        Calculations calculations = new Calculations();


        public void AddBillContainer(List<BillContainer> billContainers)
        {
            foreach(var BillContainer in billContainers)
            {
                foreach(var c in BillContainer.ListBill)
                {
                   Console.WriteLine(c.Id);
                }
            }
            EnterpriseBills EnterpriseBills = new EnterpriseBills
            {
                ListBillContainer = billContainers,
            };

            string jsonString = JsonSerializer.Serialize(EnterpriseBills);
            File.WriteAllText(FileName, jsonString);
        }
        public void UpdateBill(Bill NewBill, string fileName, List<Bill> ListBills)
        {

            ListBills.Add(NewBill);
            string id = "1111adasdadasdasaadas";
            double totalRevenue = calculations.GetBillsTotalRevenue(ListBills);
            double taxRevenue = calculations.GetBillsTotalTax(ListBills);
            double netIncome = calculations.GetBillsTotalNetIncome(ListBills);
            BillContainer billContainer = new BillContainer
            {
                ListBill = ListBills,
                BillContainerId = id,
                TotalRevenue = totalRevenue,
                TaxRevenue = taxRevenue,
                NetIncome = netIncome
            };

            List<BillContainer> ListBillContainer = new List<BillContainer>();
            ListBillContainer.Add(billContainer);
            AddBillContainer(ListBillContainer);
        }
        public EnterpriseBills Deserilization(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            EnterpriseBills enterpriseBills = JsonSerializer.Deserialize<EnterpriseBills>(jsonString);
            return enterpriseBills;
        }


        public List<Bill> FileList(string fileName)
        {
            List<Bill> ListBills = new List<Bill>();
            if (File.Exists(fileName))
            {
                var billContainer = Deserilization(fileName);
                foreach (var bill in billContainer.ListBillContainer)
                {
                    foreach (var b in bill.ListBill)
                    {
                        ListBills.Add(b);
                    }
                }
            }
            return ListBills;
        }
        public List<BillContainer> ListBillContainer(string fileName)
        {
            List <BillContainer> ListBills = new List<BillContainer>();
            if (File.Exists(fileName))
            {
                var billContainer = Deserilization(fileName);
                foreach (var bill in billContainer.ListBillContainer)
                {
                    ListBills.Add(bill);
                }
            }
            return ListBills;
        }
        public void WriteBillList(List<Items> items, string id, string fileName)
        {
            double total = calculations.GetBillTotal(items);
            double tax = calculations.GetBillTax(total);
            Bill NewBill = new Bill
            {
                Items = items,
                Id = id,
                Total = total,
                Tax = tax,
            };

            var lists = FileList(fileName);
            UpdateBill(NewBill, fileName, lists);
        }

    }
}



/* public void ShowOrder()
        {
            string fileName = "BillContainer.json";
            if(File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                BillContainer  billContainer = JsonSerializer.Deserialize<BillContainer>(jsonString)!;

                Console.WriteLine("//////////////////////////////////");
                foreach (var bill in billContainer.Bill)
                {
                    Console.WriteLine($"Bill Id is: {bill.Id}");
                    foreach(var item in bill.Items)
                    {
                        Console.WriteLine($"Id is: {item.Id}");
                        Console.WriteLine($"Definition is: {item.Definition}");
                        Console.WriteLine($"Pride is: {item.Price}");
                    }
                }
                Console.WriteLine("//////////////////////////////////");
            }
        }*/
