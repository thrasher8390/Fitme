using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using MySql.Data.MySqlClient;

namespace FitMe.Controller
{
    public class TopModel
    {
        private MySqlConnection data;
        private List<Top> tops = new List<Top>();

        //What exists in the DB today!
        Dictionary<int, string> chestDict = new Dictionary<int, string>();
        Dictionary<int, string> designerDict = new Dictionary<int, string>();
        Dictionary<int, string> neckDict = new Dictionary<int, string>();
        Dictionary<int, string> sleeveDict = new Dictionary<int, string>();

        /// <summary>
        /// This wil have access to all the databases that have to do with tops
        /// </summary>
        public TopModel()
        {
            data = new MySqlConnection(WebConfigurationManager.ConnectionStrings["fitmedatabase1"].ConnectionString);
            MySqlCommand getTop = new MySqlCommand("SELECT * FROM top",data);
            MySqlCommand getTopChest = new MySqlCommand("SELECT * FROM top_chest", data);
            MySqlCommand getTopDesigner = new MySqlCommand("SELECT * FROM top_designer", data);
            MySqlCommand getTopNeck = new MySqlCommand("SELECT * FROM top_neck", data);
            MySqlCommand getTopSleeve = new MySqlCommand("SELECT * FROM top_sleeve", data);
            data.Open();
           
            using (MySqlDataReader topChestReader = getTopChest.ExecuteReader())
            {
                while (topChestReader.Read())
                {
                    String id = topChestReader.GetString("id");
                    String size = topChestReader.GetString("Size");
                    chestDict.Add(Convert.ToInt32(id), size);
                }
            }
            
            using (MySqlDataReader topDesignerReader = getTopDesigner.ExecuteReader())
            {
                while (topDesignerReader.Read())
                {
                    String id = topDesignerReader.GetString("id");
                    String name = topDesignerReader.GetString("Name");
                    designerDict.Add(Convert.ToInt32(id), name);
                }

            }
            
            using (MySqlDataReader topNeckReader = getTopNeck.ExecuteReader())
            {
                while (topNeckReader.Read())
                {
                    String id = topNeckReader.GetString("id");
                    String size = topNeckReader.GetString("Size");
                    neckDict.Add(Convert.ToInt32(id), size);
                }

            }
            
            using (MySqlDataReader topSleveReader = getTopSleeve.ExecuteReader())
            {
                while (topSleveReader.Read())
                {
                    String id = topSleveReader.GetString("id");
                    String size = topSleveReader.GetString("Size");
                    sleeveDict.Add(Convert.ToInt32(id), size);
                }

            }

            using (MySqlDataReader topReader = getTop.ExecuteReader())
            {
                while (topReader.Read())
                {
                    int id = Convert.ToInt32(topReader.GetString("id"));
                    int designer = Convert.ToInt32(topReader.GetString("Designer"));
                    int neck = Convert.ToInt32(topReader.GetString("Neck"));
                    string chestSize = null;
                    try
                    {
                        int chest = Convert.ToInt32(topReader.GetString("Chest"));
                        chestSize = chestDict[chest];
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    int sleeve = Convert.ToInt32(topReader.GetString("Sleeve"));

                    tops.Add(new Top(id, designerDict[designer], neckDict[neck], chestSize, sleeveDict[sleeve]));
                }

            }

            data.Close();       
            
            //dispose everything
            getTop.Dispose();
            getTopChest.Dispose();
            getTopDesigner.Dispose();
            getTopNeck.Dispose();
            getTopSleeve.Dispose();
            //start connect with sql server
        }

        public Boolean CreateDesigner(string designername)
        {
            Boolean updateSuccessful = false;
            if(!designerDict.ContainsValue(designername))
            {
                MySqlCommand addDesigner = new MySqlCommand();
                addDesigner.CommandText = "INSERT INTO top_designer (Name) VALUES(\'" + designername + "\')";
                addDesigner.Connection = data;
                data.Open();
                int rowsUpdated = addDesigner.ExecuteNonQuery();
                if(rowsUpdated >0)
                {
                    updateSuccessful = true;
                }
            }

            return updateSuccessful;
        }
    }
}