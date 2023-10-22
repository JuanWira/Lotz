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
    public partial class AccountPage : System.Web.UI.Page
    {
        public String role = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer cust = (Customer)Session["customer"];

            if (cust != null || Request.Cookies["customer_cookie"] != null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            String email = emailTb.Text;
            String password = passwordTb.Text;
            String response = CustomerController.validateLoginCustomer(email, password);
            errorMsg.Text = response;

            if (response.Equals(""))
            {
                Customer c = CustomerController.doLogin(email, password);
                Session["customer"] = c;
                Response.Redirect("~/Views/HomePage.aspx");
            }

        }
    }
}