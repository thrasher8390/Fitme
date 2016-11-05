using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitMe
{
    public partial class AccountSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbFirstName.Focus();
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            string firstName = tbFirstName.Text.ToLower();
            string lastName = tbLastName.Text.ToLower();
            string email = tbEmail.Text.ToLower();
            string password = tbPassword.Text;
            string passwordVerify = tbPasswordVerify.Text;

            //Acount Sign In
            //We should check to see if the account exists. If the account exists we should flip to the signin screen
            //Sing in and go to User Profile!
        }


    }
}