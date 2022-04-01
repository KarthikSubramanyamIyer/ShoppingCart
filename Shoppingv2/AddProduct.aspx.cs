using DataModellayer.Models;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoppingv2
{
    public partial class AddProduct : System.Web.UI.Page
    {
        AddProductService productService = new AddProductService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //when page first time run then this code will execute
                BindBrand();
                BindGridview1();
                BindCategory();
                BindGender();
                ddlSubCategory.Enabled = false;
                ddlGender.Enabled = false;


            }
        }


        private void BindGender()
        {

            if (productService.GetGender().Rows.Count != 0)
            {
                ddlGender.DataSource = productService.GetGender();
                ddlGender.DataTextField = "GenderName";
                ddlGender.DataValueField = "GenderID";
                ddlGender.DataBind();
                ddlGender.Items.Insert(0, new ListItem("-Select-", "0"));

            }

        }

        private void BindCategory()
        {

            if (productService.GetCategory().Rows.Count != 0)
            {
                ddlCategory.DataSource = productService.GetCategory();
                ddlCategory.DataTextField = "CatName";
                ddlCategory.DataValueField = "CatID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));

            }

        }

        private void BindBrand()
        {
            if (productService.GetBrands().Rows.Count != 0)
            {
                ddlBrand.DataSource = productService.GetBrands();
                ddlBrand.DataTextField = "Name";
                ddlBrand.DataValueField = "BrandID";
                ddlBrand.DataBind();
                ddlBrand.Items.Insert(0, new ListItem("-Select-", "0"));

            }

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Products products = new Products();

            //products.PName = txtProductName.Text;
            //products.PPrice =  txtPrice.Text;
            //products.PSelPrice = txtsellPrice.Text;
            //products.PBrandID = ddlBrand.SelectedItem.Value;
            //products.PCategoryID = ddlCategory.SelectedItem.Value;
            //products.PSubCatID = ddlSubCategory.SelectedItem.Value;
            //products.PGender = ddlGender.SelectedItem.Value;
            //products.PDescription = txtDescription.Text;
            //products.PProductDetails = txtPDetail.Text;
            //products.PMaterialCare = txtMatCare.Text;
            SqlCommand cmd = new SqlCommand("sp_InsertProduct");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PName", txtProductName.Text);
            cmd.Parameters.AddWithValue("@PPrice", txtPrice.Text);
            cmd.Parameters.AddWithValue("@PSelPrice", txtsellPrice.Text);
            cmd.Parameters.AddWithValue("@PBrandID", ddlBrand.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@PCategoryID", ddlCategory.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@PSubCatID", ddlSubCategory.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@PGender", ddlGender.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@PDescription", txtDescription.Text);
            cmd.Parameters.AddWithValue("@PProductDetails", txtPDetail.Text);
            cmd.Parameters.AddWithValue("@PMaterialCare", txtMatCare.Text);
            if (chFD.Checked == true)
            {
                cmd.Parameters.AddWithValue("@FreeDelivery", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@FreeDelivery", 0.ToString());
            }

            if (ch30Ret.Checked == true)
            {
                cmd.Parameters.AddWithValue("@30DayRet", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@30DayRet", 0.ToString());
            }
            if (cbCOD.Checked == true)
            {
                cmd.Parameters.AddWithValue("@COD", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@COD", 0.ToString());
            }

            Int64 PID = Convert.ToInt64(cmd.ExecuteScalar());

            //Insert size quantity
            for (int i = 0; i < cblSize.Items.Count; i++)
            {
                if (cblSize.Items[i].Selected == true)
                {
                    Int64 SizeID = Convert.ToInt64(cblSize.Items[i].Value);
                    int Quantity = Convert.ToInt32(txtQuantity.Text);
                    ProductSizeQuantity productsizequantity = new ProductSizeQuantity();
                    // SqlCommand cmd2 = new SqlCommand("insert into tblProductSizeQuantity(PID,SizeID,Quantity) values('" + PID + "','" + SizeID + "','" + Quantity + "')", con);

                    productsizequantity.PID = Convert.ToInt32(PID);
                    productsizequantity.SizeId = Convert.ToInt32(SizeID);
                    productsizequantity.Quantity = Convert.ToInt32(Quantity);

                }
            }

            //Insert and upload images
            if (fuImg01.HasFile)
            {
                ProductImages productImages = new ProductImages();
                string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);

                }
                string Extention = Path.GetExtension(fuImg01.PostedFile.FileName);
                fuImg01.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "01" + Extention);

                //SqlCommand cmd3 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductName.Text.ToString ().Trim () + "01" + "','" + Extention  + "')", con);

                productImages.PID = Convert.ToInt32(PID);
                productImages.Name = txtProductName.Text.ToString().Trim() + "01";
                productImages.Extention = Extention;

            }

            //2nd fileupload
            if (fuImg02.HasFile)
            {
                ProductImages productImages = new ProductImages();
                string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);

                }
                string Extention = Path.GetExtension(fuImg02.PostedFile.FileName);
                fuImg02.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "02" + Extention);

                //SqlCommand cmd4 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductName.Text.ToString().Trim() + "02" + "','" + Extention + "')", con);
                productImages.PID = Convert.ToInt32(PID);
                productImages.Name = txtProductName.Text.ToString().Trim() + "02";
                productImages.Extention = Extention;
            }

            //3rd file upload 
            if (fuImg03.HasFile)
            {
                ProductImages productImages = new ProductImages();
                string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);

                }
                string Extention = Path.GetExtension(fuImg03.PostedFile.FileName);
                fuImg03.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "03" + Extention);

                //SqlCommand cmd5 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductName.Text.ToString().Trim() + "03" + "','" + Extention + "')", con);

                productImages.PID = Convert.ToInt32(PID);
                productImages.Name = txtProductName.Text.ToString().Trim() + "03";
                productImages.Extention = Extention;
            }

            //4th file upload control
            if (fuImg04.HasFile)
            {
                ProductImages productImages = new ProductImages();
                string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);

                }
                string Extention = Path.GetExtension(fuImg04.PostedFile.FileName);
                fuImg04.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "04" + Extention);

                //SqlCommand cmd6 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductName.Text.ToString().Trim() + "04" + "','" + Extention + "')", con);

                productImages.PID = Convert.ToInt32(PID);
                productImages.Name = txtProductName.Text.ToString().Trim() + "04";
                productImages.Extention = Extention;
            }

            //5th file upload
            if (fuImg05.HasFile)
            {
                ProductImages productImages = new ProductImages();
                string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);

                }
                string Extention = Path.GetExtension(fuImg05.PostedFile.FileName);
                fuImg05.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "05" + Extention);

                //SqlCommand cmd7 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductName.Text.ToString().Trim() + "05" + "','" + Extention + "')", con);
                productImages.PID = Convert.ToInt32(PID);
                productImages.Name = txtProductName.Text.ToString().Trim() + "05";
                productImages.Extention = Extention;


            }

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubCategory subcategory = new SubCategory();

            ddlSubCategory.Enabled = true;
            int MainCatID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            {

                if (productService.GetSubCategory().Rows.Count != 0)
                {
                    ddlSubCategory.DataSource = productService.GetSubCategory();
                    ddlSubCategory.DataTextField = "SubCatName";
                    ddlSubCategory.DataValueField = "SubCatID";
                    ddlSubCategory.DataBind();
                    ddlSubCategory.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            }
        }

        protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sizes sizes = new Sizes();

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@BrandID", ddlBrand.SelectedValue);
            cmd.Parameters.AddWithValue("@CategoryID", ddlCategory.SelectedValue);
            cmd.Parameters.AddWithValue("@SubCategoryID", ddlSubCategory.SelectedValue);
            cmd.Parameters.AddWithValue("@GenderID", ddlGender.SelectedValue);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //int BrandID = Convert.ToInt32(ddlBrand.SelectedItem.Value);
            //int CategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            //int SubCategoryID = Convert.ToInt32(ddlSubCategory.SelectedItem.Value);
            //int GenderID = Convert.ToInt32(ddlGender.SelectedItem.Value);


            {

                //SqlCommand cmd = new SqlCommand("Select * from Sizes where BrandID='" + ddlBrand.SelectedItem.Value + "' and  CategoryID='" + ddlCategory.SelectedItem.Value + "' and  SubCategoryID='" + ddlSubCategory.SelectedItem.Value + "' and  GenderID='" + ddlGender.SelectedItem.Value + "' ");
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //sda.Fill(dt);
                if (productService.GetSizes().Rows.Count != 0)
                {
                    cblSize.DataSource = productService.GetSizes();
                    cblSize.DataTextField = "SizeName";
                    cblSize.DataValueField = "SizeID";
                    cblSize.DataBind();


                }
            }
        }

        protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSubCategory.SelectedIndex != 0)
            {
                ddlGender.Enabled = true;
            }
            else
            {
                ddlGender.Enabled = false;
            }
        }
        private void BindGridview1()
        {
            if (productService.GetGridView1().Rows.Count > 0)
            {
                GridView1.DataSource = productService.GetGridView1();
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }


        }
    }
}