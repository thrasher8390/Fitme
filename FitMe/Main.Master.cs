using FitMe.Models.UserModel.Controller;
using System;
using FitMe.Helper;

namespace FitMe
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 60;
            User currentUser = (User)Session[Constants.Session_CurrentUser];

            divLogin.Visible = (currentUser == null);
            divLogout.Visible = (currentUser != null);

        }
    }
}