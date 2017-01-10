using FitMe.Helper;
using FitMe.Models.ClothesModel;
using FitMe.Models.UserModel.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitMe
{
    public partial class UserCloset : System.Web.UI.Page
    {
        private UserModel userModel = new UserModel();
        private  User user;
        private DataTable dtUserCloset;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session[Constants.Session_CurrentUser];
            if (!PagePermissions.IsAllowedOnPage(this, user))
            {
                Server.Transfer(PagePermissions.TransferToPage(this, user), true);
            }

            dtUserCloset = new DataTable();
            dtUserCloset = ConvertToDatatable(user.Closet);
            gvUserCloset.DataSource = dtUserCloset;
            gvUserCloset.DataBind();  
        }

        static DataTable ConvertToDatatable(List<UserRatedClothes> list)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Item ID");
            dt.Columns.Add("Item Type");
            dt.Columns.Add("Rating");
            foreach (var item in list)
            {
                var row = dt.NewRow();

                row["Item ID"] = item.ID;
                row["Item Type"] = item.ItemType;
                row["Rating"] = Convert.ToString(item.Rating);

                dt.Rows.Add(row);
            }

            return dt;
        }

        protected void gvUserCloset_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Clothes.Remove(user.Closet[e.RowIndex]);
            if(UserModel.RemoveClosetItem(user, e.RowIndex))
            {
                dtUserCloset.Rows.RemoveAt(e.RowIndex);
                gvUserCloset.DataBind();
            }
        }

        protected void gvUserCloset_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session[Constants.Session_CurrentUserRatedItem] = user.Closet[e.NewEditIndex];
            Response.Redirect(Constants.Page_RateItem);
        }
    }
}