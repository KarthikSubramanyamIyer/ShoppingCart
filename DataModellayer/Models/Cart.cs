using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModellayer.Models
{
    public  class Cart
    {
        public int CartID { get; set; }

        public int UID { get; set; }
        public int PID { get; set; }
        public string PName { get; set; }
        public int PPrice { get; set; }

        public int PSellPrice { get; set; }

        public int Qty { get; set; }

    }
}
