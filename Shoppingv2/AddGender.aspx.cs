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
    public partial class AddGender : System.Web.UI.Page
    {
        GenderService genderservices = new GenderService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGenderReapter();
            }
        }

        private void BindGenderReapter()
        {

            rptrGender.DataSource = genderservices.GetGender();
            rptrGender.DataBind();
        }

        protected void btnAddBrand_Click(object sender, EventArgs e)
        {

            Gender gender = new Gender();
            gender.GenderName = txtGender.Text;
            {
                Response.Write("<script> alert('Gender Added Successfully ');  </script>");
                txtGender.Text = string.Empty;

                txtGender.Focus();

            }
            BindGenderReapter();
        }
    }
}