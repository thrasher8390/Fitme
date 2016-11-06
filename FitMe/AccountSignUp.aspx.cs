using FitMe.Models.UserModel.Controller;
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
        UserModel user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = new UserModel();
            tbFirstName.Focus();
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            string firstName = tbFirstName.Text.ToLower();
            string lastName = tbLastName.Text.ToLower();
            string email = tbEmail.Text.ToLower();
            string password = tbPassword.Text;
            string passwordVerify = tbPasswordVerify.Text;

            user = new UserModel();
            if(user.CreateAccount(firstName, lastName, email, password, passwordVerify))
            {
                Session["CurrentUser"] = user.CurrentUser;
                Server.Transfer("UserProfile.aspx", true);
            }
            else
            {
                //switch case for handling Create Account
                //Account exists: If the account exists we should flip to the signin screen
                //Successful Signin: Go to User Profile!
            }
        }
    }
}