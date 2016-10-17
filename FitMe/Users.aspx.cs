using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FitMe3
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            updateGVUsers();
        }

        protected void btnSaveUser_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(FitMeUsers.ConnectionString))
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "INSERT INTO fitmeusers (userName,firstName) VALUES(\'" + tbUserName.Text + "\',\'" + tbFirstName.Text + "\')";
                    cn.Open();
                    int numRowsUpdated = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            updateGVUsers();            
        }

        /// <summary>
        /// We need to force update of the grid view
        /// </summary>
        private void updateGVUsers()
        {
            try
            {
                FitMeUsers.EnableCaching = false;
                gvFitMeUsers.DataBind();
                FitMeUsers.EnableCaching = true;
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
}