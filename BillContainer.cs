using System;
using SerializeToFile.SerializeToFile;



public class BillContainer
{
    public double TotalRevenue;
    public List<Bill> Bills;
    public Bill Bil;
    public BillContainer(Bill b)
    {
        Bil = b;
    }

    public void AddBillContainer()
    {
        // string Billcontainer = JsonSerializer.Serialize(Bil);
        Console.WriteLine(Bil);
        Bills.Add(Bil);


        foreach (var b in Bil.Items)
        {
            Console.WriteLine(b.Id + "-" + b.Definition + "-" + b.Price);
        }
    }
}
