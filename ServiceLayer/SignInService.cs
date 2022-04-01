using DataAccessLayer.DataAccessHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class SignInService
    {
        private static DBManager GetConnection() => new DBManager("connectionstring");
        public DBManager dBManager;
        public SignInService()
        {
            dBManager = GetConnection();
        }
        public System.Data.DataTable GetUsers()
        {
            return dBManager.GetDataTable("Select * from Users where UserId=@UserId and Password=@Password", commandType: System.Data.CommandType.Text);
        }

    }
}
