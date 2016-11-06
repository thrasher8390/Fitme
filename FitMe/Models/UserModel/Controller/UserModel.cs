using FitMe.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;

namespace FitMe.Models.UserModel.Controller
{
    public class UserModel
    {
        public Dictionary<int, string> EmailDict = new Dictionary<int, string>();

        private const string TABLE_USER = "fitmeusers";
        private const string TABLE_USER_COLUMN_EMAIL = "email";
        private const string TABLE_USER_COLUMN_HASHPASS = "passHash";

        public UserModel()
        {
            //Pull all the users
            EmailDict = DataBase.ReadFromTable(TABLE_USER, TABLE_USER_COLUMN_EMAIL);
        }

        /// <summary>
        /// Creates an account for the user and then automatically signs in
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns></returns>
        internal Boolean CreateAccount(string firstName, string lastName, string email, string password, string passwordVerify)
        {
            Boolean returnValue = false;

            if(IsEmailAvailable(email))
            {
                if (password.Equals(passwordVerify))
                {
                    if(CreateNewUser(firstName,lastName,email,HashPassword(password)))
                    {
                        returnValue = SignInToAccount(email, password);
                    }
                    else
                    {
                        //We are currently experiencing issues with the server
                    }
                }
                {
                    //Passwords don't match
                }
            }
            else
            {
                //transition to sign in screen and prepopulate email address
            }

            return returnValue;
        }

        /// <summary>
        /// Sign into the account if the email and password are correct
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Boolean SignInToAccount(string email, string password)
        {
            Boolean returnValue = false;
            //We should only be signing in if there is already and email address
            if(!IsEmailAvailable(email))
            {
                //Find User
                DataBase.Open();
                string readCommand = "SELECT * FROM `" + TABLE_USER + "` WHERE " + TABLE_USER_COLUMN_EMAIL + " = \"" + email + "\"";
                MySqlCommand getUser = DataBase.GetMySqlCommand(readCommand);
                using (MySqlDataReader userReader = getUser.ExecuteReader())
                {
                    //Setup to throw error 0x0001
                    Boolean shouldOnlyHaveOneValueFlag = false;

                    while (userReader.Read())
                    {

                        int topID = Convert.ToInt32(userReader.GetString(DataBase.COLUMN_ID));
                        if((userReader.GetString(TABLE_USER_COLUMN_EMAIL).Equals(email)) &&
                            (userReader.GetInt64(TABLE_USER_COLUMN_HASHPASS) == HashPassword(password)))
                        {
                            returnValue = true;
                        }
                        else
                        {
                            //password was incorrect
                        }

                        if (shouldOnlyHaveOneValueFlag)
                        {
                            throw new Exception("0x0001,When signing in we found repeat emails in DB");
                        }

                        shouldOnlyHaveOneValueFlag = true;
                    }

                }

                DataBase.Close();
            }
            else
            {
                //Email Doesn't exist
            }

            return returnValue;
        }

        /// <summary>
        /// Creates a hash function out of the password so that we don't track user passwords
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private int HashPassword(string password)
        {
            return password.GetHashCode();
        }

        /// <summary>
        /// User will be added to the database and if it is succesfful we will report that user was added
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private Boolean CreateNewUser(string firstName, string lastName, string email, Int64 p)
        {
            Boolean userContributedToDataBase = false;

            string[] columns = { TABLE_USER_COLUMN_EMAIL, TABLE_USER_COLUMN_HASHPASS};
            string[] values = { email, p.ToString() };

            int id = DataBase.CreateNewRow(TABLE_USER, columns, values);

            //User contributed a new top to the database!
            if (id > 0)
            {
                userContributedToDataBase = true;
                EmailDict.Add(id, email);
            }

            return userContributedToDataBase;
        }

        /// <summary>
        /// Check to see if the dictionary contains a value that matches the new email address
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true if the email is available</returns>
        private bool IsEmailAvailable(string email)
        {
            return !EmailDict.Values.Contains(email);
        }
    }
}