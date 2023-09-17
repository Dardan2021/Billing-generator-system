using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookiesss.Itemsa
{
    public class FrontEnd
    {
        const string fileName = "C:/Users/dama12/source/repos/Cookiesss/Cookiesss/filesBillContainer.json";
        OrderForGoogleStores o1 = new OrderForGoogleStores();
          Calculations calculations = new Calculations();
        public void AddItem()
        {
            bool endText = false;
            Menu m1 = new Menu();
            List<Items> Orders = new List<Items>();
            var ItemsToCheck = m1.BuildMenu();
            Console.WriteLine("Please Select Command");
            var command = Console.ReadLine();
            if (string.Equals("Select Items", command))
            {
                do
                {
                    Console.WriteLine("Please Select Item Id");
                    var SelectID = Console.ReadLine();
                    
                  
                    if (string.Equals("END", SelectID))
                    {
                        endText = true;
                    }
                    else
                    {
                        Console.WriteLine("Please Select Quantity");

                        string quantity = Console.ReadLine();
                   

                        foreach (var ItemToCheck in ItemsToCheck)
                        {
                            if (string.Equals(ItemToCheck.Id, SelectID))
                            {
                                Items items = new Items
                                {
                                    Id = ItemToCheck.Id,
                                    Definition = ItemToCheck.Definition,
                                    Price = ItemToCheck.Price,
                                    Quantity = int.Parse(quantity)
                                };
                          
                                Orders.Add(items);
                            }
                        }
                       }
                }
                while (endText == false);

                string id = Guid.NewGuid().ToString("N");
               
                WriteBillList(Orders, id, fileName);

                AddItem();
            }
            else if (string.Equals("Print Bill By Id", command))
            {
                Console.WriteLine("Please Select Bill Id You want to print ");
                string command1 = Console.ReadLine();
                PrintBill.PrintSingleBill(o1.FileList(fileName), command1);
                AddItem();
            }
            else if (string.Equals("Print Report", command))
            {
                Console.WriteLine("Please Select Bill Container Id You want to print ");
                string command2 = Console.ReadLine();
                var ListBillContainers = o1.ListBillContainer(fileName);
                PrintBill.PrintRevenue(ListBillContainers, command2);
                AddItem();
            }

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

            var lists = o1.FileList(fileName);
            o1.UpdateBill(NewBill, fileName, lists);
        }
    }
}
