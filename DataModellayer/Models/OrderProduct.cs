using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModellayer.Models
{
    public class OrderProduct
    {
        public int OrderProID { get; set; }
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int PID { get; set; }
        public string Products { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public int status { get; set; }
    }
}
