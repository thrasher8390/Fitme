using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using MySql.Data.MySqlClient;
using FitMe.Helper;

namespace FitMe.Controller
{
    public class TopModel
    {
        private List<Top> Tops = new List<Top>();

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
            //Read all of the shirt properties
            ChestDict = DataBase.ReadFromTable(TABLE_CHEST, COLUMN_SIZE);
            DesignerDict = DataBase.ReadFromTable(TABLE_DESIGNER, COLUMN_NAME);
            NeckDict = DataBase.ReadFromTable(TABLE_NECK, COLUMN_SIZE);
            SleeveDict = DataBase.ReadFromTable(TABLE_SLEEVE, COLUMN_SIZE);

            DataBase.Open();

            MySqlCommand getTop = DataBase.GetMySqlCommand("SELECT * FROM " + TABLE_TOP);
            using (MySqlDataReader topReader = getTop.ExecuteReader())
            {
                while (topReader.Read())
                {
                    int topID = Convert.ToInt32(topReader.GetString(DataBase.COLUMN_ID));
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

            DataBase.Close();
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
            Boolean userContributedToDataBase = false;

            DataBaseResults designerID = DataBase.TryUpdatingTables(DesignerDict, TABLE_DESIGNER, COLUMN_NAME, designer);
            DataBaseResults neckID = DataBase.TryUpdatingTables(NeckDict, TABLE_NECK, COLUMN_SIZE, neck);
            DataBaseResults sleeveID = DataBase.TryUpdatingTables(SleeveDict, TABLE_SLEEVE, COLUMN_SIZE, sleeve);
            DataBaseResults chestID = DataBase.TryUpdatingTables(ChestDict, TABLE_CHEST, COLUMN_SIZE, chest);

            //Did the user contribute to the dataBase?
            if (designerID.AddedNewValue ||
                neckID.AddedNewValue ||
                sleeveID.AddedNewValue ||
                chestID.AddedNewValue)
            {
                userContributedToDataBase = true;
            }

            if (!DoesTopExistInDB(designerID.id, neckID.id, sleeveID.id, chestID.id))
            {
                string[] columns = { TABLE_TOP_COLUMN_DESIGNER, TABLE_TOP_COLUMN_NECK, TABLE_TOP_COLUMN_SLEEVE, TABLE_TOP_COLUMN_CHEST };
                string[] values = { designerID.id.ToString(), neckID.id.ToString(), sleeveID.id.ToString(), chestID.id.ToString() };
                try
                {
                    int id = DataBase.CreateNewRow(TABLE_TOP, columns, values);

                    //User contributed a new top to the database!
                    if (id > 0)
                    {
                        userContributedToDataBase = true;
                    }
                }
                catch
                {
                    //If create New Row throws its exception it means that this are now more than 1 tops by this designer
                }
            }

            return userContributedToDataBase;
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
            foreach (Top top in Tops)
            {
                if (top.IsMatch(designer, neck, sleeve, chest))
                {
                    doesTopExist = true;
                    break;
                }
            }

            return doesTopExist;
        }
    }
}