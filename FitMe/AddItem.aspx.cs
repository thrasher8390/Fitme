using FitMe.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitMe
{
    public partial class AddItem : System.Web.UI.Page
    {
        static TopModel Top;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["CurrentUser"] == null)
            {
                Server.Transfer("Default.aspx", true);
            }
            //TODO we need a better way of updating the local topmodel db
            Top = new TopModel();
            lblInvalidDesignerName.Visible = false;
            lblInvalidNeckSize.Visible = false;
            lblInvalidSleeveSize.Visible = false;
            lblInvalidChestSize.Visible = false;

            lblSuccessfullyAddedItem.Visible = false;
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
               
                if (Top.Create(tbDesignerName.Text, tbNeckSize.Text, tbSleeveSize.Text, tbChestSize.Text))
                {
                    lblSuccessfullyAddedItem.Visible = true;
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