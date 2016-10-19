using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitMe.Controller
{
    public class Top
    {
        public int ID;
        public string DesignerName;
        public string NeckSize;
        public string ChestSize;
        public string SleeveSize;
        
        public Top (int id, string designerName, string neckSize, string chestSize, string sleeveSize)
        {
            this.ID = id;
            this.DesignerName = designerName;
            this.NeckSize = neckSize;
            this.ChestSize = chestSize;
            this.SleeveSize = sleeveSize;
        }
    }
}