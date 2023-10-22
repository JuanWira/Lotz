using Lotz_PSD_LEC_AoL.Controller;
using Lotz_PSD_LEC_AoL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lotz_PSD_LEC_AoL.Views
{
    public partial class HistoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCardItems();
        }

        private void BindCardItems()
        {
            Customer cust = (Customer)Session["customer"];
            int cID = cust.CustomerID;
            List<TransactionHeader> cardItems = TransactionController.GetTransactionByCustomer(cID);
            List<displayCard> cardList = new List<displayCard>();

            foreach (TransactionHeader displayCard in cardItems)
            {
                displayCard testItem = new displayCard();

                testItem.TransactionID = displayCard.TransactionID;
                testItem.ClothName = GetClothName(displayCard.TransactionID, cID);
                testItem.ClothImage = GetClothImg(displayCard.TransactionID, cID);
                testItem.ClothPrice = GetClothPrice(displayCard.TransactionID, cID);
                testItem.ClothQty = GetCartQty(displayCard.TransactionID, cID);
                testItem.ClothSize = GetClothSize(displayCard.TransactionID, cID);
                testItem.PaymentType = GetClothPayment(displayCard.TransactionID, cID);
                testItem.Date = GetDate(displayCard.TransactionID, cID);
                cardList.Add(testItem);
            }
            cardRepeater.DataSource = cardList;
            cardRepeater.DataBind();
        }

        public class displayCard
        {
            public int TransactionID { get; set; }
            public int CustID { get; set; }
            public int ClothID { get; set; }
            public string ClothName { get; set; }
            public int ClothQty { get; set; }
            public int ClothPrice { get; set; }
            public string ClothSize { get; set; }
            public string Date { get; set; }
            public string ClothImage { get; set; }
            public string PaymentType { get; set; }
        }

        private int GetClothID(int thID, int custID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from th in db.TransactionHeaders
                        join s in db.Customers on th.CustomerID equals s.CustomerID
                        where th.TransactionID == thID && s.CustomerID == custID
                        select th.ClothID).FirstOrDefault();
            }
        }
        private int GetCustID(int thID, int custID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from th in db.TransactionHeaders
                        join s in db.Customers on th.CustomerID equals s.CustomerID
                        where th.TransactionID == thID && s.CustomerID == custID
                        select th.CustomerID).FirstOrDefault();
            }
        }

        private string GetClothName(int thID, int custID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from th in db.TransactionHeaders
                        join cu in db.Customers on th.CustomerID equals cu.CustomerID
                        join s in db.Clothes on th.ClothID equals s.ClothID
                        where th.TransactionID == thID && cu.CustomerID == custID
                        select s.ClothName).FirstOrDefault();
            }
        }

        private string GetClothSize(int thID, int custID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from th in db.TransactionHeaders
                        join s in db.Clothes on th.ClothID equals s.ClothID
                        join cu in db.Customers on th.CustomerID equals cu.CustomerID
                        join si in db.Sizes on s.SizeID equals si.SizeId
                        where th.TransactionID == thID && cu.CustomerID == custID
                        select si.SizeType).FirstOrDefault();
            }
        }

        private int GetCartQty(int thID, int custID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from th in db.TransactionHeaders
                        join cu in db.Customers on th.CustomerID equals cu.CustomerID
                        where th.TransactionID == thID && cu.CustomerID == custID
                        select th.Qty).FirstOrDefault();
            }
        }

        private string GetDate(int thID, int custID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from th in db.TransactionHeaders
                        join cu in db.Customers on th.CustomerID equals cu.CustomerID
                        where th.TransactionID == thID && cu.CustomerID == custID
                        select th.TransactionDate).FirstOrDefault().ToString("dd MMMM yyyy");
            }
        }

        private int GetClothPrice(int thID, int custID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (int)(from c in db.TransactionHeaders
                             join cu in db.Customers on c.CustomerID equals cu.CustomerID
                             where c.TransactionID == thID && cu.CustomerID == custID
                             select c.Price).FirstOrDefault();
            }
        }

        private string GetClothImg(int thID, int custID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from c in db.TransactionHeaders
                        join s in db.Clothes on c.ClothID equals s.ClothID
                        join cu in db.Customers on c.CustomerID equals cu.CustomerID
                        where c.TransactionID == thID && cu.CustomerID == custID
                        select s.ClothImage).FirstOrDefault().Replace("~", "..");
            }
        }

        private string GetClothPayment(int thID, int custID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from c in db.TransactionHeaders
                        join s in db.Payments on c.PaymentID equals s.PaymentId
                        join cu in db.Customers on c.CustomerID equals cu.CustomerID
                        where c.TransactionID == thID && cu.CustomerID == custID
                        select s.PaymentType).FirstOrDefault();
            }
        }
    }
}