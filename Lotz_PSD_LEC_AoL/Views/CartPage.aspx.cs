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
    public partial class CartPage : System.Web.UI.Page
    {
        public String role = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["customer"] == null)
                {
                    role = "G";
                }
                else
                {
                    Customer c = new Customer();
                    role = c.role;
                    Customer cust = (Customer)Session["customer"];
                    int cID = cust.CustomerID;
                    if (CartController.GetAllCartByCustomerId(cID) != null)
                    {
                        BindCardItems();
                    }
                }
                
            }
        }

        private void BindCardItems()
        {
            Customer cust = (Customer)Session["customer"];
            int cID = cust.CustomerID;
            List<Cart> cardItems = CartController.GetAllCartByCustomerId(cID);
            List<displayCard> cardList = new List<displayCard>();

            foreach (Cart displayCard in cardItems)
            {
                displayCard testItem = new displayCard();

                testItem.CartID = displayCard.CartID;
                testItem.ClothName = GetClothName(displayCard.CartID, cID);
                testItem.ClothImage = GetClothImg(displayCard.CartID, cID);
                testItem.ClothPrice = GetClothPrice(displayCard.CartID, cID);
                testItem.ClothQty = GetCartQty(displayCard.CartID, cID);
                testItem.ClothSize = GetClothSize(displayCard.CartID, cID);
                cardList.Add(testItem);
            }
            cardRepeater.DataSource = cardList;
            cardRepeater.DataBind();
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

        private int GetClothID(int cartID, int custID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from c in db.Carts
                        join s in db.Customers on c.CustomerID equals s.CustomerID
                        where c.CartID == cartID && s.CustomerID == custID select c.ClothID).FirstOrDefault();
            }
        }
        private int GetCustID(int cartID, int custID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from c in db.Carts
                        join s in db.Customers on c.CustomerID equals s.CustomerID
                        where c.CartID == cartID && s.CustomerID == custID
                        select c.CustomerID).FirstOrDefault();
            }
        }

        private string GetClothName(int cartID, int custID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from c in db.Carts
                        join cu in db.Customers on c.CustomerID equals cu.CustomerID
                        join s in db.Clothes on c.ClothID equals s.ClothID 
                        where c.CartID == cartID && cu.CustomerID == custID
                        select s.ClothName).FirstOrDefault();
            }
        }

        private string GetClothSize(int cartID, int custID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from c in db.Carts join s in db.Clothes on c.ClothID equals s.ClothID
                        join cu in db.Customers on c.CustomerID equals cu.CustomerID
                        join si in db.Sizes on s.SizeID equals si.SizeId
                        where c.CartID == cartID && cu.CustomerID == custID
                        select si.SizeType).FirstOrDefault();
            }
        }

        private int GetCartQty(int cartID, int custID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from c in db.Carts
                        join cu in db.Customers on c.CustomerID equals cu.CustomerID
                        where c.CartID == cartID && cu.CustomerID == custID
                        select c.Qty).FirstOrDefault();
            }
        }

        private int GetClothPrice(int cartID, int custID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (int)(from c in db.Carts
                             join cu in db.Customers on c.CustomerID equals cu.CustomerID
                             where c.CartID == cartID && cu.CustomerID == custID
                             select c.Price).FirstOrDefault();
            }
        }

        private string GetClothImg(int cartID, int custID)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from c in db.Carts join s in db.Clothes on c.ClothID equals s.ClothID
                        join cu in db.Customers on c.CustomerID equals cu.CustomerID
                        where c.CartID == cartID && cu.CustomerID == custID
                        select s.ClothImage).FirstOrDefault().Replace("~", "..");
            }
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            Button del = (Button)sender;
            int cartID = Convert.ToInt32(del.CommandArgument);
            CartController.DeleteCartByID(cartID);
            Response.Redirect("CartPage.aspx");
        }
    }
}