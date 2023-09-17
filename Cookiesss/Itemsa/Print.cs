using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Cookiesss.Itemsa
{
    public class PrintBill
    {
        public static void DrawLine(int y)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();

            y = y + 30;
        }

        public static void PrintSingleBill(List<Bill> listBill, string id)
        {
            GetEncoding();
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 10, XFontStyle.Regular);
            XFont fontBold = new XFont("Verdana", 10, XFontStyle.Bold);
            XPen lineRed = new XPen(XColors.Black, 1);
            var brush = new XSolidBrush(XColor.FromArgb(255, 222, 222, 222));
            int y = 0;
          
            foreach (var item in listBill)
            {
                XRect snoColumnVal2 = new XRect(10, y, 150, 100);
                XRect snoStudentNameVal12 = new XRect(150, y, 150, 100);
                XRect snoStudentQuantity2 = new XRect(300, y, 150, 100);
                gfx.DrawString("Quantity", font, XBrushes.Black, snoStudentQuantity2, XStringFormats.CenterLeft);
                gfx.DrawString("Definition", font, XBrushes.Black, snoColumnVal2, XStringFormats.CenterLeft);
                gfx.DrawString("Price", font, XBrushes.Black, snoStudentNameVal12, XStringFormats.CenterLeft);
                if (string.Equals(item.Id, id))
                { 
                    foreach (var item2 in item.Items)
                    {
                        y = y + 30;
                        XRect snoColumnVal = new XRect(10, y, 150, 100);
                        XRect snoStudentNameVal = new XRect(150, y, 150, 100);
                        XRect snoStudentQuantity = new XRect(300, y, 150, 100);

                        gfx.DrawString(item2.Quantity.ToString(), font, XBrushes.Black, snoStudentQuantity, XStringFormats.CenterLeft);
                        gfx.DrawString(item2.Price.ToString() + "$", font, XBrushes.Black, snoStudentNameVal, XStringFormats.CenterLeft);
                        gfx.DrawString(item2.Definition, font, XBrushes.Black, snoColumnVal, XStringFormats.CenterLeft);
                        gfx.DrawLine(lineRed, 0, y+60, page.Width, y + 60);
                    }
                    y = y + 30;
                    XRect snoColumnVal1 = new XRect(10, y, 150, 100);
                    XRect snoStudentNameVal1 = new XRect(150, y, 150, 100);
                    page.Width = XUnit.FromMillimeter(210);
                    page.Height = XUnit.FromMillimeter(297);

                    gfx.DrawLine(lineRed, 0, y + 60, page.Width, y + 60);
                    gfx.DrawString("Tax: " + item.Tax.ToString() + "$", fontBold, XBrushes.Black, snoColumnVal1, XStringFormats.CenterLeft);
                    gfx.DrawString("Total: " + item.Total.ToString() + "$", fontBold, XBrushes.Black, snoStudentNameVal1, XStringFormats.CenterLeft);
                    
                    string filename = "C:/Users/dama12/source/repos/Cookiesss/Cookiesss/files/FirstPDFDocument" + id + ".pdf";
                    document.Save(filename);
                    var p = new Process();
                    p.StartInfo = new ProcessStartInfo(filename)
                    {
                        UseShellExecute = true
                    };
                    p.Start();
                    continue;
                }
              
            }

           
        }
        public static void PrintRevenue(List<BillContainer> billContainer, string billContainerId)
        {

            GetEncoding();
            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();
            XPen lineRed = new XPen(XColors.Black, 1);
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 10, XFontStyle.Regular);
            XFont fontBold = new XFont("Verdana", 10, XFontStyle.Bold);

            var brush = new XSolidBrush(XColor.FromArgb(255, 222, 222, 222));
            int y = 0;
            XRect snoColumnVal = new XRect(10, y, 150, 100);
            XRect snoStudentNameVal = new XRect(150, y, 150, 100);
            XRect snoStudentQuantity = new XRect(300, y, 150, 100);
            gfx.DrawString("Quantity", font, XBrushes.Black, snoStudentQuantity, XStringFormats.CenterLeft);
            gfx.DrawString("Definition", font, XBrushes.Black, snoColumnVal, XStringFormats.CenterLeft);
            gfx.DrawString("Price", font, XBrushes.Black, snoStudentNameVal, XStringFormats.CenterLeft);
            foreach (var it in billContainer)
            {
                
                if (string.Equals(it.BillContainerId, billContainerId))
                {
                    foreach (var item in it.ListBill)
                    {
                        foreach (var item2 in item.Items)
                        {
                            y = y + 30;
                            XRect snoColumnVal2 = new XRect(10, y, 150, 100);
                            XRect snoStudentNameVal2 = new XRect(150, y, 150, 100);
                            XRect snoStudentQuantity2 = new XRect(300, y, 150, 100);

                            gfx.DrawString(item2.Quantity.ToString(), font, XBrushes.Black, snoStudentQuantity2, XStringFormats.CenterLeft);
                            gfx.DrawString(item2.Price.ToString() + "$", font, XBrushes.Black, snoStudentNameVal2, XStringFormats.CenterLeft);
                            gfx.DrawString(item2.Definition, font, XBrushes.Black, snoColumnVal2 , XStringFormats.CenterLeft);
                            page.Width = XUnit.FromMillimeter(210);
                            page.Height = XUnit.FromMillimeter(297);
                            gfx.DrawLine(lineRed, 0, y+60, page.Width, y + 60);
                        }
                        y = y + 30;
                        XRect snoColumnVal1 = new XRect(10, y, 150, 100);
                        XRect snoStudentNameVal1 = new XRect(150, y, 150, 100);
                        
                        gfx.DrawString("Tax: " + item.Tax.ToString(), fontBold, XBrushes.Black, snoColumnVal1, XStringFormats.CenterLeft);
                        gfx.DrawString("Total: " + item.Total.ToString() + "$", fontBold, XBrushes.Black, snoStudentNameVal1, XStringFormats.CenterLeft);
                        gfx.DrawLine(lineRed, 0, y + 60, page.Width, y + 60);
                        continue;
                    }

                }
                y = y + 30;
                XRect total = new XRect(10, y, 150, 100);
                XRect tax = new XRect(10, y + 20, 150, 100);
                XRect net = new XRect(10, y + 40, 150, 100);
               
                gfx.DrawString("Total Revenue: " + it.TotalRevenue + "$", font, XBrushes.Black, total, XStringFormats.CenterLeft);
                gfx.DrawString("Tax Revenue: " + it.TaxRevenue + "$", font, XBrushes.Black, tax, XStringFormats.CenterLeft);
                gfx.DrawString("Net Income: " + it.NetIncome + "$", font, XBrushes.Black, net, XStringFormats.CenterLeft);
                gfx.DrawLine(lineRed, 0, y + 100, page.Width, y + 100);
                continue;
            }
            string filename = "C:/Users/dama12/source/repos/Cookiesss/Cookiesss/files/Revenue" + billContainerId + ".pdf";
            document.Save(filename);
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(filename)
            {
                UseShellExecute = true
            };
            p.Start();
        }
        public static void GetEncoding()
        {
            var enc = CodePagesEncodingProvider.Instance.GetEncoding(1252);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
    
    }


}

