using FitMe.Models.UserModel.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitMe.Models.ClothesModel
{
    public static class Clothes
    {
        public enum Type
        {
            Top,
            Bottom
        };

        /// <summary>
        /// The intent of this is to help keep the DB clean. When a user removes a item from their closet we'll try to remove it from the DB
        /// </summary>
        /// <param name=""></param>
        public static void Remove(UserRatedClothes item)
        {
            switch(item.ItemType)
            {
                case Type.Top:
                    {
                        TopModel topModel = new TopModel();
                        topModel.TryRemovingTop(item.ItemID);
                        break;
                    }
                case Type.Bottom:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}