using DataAccessLayer.DataAccessHandler;
using DataModellayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ProductViewService
    {
        private static DBManager GetConnection() => new DBManager("connectionstring");
        public DBManager dBManager;
        public ProductViewService()
        {
            dBManager = GetConnection();
        }
        public System.Data.DataTable GetProducts()
        {
            return dBManager.GetDataTable("Select * from Products", commandType: System.Data.CommandType.Text);
        }
        public System.Data.DataTable GetProductImages()
        {
            return dBManager.GetDataTable("Select * from ProductImages", commandType: System.Data.CommandType.Text);
        }
        public System.Data.DataTable GetSizes()
        {
            return dBManager.GetDataTable("Select * from Sizes", commandType: System.Data.CommandType.Text);
        }

        public System.Data.DataTable GetBindCartNumberz()
        {


            return dBManager.GetDataTable("SP_BindCartNumberz", commandType: System.Data.CommandType.Text);
        }

        public System.Data.DataTable GetAddToCartProducton()
        {


            return dBManager.GetDataTable("SP_IsProductExistInCart", commandType: System.Data.CommandType.Text);
        }

        public System.Data.DataTable GetActiveImgClass()
        {


            return dBManager.GetDataTable("", commandType: System.Data.CommandType.Text);
        }


        public bool Products(Products products)

        {

            try
            {
                string commandText = "select * from Products Where PID = '" + products.PID + "'";
                dBManager.Insert(commandText, commandType: System.Data.CommandType.Text, null);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ProductImages(ProductImages productimages)

        {

            try
            {
                string commandText = "select * from ProdctImages Where PID = '" + productimages.PID + "'";
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
                string commandText = "select * from Sizes where BrandID='" + sizes.BrandID + "' and CategoryID=" + sizes.CategoryID + " and SubCategoryID=" + sizes.SubCategoryID + " and GenderID=" + sizes.GenderID + "";
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
