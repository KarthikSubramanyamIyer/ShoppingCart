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
    public partial class AddBrand : System.Web.UI.Page
    {
        BrandService brandService = new BrandService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrandRepeater();

            }
        }

        public void BindBrandRepeater()
        {

            rptrBrands.DataSource = brandService.GetBrands();
            rptrBrands.DataBind();


        }

        protected void btnAddBrand_Click(object sender, EventArgs e)
        {
            Brands brands = new Brands();
            brands.Name = txtBrand.Text;
            bool result = brandService.SaveBrands(brands);
            if (result)
            {
                Response.Write("<script> alert('Brand Added Successfully ');  </script>");
            }
            else
            {
                Response.Write("<script> alert('Brand Added Failed ');  </script>");
            }

            txtBrand.Text = string.Empty;

            //lblMsg.Text = "Registration Successfully done";
            //lblMsg.ForeColor = System.Drawing.Color.Green;
            txtBrand.Focus();
        }
    }
}
