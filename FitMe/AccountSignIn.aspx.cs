using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitMe
{
    public partial class AccountSignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbUserName.Focus();
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text.ToLower();
            string password = tbPassword.Text;

            //Sing in and go to User Profile!
        }


    }
}