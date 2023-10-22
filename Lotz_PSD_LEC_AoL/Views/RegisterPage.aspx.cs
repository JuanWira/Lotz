using Lotz_PSD_LEC_AoL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lotz_PSD_LEC_AoL.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            String name = nameReg.Text;
            String email = emailReg.Text;
            String gender = genderRb.SelectedValue;
            String address = addressTb.Text;
            String password = pw.Text;
            String num = number.Text;
            String r = "C";
            errorReg.Text = CustomerController.validateRegisterCustomer(name, email, gender, address, password, num, r);
            if (errorReg.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Account Made Successfully. Please Login');window.location ='LoginPage.aspx';",
                    true);
            }

        }
    }
}