using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModellayer.Models
{
    public class Products
    {
        public int PID { get; set; }

        public string PName { get; set; }

        public int PBrandID { get; set; }

        public int PCategoryID { get; set; }

        public int PGender { get; set; }

        public string PDescription { get; set; }

        public string PProductDescription { get; set; }

        public int PMaterialCare { get; set; }

        public int FreeDelivery { get; set; }
        public int COD { get; set; }

        public int DayRet { get; set; }

    }
}
