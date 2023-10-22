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
    public partial class NavBarFooter : System.Web.UI.MasterPage
    {
        public String role = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer cust;
            if (Session["customer"] == null)
            {
                role = "G";
            }
            else
            {
                cust = (Customer)Session["customer"];
                role = cust.role;
            }
        }

        protected void reg_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }

        protected void login_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void shop_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShopPage.aspx");
        }

        protected void history_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistoryPage.aspx");
        }

        protected void cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("CartPage.aspx");
        }

        protected void logo_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void women_Click(object sender, EventArgs e)
        {
            Response.Redirect("WomenPage.aspx");
        }

        protected void men_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenPage.aspx");
        }

        protected void about_Click(object sender, EventArgs e)
        {
            Response.Redirect("AboutPage.aspx");
        }

        protected void searchBtn_Click(object sender, ImageClickEventArgs e)
        {
            if (search.Text != "")
            {
                string s = search.Text;
                Session["SearchFor"] = s;
                Response.Redirect("ShowSearchPage.aspx");
            }
            else
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void privNpol_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrivacyAndPolicyPage.aspx");
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertClothPage.aspx");
        }

        protected void deleteCloth_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteClothPage.aspx");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            String[] cookies = Request.Cookies.AllKeys;
            foreach (String cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Remove("customer");
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}