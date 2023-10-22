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
    public partial class CheckoutPage : System.Web.UI.Page
    {
        LotzDatabaseEntities db = new LotzDatabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCardItems();
            }
        }

        private void BindCardItems()
        {
            int id = Convert.ToInt32(Request.QueryString["CartID"]);
            Cart c = CartController.GetCartByID(id);

            name.Text = GetClothName(c.CartID);
            img.ImageUrl = GetClothImg(c.CartID);
            prc.Text = "Rp " + GetClothPrice(c.CartID).ToString();
            qty.Text = GetCartQty(c.CartID).ToString();
            size.Text = GetClothSize(c.CartID);
        }

        public class displayCard
        {
            public int CartID { get; set; }
            public int CustID { get; set; }
            public int ClothID { get; set; }
            public string ClothName { get; set; }
            public int ClothQty { get; set; }
            public int ClothPrice { get; set; }
            public string ClothSize { get; set; }
            public string ClothImage { get; set; }
        }

        private int GetClothID(int cartID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from c in db.Carts
                        where c.CartID == cartID
                        select c.ClothID).FirstOrDefault();
            }
        }
        private int GetCustID(int cartID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from c in db.Carts
                        where c.CartID == cartID
                        select c.CustomerID).FirstOrDefault();
            }
        }

        private string GetClothName(int cartID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from c in db.Carts
                        join s in db.Clothes on c.ClothID equals s.ClothID
                        where c.CartID == cartID 
                        select s.ClothName).FirstOrDefault();
            }
        }

        private string GetClothSize(int cartID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from c in db.Carts
                        join s in db.Clothes on c.ClothID equals s.ClothID
                        join si in db.Sizes on s.SizeID equals si.SizeId
                        where c.CartID == cartID
                        select si.SizeType).FirstOrDefault();
            }
        }

        private int GetCartQty(int cartID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from c in db.Carts
                        where c.CartID == cartID
                        select c.Qty).FirstOrDefault();
            }
        }

        private int GetClothPrice(int cartID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (int)(from c in db.Carts
                             where c.CartID == cartID
                             select c.Price).FirstOrDefault();
            }
        }

        private string GetClothImg(int cartID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from c in db.Carts
                        join s in db.Clothes on c.ClothID equals s.ClothID
                        where c.CartID == cartID
                        select s.ClothImage).FirstOrDefault().Replace("~", "..");
            }
        }

        protected void buy_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];
            int id = Convert.ToInt32(Request.QueryString["CartID"]);
            Payment pay = (from p in db.Payments where payment.SelectedValue == p.PaymentType select p).FirstOrDefault();
            Cloth cloth = (from c in db.Carts where c.CartID == id
                           join cl in db.Clothes on c.ClothID equals cl.ClothID
                           select cl).FirstOrDefault();
            TransactionController.CreateTransactionHeader(cust, pay, cloth, Convert.ToInt32(qty.Text), Convert.ToInt32(prc.Text.Replace("Rp ", "")));
            CartController.DeleteCartByID(id);
            ClothController.UpdateClothStock(cloth.ClothID, Convert.ToInt32(qty.Text));
            Response.Redirect("HistoryPage.aspx");
        }
    }
}