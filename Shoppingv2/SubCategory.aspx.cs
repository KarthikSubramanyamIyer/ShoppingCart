using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoppingv2
{
    public partial class SubCategory : System.Web.UI.Page
    {
        SubCategoryService subcategoryservice = new SubCategoryService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMainCat();
                BindSubCatRptr();

            }
        }

        private void BindSubCatRptr()
        {

            {
                rptrSubCat.DataSource = subcategoryservice.GetSubCategory();
                rptrSubCat.DataBind();


            }
        }


        protected void btnAddSubCategory_Click(object sender, EventArgs e)
        {

            {


                Response.Write("<script> alert('SubCategory Added Successfully ');  </script>");
                txtSubCategory.Text = string.Empty;


                ddlMainCatID.ClearSelection();
                ddlMainCatID.Items.FindByValue("0").Selected = true;
                txtSubCategory.Focus();
            }
            BindSubCatRptr();
        }

        private void BindMainCat()
        {
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-5ARN2QG\\SQLEXPRESS01; Initial Catalog = PandaCart; Integrated Security = True");
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Category", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlMainCatID.DataSource = dt;
                    ddlMainCatID.DataTextField = "CatName";
                    ddlMainCatID.DataValueField = "CatID";
                    ddlMainCatID.DataBind();
                    ddlMainCatID.Items.Insert(0, new ListItem("-Select-", "0"));

                }




            }
        }
    }
}