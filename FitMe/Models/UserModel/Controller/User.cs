using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitMe.Models.UserModel.Controller
{
    public class User
    {
        public int ID;
        public string FirstName;
        public string LastName;
        public string EmailAddress;
        public string Gender;
        public long Password;

        public User()
        {
        }

        public User(int id, string firstName, string lastName, string email, long p)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = email;
            Password = p;
        }
    }
}