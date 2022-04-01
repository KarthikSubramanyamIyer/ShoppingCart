using DataAccessLayer.DataAccessHandler;
using DataModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class SignUpService
    {
        private static DBManager GetConnection() => new DBManager("connectionstring");
        public DBManager dBManager;
        public SignUpService()
        {
            dBManager = GetConnection();
        }

        public bool SaveUsers(Users users)
        {

            try
            {
                string commandText = "Insert into Users(UserId,Name,Password,ConfirmPassword,MobileNo,Address,Pincode,Email,Usertype) values('" + users.UserId + "','" + users.Name + "','" + users.Password + "','" + users.ConfirmPassword + "','" + users.Mobileno + "','" + users.Address + "','" + users.PinCode + "','" + users.Email + "','User')";
                dBManager.Insert(commandText, commandType: System.Data.CommandType.Text, null);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
