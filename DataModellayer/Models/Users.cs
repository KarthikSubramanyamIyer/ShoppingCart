using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModelLayer
{
    public class Users
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public int Mobileno { get; set; }

        public string Address { get; set; }

        public int PinCode { get; set; }

        public string Email { get; set; }

        public string Usertype { get; set; }
    }
}
