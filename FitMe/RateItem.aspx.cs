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
        public UserRatedClothes UserRateditem;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session[Constants.Session_CurrentUser];
            UserRateditem = (UserRatedClothes)Session[Constants.Session_CurrentUserRatedItem];
            if(!PagePermissions.IsAllowedOnPage(this, user))
            {
                Response.Redirect(PagePermissions.TransferToPage(this, user));
            }

            //Update item properties
            if (!IsPostBack)
            {
                rItemRating.CurrentRating = UserRateditem.Rating;
                tbPrice.Text = UserRateditem.Price.ToString();
                tbStore.Text = UserRateditem.Store_or_Link;
                tbComment.Text = UserRateditem.Comments;
            }
        }

        protected void btnRateItem_Click(Object sender, EventArgs e)
        {
            //update user rated item
            UserRateditem.Rating = rItemRating.CurrentRating;

            try
            {
                UserRateditem.Price = Convert.ToDouble(tbPrice.Text);
            }
            catch(Exception ex)
            {
                Console.WriteLine("0x0007,Could not convert price to a type Double," + ex.ToString());
            }

            UserRateditem.Store_or_Link = tbStore.Text;
            UserRateditem.Comments = tbComment.Text;

            UserModel.UpdateUserProfile(user);
            Response.Redirect(Constants.Page_UserCloset);  
        }
    }
}