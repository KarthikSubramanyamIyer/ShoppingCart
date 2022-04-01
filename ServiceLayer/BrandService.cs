using DataAccessLayer.DataAccessHandler;
using DataModellayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class BrandService
    {
        private static DBManager GetConnection() => new DBManager("connectionstring");
        public DBManager dBManager;
        public BrandService()
        {
            dBManager = GetConnection();
        }
        public System.Data.DataTable GetBrands()
        {
            return dBManager.GetDataTable("SELECT * FROM  Brands", commandType: System.Data.CommandType.Text);
        }

        public bool SaveBrands(Brands brands)
        {

            try
            {
                string commandText = "Insert into Brands(Name) Values('" + brands.Name + "')";
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

