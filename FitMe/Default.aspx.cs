﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitMe
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Users.aspx",false);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
}