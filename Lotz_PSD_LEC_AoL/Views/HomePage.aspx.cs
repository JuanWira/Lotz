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
    public partial class HomePage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCardItems();
        }

        protected void shopSingle(object sender, EventArgs e)
        {
            Session["Single"] = Eval("ClothID");
            Response.Redirect("SinglePage.aspx");
        }
        private void BindCardItems()
        {
            List<Cloth> cardItems = ClothController.GetHomeCloth();
            List<displayCard> cardList = new List<displayCard>();
            foreach (Cloth displayCard in cardItems)
            {
                displayCard testItem = new displayCard();

                testItem.ClothID = displayCard.ClothID;
                testItem.ClothName = GetClothName(displayCard.ClothID);
                testItem.ClothImage = GetClothImg(displayCard.ClothID);
                testItem.ClothPrice = GetClothPrice(displayCard.ClothID);
                testItem.ClothStock = GetClothStock(displayCard.ClothID);
                testItem.ClothSize = GetClothSize(displayCard.ClothID);
                testItem.ClothGender = GetClothGender(displayCard.ClothID);
                testItem.ClothDesc = GetClothDesc(displayCard.ClothID);
                cardList.Add(testItem);
            }
            cardRepeater.DataSource = cardList;
            cardRepeater.DataBind();
        }

        public class displayCard
        {
            public string ClothImage { get; set; }
            public int ClothID { get; set; }
            public string ClothName { get; set; }
            public int ClothStock { get; set; }
            public int ClothPrice { get; set; }
            public string ClothDesc { get; set; }
            public string ClothSize { get; set; }
            public string ClothGender { get; set; }
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

        protected void shop_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShopPage.aspx");
        }

        protected void insertCloth_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertClothPage.aspx");
        }
    }
}