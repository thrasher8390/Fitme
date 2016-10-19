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
            string designer = tbDesignerName.Text;
            string neck = tbNeckSize.Text;

            TopModel top = new TopModel();

            top.CreateDesigner(designer);
        }
    }
}