using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoppingv2
{
    public partial class AddSize : System.Web.UI.Page
    {
        SizeServices sizeservices = new SizeServices();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrand();
                BindMainCategory();
                BindGender();
                BindrptrSize();



            }
        }

        private void BindrptrSize()
        {

            rptrSize.DataSource = sizeservices.GetSizes();
            rptrSize.DataBind();

        }



        private void BindMainCategory()

        {

            if (sizeservices.GetMainCategory().Rows.Count != 0)
            {
                ddlCategory.DataSource = sizeservices.GetMainCategory();
                ddlCategory.DataTextField = "CatName";
                ddlCategory.DataValueField = "CatID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));

            }
        }


        private void BindBrand()
        {

            if (sizeservices.GetBrands().Rows.Count != 0)
            {
                ddlBrand.DataSource = sizeservices.GetBrands();
                ddlBrand.DataTextField = "Name";
                ddlBrand.DataValueField = "BrandID";
                ddlBrand.DataBind();
                ddlBrand.Items.Insert(0, new ListItem("-Select-", "0"));

            }

        }

        private void BindGender()
        {
            if (sizeservices.GetGender().Rows.Count != 0)
            {
                ddlGender.DataSource = sizeservices.GetGender();
                ddlGender.DataTextField = "GenderName";
                ddlGender.DataValueField = "GenderID";
                ddlGender.DataBind();
                ddlGender.Items.Insert(0, new ListItem("-Select-", "0"));

            }

        }
        protected void btnAddSize_Click(object sender, EventArgs e)
        {

            {

                Response.Write("<script> alert('Size Added Successfully ');  </script>");
                txtSize.Text = string.Empty;


                ddlBrand.ClearSelection();
                ddlBrand.Items.FindByValue("0").Selected = true;

                ddlCategory.ClearSelection();
                ddlCategory.Items.FindByValue("0").Selected = true;

                ddlSubCategory.ClearSelection();
                ddlSubCategory.Items.FindByValue("0").Selected = true;

                ddlGender.ClearSelection();
                ddlGender.Items.FindByValue("0").Selected = true;

            }
            BindrptrSize();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);


            {

                SqlCommand cmd = new SqlCommand("Select * from SubCategory where MainCatID='" + ddlCategory.SelectedItem.Value + "'");

                if (sizeservices.GetSubCategory().Rows.Count != 0)
                {
                    ddlSubCategory.DataSource = sizeservices.GetSubCategory();
                    ddlSubCategory.DataTextField = "SubCatName";
                    ddlSubCategory.DataValueField = "SubCatID";
                    ddlSubCategory.DataBind();
                    ddlSubCategory.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            }
        }
    }
}