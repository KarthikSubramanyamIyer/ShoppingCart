using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModellayer.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }

        public int UserId { get; set; }

        public int PIDSizeID { get; set; }

        public string PaymentType { get; set; }

        public string PaymentStatus { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int PinCode { get; set; }

        public int MobileNumber { get; set; }
    }
}
