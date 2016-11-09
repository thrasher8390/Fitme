using FitMe.Controller;
using FitMe.Models.ClothesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitMe.Models.UserModel.Controller
{
    public class UserRatedClothes
    {
        Clothes.Type ItemType;
        int ItemID;
        int Rating;

        public UserRatedClothes(Clothes.Type itemType, int itemID, int rating)
        {
            ItemType = itemType;
            ItemID = itemID;
            Rating = rating; 
        }
    }
}