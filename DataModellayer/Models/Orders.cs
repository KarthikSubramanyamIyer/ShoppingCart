using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModellayer.Models
{
    public class Orders
    {
        public int OrderID { get; set; }

        public int UserID { get; set; }

        public string Email { get; set; }

        public int PaymentType { get; set; }

        public int PaymentStatus { get; set; }
        public DateTime DateofPurchase { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MobileNumber { get; set; }
        public int OrderStatus { get; set; }
        public int OrderNumber { get; set; }
    }
}
