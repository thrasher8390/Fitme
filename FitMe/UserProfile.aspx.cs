using FitMe.Helper;
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
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["CurrentUser"];
            if(!PagePermissions.IsAllowedOnPage(this, user))
            {
                Response.Redirect(PagePermissions.TransferToPage(this, user), true);
            }

            if (!IsPostBack)
            {
                lblUpdateSuccessfull.Visible = false;
                
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
            user.FirstName = tbFirstName.Text;
            user.LastName = tbLastName.Text;
            
            lblUpdateSuccessfull.Visible = UserModel.UpdateUserProfile(user);           
        }
    }
}