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

        const string COLUMN_ID = "id";
        const string COLUMN_NAME = "Name";
        const string COLUMN_SIZE = "Size";

        const string TABLE_TOP = "top";
        const string TABLE_TOP_COLUMN_DESIGNER = "Designer";
        const string TABLE_TOP_COLUMN_NECK = "Neck";
        const string TABLE_TOP_COLUMN_SLEEVE = "Sleeve";
        const string TABLE_TOP_COLUMN_CHEST = "Chest";

        const string TABLE_DESIGNER = "designer";
        const string TABLE_CHEST = "size_chest";
        const string TABLE_NECK = "size_neck";
        const string TABLE_SLEEVE = "size_sleeve";

        //What exists in the DB today!
        public Dictionary<int, string> ChestDict = new Dictionary<int, string>();
        public Dictionary<int, string> DesignerDict = new Dictionary<int, string>();
        public Dictionary<int, string> NeckDict = new Dictionary<int, string>();
        public Dictionary<int, string> SleeveDict = new Dictionary<int, string>();

        /// <summary>
        /// This wil have access to all the databases that have to do with tops
        /// </summary>
        public TopModel()
        {
            FitMeDataBaseConnection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["fitmedatabase1"].ConnectionString);
            MySqlCommand getTop = new MySqlCommand("SELECT * FROM " + TABLE_TOP, FitMeDataBaseConnection);

            //Read all of the shirt properties
            ReadFromTable(ChestDict, TABLE_CHEST, COLUMN_SIZE);
            ReadFromTable(DesignerDict, TABLE_DESIGNER , COLUMN_NAME);
            ReadFromTable(NeckDict, TABLE_NECK, COLUMN_SIZE);
            ReadFromTable(SleeveDict, TABLE_SLEEVE, COLUMN_SIZE);

            FitMeDataBaseConnection.Open();

            using (MySqlDataReader topReader = getTop.ExecuteReader())
            {
                while (topReader.Read())
                {
                    int topID = Convert.ToInt32(topReader.GetString(COLUMN_ID));
                    int designerID = Convert.ToInt32(topReader.GetString(TABLE_TOP_COLUMN_DESIGNER));
                    int neckID = Convert.ToInt32(topReader.GetString(TABLE_TOP_COLUMN_NECK));
                    int chestID = 0;
                    try
                    {
                        chestID = Convert.ToInt32(topReader.GetString(TABLE_TOP_COLUMN_CHEST));
                    }
                    catch
                    {
                        Console.WriteLine("Chest ID was null");
                    }

                    int sleeveID = Convert.ToInt32(topReader.GetString(TABLE_TOP_COLUMN_SLEEVE));

                    Tops.Add(new Top(topID, designerID, neckID, chestID, sleeveID));
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

            TopDBAdd designerID = TryUpdatingTables(DesignerDict, TABLE_DESIGNER, COLUMN_NAME, designer);
            TopDBAdd neckID = TryUpdatingTables(NeckDict, TABLE_NECK, COLUMN_SIZE, neck);
            TopDBAdd sleeveID = TryUpdatingTables(SleeveDict, TABLE_SLEEVE, COLUMN_SIZE, sleeve);
            TopDBAdd chestID = TryUpdatingTables(ChestDict, TABLE_CHEST, COLUMN_SIZE, chest);

            if ( designerID.AddedNewValue ||
                neckID.AddedNewValue ||
                sleeveID.AddedNewValue ||
                chestID.AddedNewValue) 
            {
                userAddedSomethingNew = true;
            }

            if (!DoesTopExistInDB(designerID.id, neckID.id, sleeveID.id, chestID.id))
            {
                string[] columns = { TABLE_TOP_COLUMN_DESIGNER, TABLE_TOP_COLUMN_NECK, TABLE_TOP_COLUMN_SLEEVE, TABLE_TOP_COLUMN_CHEST };
                string[] values = { designerID.id.ToString(), neckID.id.ToString(), sleeveID.id.ToString(), chestID.id.ToString() };
                int id = CreateNewRow(TABLE_TOP, columns, values);
                if(id > 0)
                {
                    userAddedSomethingNew = true;
                }
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
        /// <returns>top already exists</returns>
        private Boolean DoesTopExistInDB(int designer, int neck, int sleeve, int chest)
        {
            Boolean doesTopExist = false;
            foreach(Top top in Tops)
            {
                if(top.IsMatch(designer, neck, sleeve, chest))
                {
                    doesTopExist = true;
                    break;
                }
            }

            return doesTopExist;
        }

        /// <summary>
        /// Read for a table in FitMeDataBase and add value to a dictionary
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="table"></param>
        /// <param name="valueString"></param>
        private void ReadFromTable(Dictionary<int,string> dict, string table, string valueString)
        {
            string command = "SELECT * FROM " + table;
            ReadFromTable(dict, table, valueString, command);
        }

        /// <summary>
        /// Read into dictionary from a table/command and its column
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="table"></param>
        /// <param name="valueString"></param>
        /// <param name="command"></param>
        private void ReadFromTable(Dictionary<int, string> dict, string table, string valueString, string command)
        {
            MySqlCommand cmd = new MySqlCommand(command, FitMeDataBaseConnection);

            FitMeDataBaseConnection.OpenAsync();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    String key = reader.GetString(COLUMN_ID);
                    String value = reader.GetString(valueString);
                    dict.Add(Convert.ToInt32(key), value);
                }
            }
            FitMeDataBaseConnection.CloseAsync();
            cmd.Dispose();
        }

        /// <summary>
        /// We should try to create a designer
        /// </summary>
        /// /// <param name="dict"></param
        /// <param name="designername"></param
        /// <returns>user contributed to the database!</returns>
        private TopDBAdd TryUpdatingTables(Dictionary<int,string> dict, string table, string column, string value)
        {
            TopDBAdd newItemTracker = new TopDBAdd();

            if( !String.IsNullOrEmpty(column) &&
                !String.IsNullOrEmpty(value))
            {
                Boolean valueExists = false;
                //Lets make sure it isn't formatting
                foreach (KeyValuePair<int,string> dictItem in dict)
                {
                    if (dictItem.Value.ToLower().Equals(value.ToLower()))
                    {
                        valueExists = true;
                        newItemTracker.id = dictItem.Key;
                    }
                }
 
                //try adding the new value if it isn't a repeate
                if (!valueExists)
                {
                    string[] columnArray = { column };
                    string[] valueArray = { value };
                    newItemTracker.id = CreateNewRow(table, columnArray, valueArray);
                    if(newItemTracker.id > 0)
                    {
                        newItemTracker.AddedNewValue = true;
                    }
                }
            }

            return newItemTracker;
        }

        /// <summary>
        /// Insert a new value into a new row of a specified table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns>id of the new row</returns>
        private int CreateNewRow(string table, string[] columns, string[] values)
        {
            int returnValue = 0;

            if (columns.Length == values.Length)
            {
                using (MySqlCommand insert = new MySqlCommand())
                {
                    string command = "INSERT INTO " + table + " (";
                    foreach(string col in columns)
                    {
                        command += col + ",";
                    }
                    //Remove the last comma
                    command = command.Remove(command.Length - 1,1);
                    command += ") VALUES(";
                    foreach (string val in values)
                    {
                        command += "\'" + val + "\',";
                    }
                    //Remove the last comma
                    command = command.Remove(command.Length - 1,1);
                    command += ")";

                    insert.CommandText = command;
                    insert.Connection = FitMeDataBaseConnection;

                    FitMeDataBaseConnection.Open();

                    if (insert.ExecuteNonQuery() > 0)
                    {
                        string readCommand = "SELECT * FROM `" + table + "` WHERE " + columns[0] + " = \"" + values[0] + "\"";
                        Dictionary<int, string> dict = new Dictionary<int, string>();
                        ReadFromTable(dict, table, columns[0], readCommand);

                        //TODO should we ever be seeing this sort of error?
                        if (dict.Count > 1)
                        {
                            throw new Exception("0x0000, When reading for the colum there was more than 1 id with the filtered value, " + dict.ToString());
                        }

                        returnValue = dict.Keys.First();
                    }

                    FitMeDataBaseConnection.Close();
                }
            }   

            return returnValue;
        }
    }

    /// <summary>
    /// This is used for when we are adding to a DB we can return if the row was created successfully and the unique id of the new row
    /// </summary>
    public class TopDBAdd
    {
        public int id = 0;
        public Boolean AddedNewValue = false;
        public TopDBAdd()
        {

        }
    }
}