using FitMe.Helper;
using FitMe.Models.UserModel.Controller;
using System;

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
                Session[Constants.Session_CurrentUser] = user.CurrentUser;
                Response.Redirect(Constants.Page_UserProfile);
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