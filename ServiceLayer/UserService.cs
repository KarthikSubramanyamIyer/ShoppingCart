using DataAccessLayer.DataAccessHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class UserService
    {
        private static DBManager GetConnection() => new DBManager("connectionstring");
        public DBManager dBManager;
        public UserService()
        {
            dBManager = GetConnection();
        }
        public System.Data.DataTable GetBindCart22()
        {
            return dBManager.GetDataTable("SP_BindCartNumberz", commandType: System.Data.CommandType.Text);
        }
    }
}
