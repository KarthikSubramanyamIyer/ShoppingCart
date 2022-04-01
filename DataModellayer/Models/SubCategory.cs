using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModellayer.Models
{
    public  class SubCategory
    {
        public int SubCatID { get; set; }

        public string SubCatName { get; set; }

        public int MainCatID { get; set; }
    }
}
