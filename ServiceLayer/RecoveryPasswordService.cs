using DataAccessLayer.DataAccessHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class RecoveryPasswordService
    {
        private static DBManager GetConnection() => new DBManager("connectionstring");
        public DBManager dBManager;
        public RecoveryPasswordService()
        {
            dBManager = GetConnection();
        }
        public System.Data.DataTable GetForgotPass()
        {
            return dBManager.GetDataTable("select*from ForogtPass where UserId= @UserId", commandType: System.Data.CommandType.Text);
        }

        public System.Data.DataTable UpdateUsers()
        {
            return dBManager.GetDataTable("Update Users set Password=@Password where UserId=@UserId", commandType: System.Data.CommandType.Text);
        }

        public System.Data.DataTable DeleteUsers()
        {
            return dBManager.GetDataTable("Delete from ForgotPass where UserId = @UserId", commandType: System.Data.CommandType.Text);
        }
    }
}
