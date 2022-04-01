using DataModellayer.Models;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoppingv2
{
    public partial class AddCategory : System.Web.UI.Page
    {
        CategoryService categoryService = new CategoryService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategoryReapter();
            }
        }

        private void BindCategoryReapter()
        {
            rptrCategory.DataSource = categoryService.GetCategory();
            rptrCategory.DataBind();
        }


        protected void btnAddtxtCategory_Click(object sender, EventArgs e)
        {
            Category categories = new Category();
            categories.Catname = txtCategory.Text;
            {
                Response.Write("<script> alert('Category Added Successfully ');  </script>");
                txtCategory.Text = string.Empty;


                //lblMsg.Text = "Registration Successfully done";
                //lblMsg.ForeColor = System.Drawing.Color.Green;
                txtCategory.Focus();


            }
        }
    }
}
