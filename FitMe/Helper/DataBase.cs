using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace FitMe.Helper
{
    public static class DataBase
    {
        private static MySqlConnection FitMeDataBaseConnection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["fitmedatabase1"].ConnectionString);

        private static Boolean isOpen = false;
        private static object lockIsOpen = new object();

        internal static void Open()
        {
            lock (lockIsOpen)
            {
                if (!isOpen)
                {
                    isOpen = true;
                    FitMeDataBaseConnection.Open();
                }
            }
        }

        internal static void Close()
        {
            lock (lockIsOpen)
            {
                if (isOpen)
                {
                    isOpen = false;
                    FitMeDataBaseConnection.Close();
                }
            }
        }

        internal static MySqlCommand GetMySqlCommand(string command)
        {
            return new MySqlCommand(command, FitMeDataBaseConnection);
        }
    }
}