// See https://aka.ms/new-console-template for more information
using Cookiesss.Itemsa;

namespace Cookiesss
{   
    public class Program
    {
        public static void Main()
        {
            Menu m1 = new Menu();
            FrontEnd F1 = new FrontEnd();
            m1.ShowMenu();
            F1.AddItem();
            Console.ReadKey();
        }
    }
}