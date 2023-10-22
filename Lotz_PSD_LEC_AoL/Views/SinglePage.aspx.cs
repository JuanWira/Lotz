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
    public partial class SinglePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorQty.Text = "";
            BindCardItems();
        }

        private void BindCardItems()
        {
            int id = Convert.ToInt32(Request.QueryString["ClothID"]);
            Cloth cardItems = ClothController.GetClothById(id);
            name.Text = GetClothName(cardItems.ClothID);
            img.ImageUrl = GetClothImg(cardItems.ClothID);
            prc.Text = GetClothPrice(cardItems.ClothID).ToString();
            desc.Text = GetClothDesc(cardItems.ClothID);
            size.Text = GetClothSize(cardItems.ClothID);
            gender.Text = GetClothGender(cardItems.ClothID);
            stock.Text = GetClothStock(cardItems.ClothID).ToString();
        }

        private string GetClothGender(int clothId)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from c in db.Clothes join s in db.Genders on c.GenderID equals s.GenderId where c.ClothID == clothId select s.GenderType).FirstOrDefault();
            }
        }

        private string GetClothSize(int clothId)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return (from c in db.Clothes join s in db.Sizes on c.SizeID equals s.SizeId where c.ClothID == clothId select s.SizeType).FirstOrDefault();
            }
        }

        private string GetClothDesc(int clothId)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return db.Clothes.Where(c => c.ClothID == clothId).Select(c => c.ClothDescription).FirstOrDefault();
            }
        }

        private int GetClothStock(int clothId)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return db.Clothes.Where(c => c.ClothID == clothId).Select(c => c.ClothStock).FirstOrDefault();
            }
        }

        private int GetClothPrice(int clothId)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return db.Clothes.Where(c => c.ClothID == clothId).Select(c => c.ClothPrice).FirstOrDefault();
            }
        }

        private string GetClothImg(int clothId)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return db.Clothes.Where(c => c.ClothID == clothId).Select(c => c.ClothImage).FirstOrDefault().Replace("~", "..");
            }
        }

        private string GetClothName(int clothId)
        {
            using (LotzDatabaseEntities db = new LotzDatabaseEntities())
            {
                return db.Clothes.Where(c => c.ClothID == clothId).Select(c => c.ClothName).FirstOrDefault();
            }
        }

        private bool error()
        {
            int id = Convert.ToInt32(Request.QueryString["ClothID"]);
            Cloth cardItems = ClothController.GetClothById(id);
            if (qty.Text != "" && Convert.ToInt32(qty.Text) > Convert.ToInt32(GetClothStock(cardItems.ClothID)))
            {
                errorQty.Text = "Stock is not enough!";
                return false;
            }
            else if(qty.Text == "")
            {
                errorQty.Text = "Input the quantity!";
                return false;
            }
            return true;
        }

        private bool login()
        {
            if(Session["customer"] == null)
            {
                return false;
            }
            return true;
        }

        protected void cart_Click(object sender, EventArgs e)
        {
            login();
            if (login() == true)
            {
                error();
                if (error() == true)
                {
                    Customer cust = (Customer)Session["customer"];
                    int id = Convert.ToInt32(Request.QueryString["ClothID"]);
                    Cloth item = ClothController.GetClothById(id);
                    CartController.AddItemToCart(cust, item, Convert.ToInt32(qty.Text));
                    Response.Redirect("CartPage.aspx");
                }
            }
            else
            {
                errorQty.Text = "Login First!";
            }
        }
    }
}