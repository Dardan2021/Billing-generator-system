using System;
using SerializeToFile.SerializeToFile;

public class Bill
{
    public List<Items> Items;
    public string Id;

    public Bill(List<Items> items, string id)
    {
        Items = items;
        Id = id;
    }
    public int TaxAmount()
    {
        var total = GetTotal();
        return total / 5;
    }
    public int GetTotal()
    {
        int total = 0;
        foreach (var i in Items)
        {
            total = total + i.Price;
        }
        return total;
    }
}