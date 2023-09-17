using System;
using SerializeToFile.SerializeToFile;

public class Order
{
    public string SelectID;

    public List<Items> AddItem()
    {
        bool endText = false;
        Menu m1 = new Menu();
        List<Items> Orders = new List<Items>();
        var ItemsToCheck = m1.BuildMenu();
        do
        {
            Console.WriteLine("Please select the order id");
            var SelectID = Console.ReadLine();

            if (string.Equals("END", SelectID))
            {
                endText = true;
            }

            foreach (var ItemToCheck in ItemsToCheck)
            {
                if (string.Equals(ItemToCheck.Id, SelectID))
                {
                    Orders.Add(ItemToCheck);
                }
            }
        }
        while (endText == false);
        Console.WriteLine("SelectId is" + string.Equals("END", SelectID));
        string id = Guid.NewGuid().ToString("N");
        WriteBill(Orders, id);
        Bill bill1 = new Bill(Orders, id);
        BillContainer billContainer = new BillContainer(bill1);
        billContainer.AddBillContainer();
        return Orders;
    }


    public void WriteBill(List<Items> Orders, string id)
    {
        Bill bill1 = new Bill(Orders, id);
        string fileName = "WeatherForecast.json";
        string jsonString = JsonSerializer.Serialize(Orders);
        File.WriteAllText(fileName, jsonString);

        Console.WriteLine("Get Total" + bill1.GetTotal());
        Console.WriteLine("Get Tax" + bill1.TaxAmount());
    }

    public void PrintBill(List<Items> Orders)
    {
        PdfDocument document = new PdfDocument();

        PdfPage page = document.AddPage();

        XGraphics gfx = XGraphics.FromPdfPage(page);

        XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
        gfx.DrawString("My First PDF Document", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);
        foreach (var O in Orders)
        {
            gfx.DrawString("My First PDF Document", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);
        }
        string filename = "FirstPDFDocument.pdf";
        document.Save(filename);
        Process.Start(filename);
    }
}