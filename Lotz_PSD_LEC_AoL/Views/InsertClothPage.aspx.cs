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
    public partial class InsertClothPage : System.Web.UI.Page
    {
        public int s, g;
        LotzDatabaseEntities db = new LotzDatabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
                if (Session["customer"] != null || Request.Cookies["customer_cookie"] != null)
                {
                    Customer c = (Customer)Session["customer"];
                    // Only admin
                    if (!c.role.Equals("A"))
                    {
                        Response.Redirect("ErrorPage.aspx");
                    }

                }
                else
                {
                    Response.Redirect("ErrorPage.aspx");
                }

        }

        protected void insertCloth_Click(object sender, EventArgs e)
        {

            String name = nameTb.Text;
            String desc = descriptionTb.Text;
            String priceText = priceTb.Text;
            String stockText = stockTb.Text;
            s = (from si in db.Sizes where size.SelectedValue == si.SizeType select si.SizeId).FirstOrDefault();
            g = (from ge in db.Genders where gender.SelectedValue == ge.GenderType select ge.GenderId).FirstOrDefault();
            int price = 0, stock = 0;
            if (!priceText.Equals("")) price = int.Parse(priceText);
            if (!stockText.Equals("")) stock = int.Parse(stockText);

            String imgPath = "";
            int imgSize = 0;
            String imgExt = "";
            String response = "";
            if (imageUpload.HasFile)
            {
                imgPath = Server.MapPath("~/assets/img/") + imageUpload.FileName;
                imgSize = imageUpload.PostedFile.ContentLength;
                imgExt = System.IO.Path.GetExtension(imageUpload.FileName);
            }
            response = ClothController.validateCloth(name, desc, price, stock, imgPath, imageUpload.HasFile, imgSize, imgExt, s, g);

            errorMsg.Text = response;


            if (response.Equals(""))
            {
                imageUpload.SaveAs(imgPath);
                ClothController.doInsertCloth(name, desc, price, stock, "~/assets/img/" + imageUpload.FileName, s, g);
                Response.Redirect("~/Views/HomePage.aspx?ID=");
            }
        }
    }
}