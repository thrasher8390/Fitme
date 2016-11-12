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
    public partial class RateItem : System.Web.UI.Page
    {
        private UserModel userModel = new UserModel();
        private User user;
        private UserRatedClothes userRateditem;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session[Constants.Session_CurrentUser];
            userRateditem = (UserRatedClothes)Session[Constants.Session_CurrentUserRatedItem];
            if(!PagePermissions.IsAllowedOnPage(this, user))
            {
                Response.Redirect(PagePermissions.TransferToPage(this, user));
            }
        }

        protected void btnRateItem_Click(Object sender, EventArgs e)
        {
            //update user rated item
            userRateditem.Rating = rItemRating.CurrentRating;
            UserModel.UpdateUserProfile(user);
            Response.Redirect(Constants.Page_UserCloset);
            
        }

        protected void rItemRating_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
        {

        }
    }
}