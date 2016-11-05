using FitMe.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.IO;
using System.Text;

namespace FitMe.Models.UserModel.Controller
{
    public class UserModel
    {
        public Dictionary<int, string> EmailDict = new Dictionary<int, string>();

        public UserModel()
        {
            //Pull all the users
            
            //Fill in email dictionary so that we can easily determine if an email is already taken

        }
        internal void CreateAccount(string firstName, string lastName, string email, string password, string passwordVerify)
        {
            if(IsEmailAvailable(email))
            {
                if (password.Equals(passwordVerify))
                {
                    CreateNewUser(firstName,lastName,email,HashPassword(Encoding.ASCII.GetBytes(password)));
                }
            }
            else
            {
                //transition to sign in screen and prepopulate email address
            }
        }

        /// <summary>
        /// Creates a hash function out of the password so that we don't track user passwords
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private Int64 HashPassword(byte[] passwordBytes)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(passwordBytes);

            return BitConverter.ToInt64(sha1data, 0);
        }

        private void CreateNewUser(string firstName, string lastName, string email, Int64 p)
        {
            throw new NotImplementedException();
        }

        private bool IsEmailAvailable(string email)
        {
            throw new NotImplementedException();
        }
    }
}