using DataAccessLayer;
using DataAccessLayer.DataAccessHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class DefaultService
    {
        private static DBManager GetConnection() => new DBManager("connectionstring");
        public DBManager dBManager;
        public DefaultService()
        {
            dBManager = GetConnection();
        }
        public System.Data.DataTable GetProducts()
        {
            return dBManager.GetDataTable("procBindAllProducts", commandType: System.Data.CommandType.Text);
        }
    }
}
