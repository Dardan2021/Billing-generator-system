using System;

namespace Cookiesss.Itemsa
{
    public  interface FileOperations
    {
        public EnterpriseBills Deserilization(string fileName);
        public void WriteBillList(List<Items> tems, string id, string fileName);
        public List<Bill> FileList(string fileName);
        public void UpdateBill(Bill NewBill, string fileName, List<Bill> ListBills);
        public void AddBillContainer(List<BillContainer> billContainer);
     
    }
}
