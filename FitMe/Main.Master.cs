using FitMe.Models.UserModel.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitMe
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 60;
            User currentUser = (User)Session["CurrentUser"];

            divLogin.Visible = (currentUser == null);
            divLogout.Visible = (currentUser != null);

        }
    }
}