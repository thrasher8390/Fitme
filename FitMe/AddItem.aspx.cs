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
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            TopModel Top = new TopModel();
            if (Top.Create(tbDesignerName.Text, tbNeckSize.Text, tbSleeveSize.Text, tbChestSize.Text))
            {
                Console.WriteLine("YAY!!! something new was added! Thanks for the contribution");
                lblSuccessfullyAddedItem.Visible = true;
            }
            else
            {
                lblSuccessfullyAddedItem.Visible = false;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}