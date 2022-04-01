using DataAccessLayer.DataAccessHandler;
using DataModellayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
   public class SizeServices
    {
        private static DBManager GetConnection() => new DBManager("connectionstring");
        public DBManager dBManager;
        public SizeServices()
        {
            dBManager = GetConnection();
        }
        public System.Data.DataTable GetSizes()
        {
            return dBManager.GetDataTable("select A.*,B.*,C.*,D.*,E.* from Sizes A inner join Category B on B.CatID =a.CategoryID  inner join Brands C on C.BrandID =A.BrandID inner join SubCategory D on D.SubCatID =A.SubCategoryID inner join Gender E on E.GenderID =A.GenderID", commandType: System.Data.CommandType.Text);
        }

        public System.Data.DataTable GetMainCategory()
        {
            return dBManager.GetDataTable("Select * from Category", commandType: System.Data.CommandType.Text);
        }
        public System.Data.DataTable GetBrands()
        {
            return dBManager.GetDataTable("Select * from Brands", commandType: System.Data.CommandType.Text);
        }
        public System.Data.DataTable GetGender()
        {
            return dBManager.GetDataTable("Select * from Gender with(nolock)", commandType: System.Data.CommandType.Text);
        }
        public System.Data.DataTable GetSubCategory()
        {

            return dBManager.GetDataTable("Select * from SubCategory", commandType: System.Data.CommandType.Text);
        }
        public bool SaveSubCategory(SubCategory subcategory)

        {

            try
            {
                string commandText = "Select * from SubCategory where MainCatID='" + subcategory.MainCatID + "'";
                dBManager.Insert(commandText, commandType: System.Data.CommandType.Text, null);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveSizes(Sizes sizes)
        {

            try
            {
                string commandText = "Insert into Sizes(SizeName,BrandID,CategoryID,SubCategoryID,GenderID) Values('" + sizes.SizeName + "','" + sizes.BrandID + "','" + sizes.CategoryID + "','" + sizes.SubCategoryID + "','" + sizes.GenderID + "')";
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
