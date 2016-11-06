using FitMe.Models.UserModel.Controller;
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
        UserModel user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = new UserModel();
            tbUserName.Focus();
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text.ToLower();
            string password = tbPassword.Text;

            user = new UserModel();
            if(user.SignInToAccount(userName, password))
            {
                Session["CurrentUser"] = user.CurrentUser;
                Server.Transfer("UserProfile.aspx",true);
            }
            else
            {
                //show failure message
            }
            
            //If successfull: go to User Profile!
            //If failure : say that email or password was not found
        }


    }
}