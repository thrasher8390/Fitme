using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitMe.Helper;
using FitMe.Models.UserModel.Controller;
using FitMe.Models.ClothesModel;

namespace FitMe
{
    public partial class AddItem : System.Web.UI.Page
    {
        private static TopModel Top;
        private User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session[Constants.Session_CurrentUser];
            if (!PagePermissions.IsAllowedOnPage(this, user))
            {
                Response.Redirect(PagePermissions.TransferToPage(this, user), true);
            }

            tbDesignerName.Focus();
            //TODO we need a better way of updating the local topmodel db
            Top = new TopModel();
            lblInvalidDesignerName.Visible = false;
            lblInvalidNeckSize.Visible = false;
            lblInvalidSleeveSize.Visible = false;
            lblInvalidChestSize.Visible = false;

            lblTroubleAddingItem.Visible = false;
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            string designerName = tbDesignerName.Text;
            string neckSize = tbNeckSize.Text;
            string sleeveSize = tbSleeveSize.Text;
            string chestSize = tbChestSize.Text;

            //Determins if we try to add a shirt or not
            Boolean illegalArgument = false;

            if (String.IsNullOrEmpty(designerName))
            {
                illegalArgument = true;
                lblInvalidDesignerName.Visible = true;
            }

            if(String.IsNullOrEmpty(neckSize))
            {
                illegalArgument = true;
                lblInvalidNeckSize.Visible = true;
            }

            if(String.IsNullOrEmpty(sleeveSize))
            {
                illegalArgument = true;
                lblInvalidSleeveSize.Visible = true;
            }

            if(String.IsNullOrEmpty(chestSize))
            {
                //illegalArgument = true;
                //lblInvalidChestSize.Visible = true;
            }

            if(!illegalArgument)
            {
                //Make sure the inputs are correct
                DataBaseResults result = Top.Create(tbDesignerName.Text, tbNeckSize.Text, tbSleeveSize.Text, tbChestSize.Text, user.ID);

                if (result.ItemIDExists)
                {
                    //TODO the next to lines should be placed in stage 4 of clothes model rating
                    UserRatedClothes item = new UserRatedClothes(Clothes.Type.Top, result.ID, 0);

                    //We have to add the item to the users closet to ensure that our Top DB and User validation stay in sync
                    if(UserModel.TryAddingClosetItem(user, item))
                    {
                        //newly added
                        Top.ValidatedClosetItem(item.ID);
                    }
                    else
                    {
                        //user already owns the item
                        item = user.GetClosetItemById(item.ID);
                    }

                    Session[Constants.Session_CurrentUserRatedItem] = item;
                    Response.Redirect(Constants.Page_RateItem);
                }
                else
                {
                    lblTroubleAddingItem.Visible = true;
                }
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetDesignerName(string prefixText, int count)
        {
            return FilterTable(Top.DesignerDict, prefixText, count);
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetNeckSize(string prefixText, int count)
        {
            return FilterTable(Top.NeckDict, prefixText, count);
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetSleeveSize(string prefixText, int count)
        {
            return FilterTable(Top.SleeveDict, prefixText, count);
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetChestSize(string prefixText, int count)
        {
            return FilterTable(Top.ChestDict, prefixText, count);
        }


        private static List<string> FilterTable(Dictionary<int,string> dict, string prefixText, int count)
        { 
            
            List<string> allDesigners = new List<string>();

            allDesigners.AddRange(from a in dict
                                  where a.Value.ToLower().StartsWith(prefixText.ToLower())
                            select a.Value);

            //Fill the list in with other words that contain the prefix if we are less than count
            if (allDesigners.Count < count)
            {
                allDesigners.AddRange(from a in dict
                                      where (!allDesigners.Contains(a.Value) && a.Value.ToLower().Contains(prefixText.ToLower()))
                                      select a.Value);
            }

            //Trim the list if it is greater than count
            if (allDesigners.Count > count)
            {
                allDesigners.RemoveRange(count, allDesigners.Count - count);
            }

            return allDesigners;
        }
    }
}