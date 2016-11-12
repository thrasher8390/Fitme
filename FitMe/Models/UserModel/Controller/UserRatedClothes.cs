using FitMe.Models.ClothesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitMe.Models.UserModel.Controller
{
    public class UserRatedClothes
    {
        public Clothes.Type ItemType;
        public int ItemID;
        public int Rating;

        public UserRatedClothes(Clothes.Type itemType, int itemID, int rating)
        {
            ItemType = itemType;
            ItemID = itemID;
            Rating = rating; 
        }
    }
}