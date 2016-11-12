using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace FitMe.Helper
{
    internal static class DataBase
    {
        private static MySqlConnection FitMeDataBaseConnection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["fitmedatabase1"].ConnectionString);

        internal const string COLUMN_ID = "id";

        private static Boolean isOpen = false;
        private static object lockIsOpen = new object();

        /// <summary>
        /// thread safe open DB connection
        /// </summary>
        internal static void Open()
        {
            lock (lockIsOpen)
            {
                if (!isOpen)
                {
                    isOpen = true;
                    try
                    {
                        FitMeDataBaseConnection.Open();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("0x0003,Database is not responding");
                    }
                }
            }
        }

        /// <summary>
        /// thread safe close DB connection
        /// </summary>
        internal static void Close()
        {
            lock (lockIsOpen)
            {
                try
                {
                    if (isOpen)
                    {
                        isOpen = false;
                        FitMeDataBaseConnection.Close();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("0x0006,Unable to close the DB connection," + ex.ToString());
                }
            }
        }

        /// <summary>
        /// grab a command with the database connection preloaded
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        internal static MySqlCommand GetMySqlCommand(string command)
        {
            return new MySqlCommand(command, FitMeDataBaseConnection);
        }

        /// <summary>
        /// Read for a table in FitMeDataBase and add value to a dictionary
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="table"></param>
        /// <param name="valueString"></param>
        internal static Dictionary<int, string> ReadFromTable(string table, string valueString)
        {
            string command = "SELECT * FROM " + table;
            return ReadFromTable(table, valueString, command);
        }

        /// <summary>
        /// Read into dictionary from a table/command and its column
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="table"></param>
        /// <param name="valueString"></param>
        /// <param name="command"></param>
        internal static Dictionary<int, string> ReadFromTable(string table, string valueString, string command)
        {
            MySqlCommand cmd = GetMySqlCommand(command);
            Dictionary<int, string> dict = new Dictionary<int, string>();
            Open();
            try
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        String key = reader.GetString(COLUMN_ID);
                        String value = reader.GetString(valueString);
                        dict.Add(Convert.ToInt32(key), value);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("0x0004, Failed to ReadFromTable," + ex.ToString());
            }
            Close();
            cmd.Dispose();

            return dict;
        }

        /// <summary>
        /// We should try to create a designer
        /// </summary>
        /// /// <param name="dict"></param
        /// <param name="designername"></param
        /// <returns>user contributed to the database!</returns>
        internal static DataBaseResults TryUpdatingTables(Dictionary<int, string> dict, string table, string column, string value)
        {
            DataBaseResults newItemTracker = new DataBaseResults();

            if (!String.IsNullOrEmpty(column) &&
                !String.IsNullOrEmpty(value))
            {
                Boolean valueExists = false;
                //Lets make sure it isn't formatting
                foreach (KeyValuePair<int, string> dictItem in dict)
                {
                    if (dictItem.Value.ToLower().Equals(value.ToLower()))
                    {
                        valueExists = true;
                        newItemTracker.ID = dictItem.Key;
                    }
                }

                //try adding the new value if it isn't a repeat
                if (!valueExists)
                {
                    string[] columnArray = { column };
                    string[] valueArray = { value };
                    newItemTracker = CreateNewRow(table, columnArray, valueArray);
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
        internal static DataBaseResults CreateNewRow(string table, string[] columns, string[] values)
        {
            DataBaseResults returnValue = new DataBaseResults();

            if (columns.Length == values.Length)
            {
                string command = "INSERT INTO " + table + " (";
                foreach (string col in columns)
                {
                    command += col + ",";
                }
                //Remove the last comma
                command = command.Remove(command.Length - 1, 1);
                command += ") VALUES(";
                foreach (string val in values)
                {
                    command += "\'" + val + "\',";
                }
                //Remove the last comma
                command = command.Remove(command.Length - 1, 1);
                command += ")";

                using (MySqlCommand insert = GetMySqlCommand(command))
                {
                    Open();

                    if (insert.ExecuteNonQuery() > 0)
                    {
                        string readCommand = "SELECT * FROM `" + table + "` WHERE " + columns[0] + " = \"" + values[0] + "\"";
                        Dictionary<int, string> dict = ReadFromTable(table, columns[0], readCommand);

                        //TODO should we ever be seeing this sort of error?
                        if (dict.Count > 1)
                        {
                            throw new Exception("0x0000, When reading for the colum there was more than 1 id with the filtered value, " + dict.ToString());
                        }

                        int id = dict.Keys.First();
                        if ( id > 0)
                        {
                            returnValue.NewItemAdded = true;
                            returnValue.ID = id;
                        }
                    }

                    Close();
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Remove a specific row ID from a table
        /// </summary>
        /// <param name="tableWithRow"></param>
        /// <param name="rowID"></param>
        /// <returns></returns>
        internal static Boolean RemoveRow(string tableWithRowID, string rowID)
        {
            Boolean columnUpdated = false;

            string command = "DELETE FROM " + tableWithRowID + " WHERE " + COLUMN_ID + "=\'" + rowID + "\'";
            using (MySqlCommand delete = GetMySqlCommand(command))
            {
                Open();

                if (delete.ExecuteNonQuery() > 0)
                {
                    columnUpdated = true;
                }
            }

            return columnUpdated;
        }

        /// <summary>
        /// Update a specific column of a row in a table
        /// </summary>
        /// <param name="tableWithColumn"></param>
        /// <param name="tableRowID"></param>
        /// <param name="columnToUpdate"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        internal static Boolean UpdateColumn(string tableWithColumn, int tableRowID, string columnToUpdate, string newValue)
        {
            Boolean columnUpdated = false;

            string command = "UPDATE " + tableWithColumn + " SET " + columnToUpdate + "=\'" + newValue + "\' WHERE id=\'" + tableRowID + "\'";
            using (MySqlCommand insert = GetMySqlCommand(command))
            {
                Open();

                if (insert.ExecuteNonQuery() > 0)
                {
                    columnUpdated = true;
                }
            }

            return columnUpdated;
        }
    }

    /// <summary>
    /// This is used for when we are adding to a DB we can return if the row was created successfully and the unique id of the new row
    /// </summary>
    internal class DataBaseResults
    {
        internal int ID = 0;
        internal Boolean ItemIDExists = false;
        private Boolean newItemAdded = false;
        internal Boolean NewItemAdded
        {
            get
            {
                return newItemAdded;
            }
            set
            {
                if (value)
                {
                    newItemAdded = value;
                    ItemIDExists = true;
                }
                else
                {
                    throw new Exception("Don't set NewItemAdded to false!");
                }
            }
        }

        internal DataBaseResults()
        {

        }
    }
}