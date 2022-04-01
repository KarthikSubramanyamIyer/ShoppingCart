using DataAccessLayer.DataAccessHandler;
using DataModellayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class CategoryService
    {
        private static DBManager GetConnection() => new DBManager("connectionstring");
        public DBManager dBManager;

        public CategoryService()
        {
            dBManager = GetConnection();
        }

        public System.Data.DataTable GetCategory()
        {
            return dBManager.GetDataTable("SELECT * FROM  Category", commandType: System.Data.CommandType.Text);
        }

        public bool SaveCategory(Category categories)
        {

            try
            {
                string commandText = "Insert into Category(CatName) Values('" + categories.Catname + "')";
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

