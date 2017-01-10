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
        public string Gender;
        private List<UserRatedClothes> closet = new List<UserRatedClothes>();
        public List<UserRatedClothes> Closet
        {
            get
            {
                return closet;
            }
            set
            {
                if (value != null)
                {
                    closet = value;
                }
            }
        }

        internal long Password;
        internal string EmailAddress;

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

        /// <summary>
        /// passes back the reference to the item as it exists in the users closet
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        internal UserRatedClothes GetClosetItemById(int itemID)
        {
            return Closet.Find(closetItem => closetItem.ID == itemID);
        }
    }
}