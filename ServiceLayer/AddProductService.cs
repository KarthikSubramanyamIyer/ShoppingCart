using DataAccessLayer.DataAccessHandler;
using DataModellayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class AddProductService
    {
        private static DBManager GetConnection() => new DBManager("connectionstring");
        public DBManager dBManager;
        public AddProductService()
        {
            dBManager = GetConnection();
        }

        public bool SaveProdcuts(Products products)
        {

            try
            {
                string commandText = "sp_InsertProduct(PName) values ('" + products.PName + "')";
                dBManager.Insert(commandText, commandType: System.Data.CommandType.Text, null);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public System.Data.DataTable GetBrands()
        {
            return dBManager.GetDataTable("SELECT * FROM  Products", commandType: System.Data.CommandType.Text);
        }


        public System.Data.DataTable GetGender()
        {
            return dBManager.GetDataTable("SELECT * FROM  Gender with(nolock)", commandType: System.Data.CommandType.Text);
        }
        public System.Data.DataTable GetCategory()
        {
            return dBManager.GetDataTable("SELECT * FROM   Category", commandType: System.Data.CommandType.Text);
        }

        public System.Data.DataTable GetSubCategory()
        {
            return dBManager.GetDataTable("SELECT * FROM   SubCategory", commandType: System.Data.CommandType.Text);
        }
        public System.Data.DataTable GetSizes()
        {
            return dBManager.GetDataTable("SELECT * FROM   Sizes", commandType: System.Data.CommandType.Text);
        }

        public System.Data.DataTable GetGridView1()
        {
            return dBManager.GetDataTable(" select distinct t1.PID,t1.PName,t1.PPrice,t1.PSelPrice,t2.Name as Brand,t3.CatName,t4.SubCatName, t5.GenderName as gender,t6.SizeName,t8.Quantity from Products as t1  inner join Brands as t2 on t2.BrandID=t1.PBrandID  inner join Category as t3 on t3.CatID=t1.PCategoryID  inner join SubCategory as t4 on t4.SubCatID=t1.PSubCatID   inner join Gender as t5 on t5.GenderID =t1.PGender   inner join Sizes as t6 on t6.SubCategoryID=t1.PSubCatID  inner join ProductSizeQuantity as t8 on t8.PID=t1.PID order by t1.PName", commandType: System.Data.CommandType.Text);
        }

    }
}

