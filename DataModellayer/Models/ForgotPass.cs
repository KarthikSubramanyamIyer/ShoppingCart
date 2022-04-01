using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModellayer.Models
{
    public class ForgotPass
    {
        public string myGUID;

        public int id { get; set; }

        public int UserId { get; set; }

        public DateTime RequestDateTime { get; set; }
    }
}
