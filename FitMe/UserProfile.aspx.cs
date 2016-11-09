using FitMe.Models.UserModel.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitMe
{
    public partial class UserProfile : System.Web.UI.Page
    {
        UserModel userModel = new UserModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUpdateSuccessfull.Visible = false;

                User user = (User)Session["CurrentUser"];
                try
                {
                    tbFirstName.Text = user.FirstName;
                    tbLastName.Text = user.LastName;
                    tbEmailAddress.Text = user.EmailAddress;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("0x0002," + ex.ToString());
                }
            }
        }

        protected void btnUpdateProfile_Click(Object sender, EventArgs e)
        {
            User user = (User)Session["CurrentUser"];
            user.FirstName = tbFirstName.Text;
            user.LastName = tbLastName.Text;
            
            lblUpdateSuccessfull.Visible = UserModel.UpdateUserProfile(user);           
        }
    }
}