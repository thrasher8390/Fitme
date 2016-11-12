using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitMe.Models.ClothesModel
{
    public class Top
    {
        public int ID;
        public int DesignerName;
        public int NeckSize;
        public int ChestSize;
        public int SleeveSize;
        /// <summary>
        /// This is how many users have added the shirt to their closet
        /// </summary>
        public int ValidatedCount;
        
        public Top (int id, int designerName, int neckSize, int chestSize, int sleeveSize, int validatedCount)
        {
            ID = id;
            DesignerName = designerName;
            NeckSize = neckSize;
            ChestSize = chestSize;
            SleeveSize = sleeveSize;
            ValidatedCount = validatedCount;
        }

        public Boolean IsMatch(int designer, int neck, int sleeve, int chest)
        {
            Boolean result = DesignerName.Equals(designer);
            result &= NeckSize.Equals(neck);
            result &= SleeveSize.Equals(sleeve);
            result &= ChestSize.Equals(chest);

            return result;
        }
    }
}