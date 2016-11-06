using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitMe.Controller
{
    public class Top
    {
        public int ID;
        public int DesignerName;
        public int NeckSize;
        public int ChestSize;
        public int SleeveSize;
        
        public Top (int id, int designerName, int neckSize, int chestSize, int sleeveSize)
        {
            this.ID = id;
            this.DesignerName = designerName;
            this.NeckSize = neckSize;
            this.ChestSize = chestSize;
            this.SleeveSize = sleeveSize;
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