using DataAccessLayer.DataAccessHandler;
using DataModellayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ForgotPasswordService
    {
        private static DBManager GetConnection() => new DBManager("connectionstring");
        public DBManager dBManager;
        public ForgotPasswordService()
        {
            dBManager = GetConnection();
        }
        public System.Data.DataTable GetUsers()
        {
            return dBManager.GetDataTable("Select * from Users where Email = @Email", commandType: System.Data.CommandType.Text);
        }
        public bool SaveForgotPass(ForgotPass forgotpass)
        {

            try
            {
                string commandText = "Insert into ForgotPass(Id,Userid,RequestDateTime) values('" + forgotpass.myGUID + "','" + forgotpass.UserId + "',GETDATE())";
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
