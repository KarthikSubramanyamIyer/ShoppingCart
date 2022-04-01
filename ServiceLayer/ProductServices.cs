using DataAccessLayer.DataAccessHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ProductServices
    {
        private static DBManager GetConnection() => new DBManager("connectionstring");
        public DBManager dBManager;

        public ProductServices()
        {
            dBManager = GetConnection();
        }

        public System.Data.DataTable GetProducts()
        {
            return dBManager.GetDataTable("SELECT * FROM  Products", commandType: System.Data.CommandType.Text);
        }
    }
}
