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
        private MySqlConnection FitMeDataBaseConnection;
        private List<Top> Tops = new List<Top>();

        const string TABLE_DESIGNER = "top_designer";
        const string TABLE_CHEST = "top_chest";
        const string TABLE_NECK = "top_neck";
        const string TABLE_SLEEVE = "top_sleeve";

        //What exists in the DB today!
        Dictionary<int, string> ChestDict = new Dictionary<int, string>();
        Dictionary<int, string> DesignerDict = new Dictionary<int, string>();
        Dictionary<int, string> NeckDict = new Dictionary<int, string>();
        Dictionary<int, string> SleeveDict = new Dictionary<int, string>();

        /// <summary>
        /// This wil have access to all the databases that have to do with tops
        /// </summary>
        public TopModel()
        {
            FitMeDataBaseConnection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["fitmedatabase1"].ConnectionString);
            MySqlCommand getTop = new MySqlCommand("SELECT * FROM top",FitMeDataBaseConnection);

            //Read all of the shirt properties
            ReadFromTable(ChestDict, TABLE_CHEST, "Size");
            ReadFromTable(DesignerDict, TABLE_DESIGNER , "Name");
            ReadFromTable(NeckDict, TABLE_NECK, "Size");
            ReadFromTable(SleeveDict, TABLE_SLEEVE, "Size");

            FitMeDataBaseConnection.Open();

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
                        chestSize = ChestDict[chest];
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    int sleeve = Convert.ToInt32(topReader.GetString("Sleeve"));

                    Tops.Add(new Top(id, DesignerDict[designer], NeckDict[neck], chestSize, SleeveDict[sleeve]));
                }

            }

            FitMeDataBaseConnection.Close();       
        }

        /// <summary>
        /// We'll try updating the DB and also try creating a new Top item
        /// </summary>
        /// <param name="designer"></param>
        /// <param name="neck"></param>
        /// <param name="sleeve"></param>
        /// <param name="chest"></param>
        internal Boolean Create(string designer, string neck, string sleeve, string chest)
        {
            Boolean userAddedSomethingNew = false;

            if( TryUpdatingTables(DesignerDict, TABLE_DESIGNER, "Name", designer) |
                TryUpdatingTables(NeckDict, TABLE_NECK, "Size", neck) |
                TryUpdatingTables(SleeveDict, TABLE_SLEEVE, "Size", sleeve) |
                TryUpdatingTables(ChestDict, TABLE_CHEST, "Size", chest))
            {
                userAddedSomethingNew = true;
            }

            if (DoesTopExistInDB(designer, neck, sleeve, chest))
            {
                //Add a top to the DB
            }

            return userAddedSomethingNew;
        }

        /// <summary>
        /// Filter through Tops
        /// </summary>
        /// <param name="designer"></param>
        /// <param name="neck"></param>
        /// <param name="sleeve"></param>
        /// <param name="chest"></param>
        /// <returns></returns>
        private Boolean DoesTopExistInDB(string designer, string neck, string sleeve, string chest)
        {
            return false;
        }

        /// <summary>
        /// Read for a table in FitMeDataBase and add value to a dictionary
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="table"></param>
        /// <param name="valueString"></param>
        private void ReadFromTable(Dictionary<int,string> dict, string table, string valueString)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + table, FitMeDataBaseConnection);
            FitMeDataBaseConnection.Open();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    String key = reader.GetString("id");
                    String value = reader.GetString(valueString);
                    dict.Add(Convert.ToInt32(key), value);
                }
            }
            FitMeDataBaseConnection.Close();
            cmd.Dispose();
        }

        /// <summary>
        /// We should try to create a designer
        /// </summary>
        /// /// <param name="dict"></param
        /// <param name="designername"></param
        /// <returns>user contributed to the database!</returns>
        private Boolean TryUpdatingTables(Dictionary<int,string> dict, string table, string column, string value)
        {
            Boolean newValueAdded = false;
            if( !dict.ContainsValue(value) &&
                !String.IsNullOrEmpty(column) &&
                !String.IsNullOrEmpty(value))
            {
                newValueAdded = CreateNewRow(table, column, value);
            }

            return newValueAdded;
        }

        /// <summary>
        /// Create a new row and insert value
        /// </summary>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns>Successfully added row</returns>
        private Boolean CreateNewRow(string table, string column, string value)
        {
            Boolean returnValue = false;

            using (MySqlCommand insert = new MySqlCommand())
            {
                insert.CommandText = "INSERT INTO " + table + " (" + column + ") VALUES(\'" + value + "\')";
                insert.Connection = FitMeDataBaseConnection;

                FitMeDataBaseConnection.Open();

                if (insert.ExecuteNonQuery() > 0)
                {
                    returnValue = true;
                }

                FitMeDataBaseConnection.Close();
            }        

            return returnValue;
        }

    }
}