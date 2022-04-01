using DataAccessLayer.DataAccessHandler;
using DataModellayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class SubCategoryService
    {
        private static DBManager GetConnection() => new DBManager("connectionstring");
        public DBManager dBManager;
        public SubCategoryService()
        {
            dBManager = GetConnection();
        }

        public System.Data.DataTable GetSubCategory()
        {
            return dBManager.GetDataTable("select A.*,B.* from SubCategory A inner join Category B on B.CatID  = A.MainCatID", commandType: System.Data.CommandType.Text);
        }

        public bool SaveSubCategory(SubCategory subcategory)
        {

            try
            {
                string commandText = "Insert into SubCategory(SubCatName,MainCatID) Values('" + subcategory.SubCatName + "','" + subcategory.MainCatID + "')";
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
