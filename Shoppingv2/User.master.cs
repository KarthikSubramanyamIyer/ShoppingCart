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
    public partial class User : MasterPage
    {
        UserService userservice = new UserService();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Username"] != null)
            {
                //lblSuccess.Text = "Login Success, Welcome <b>" + Session["Username"].ToString() + "</b>";
                btnlogout.Visible = true;
                btnLogin.Visible = false;
                BindCartNumber22();
                Button1.Text = "Welcome: " + Session["Username"].ToString().ToUpper();

            }

        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session["Username"] = null;

            Response.Redirect("Default.aspx");

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SignIn.aspx");
        }
        public void BindCartNumber()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] ProductArray = CookiePID.Split(',');
                int ProductCount = ProductArray.Length;

            }

        }

        public void BindCartNumber22()
        {
            if (Session["USERID"] != null)
            {
                string UserIDD = Session["USERID"].ToString();



                {
                    SqlCommand cmd = new SqlCommand("SP_BindCartNumberz")
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@UserID", UserIDD);

                    {

                        if (userservice.GetBindCart22().Rows.Count > 0)
                        {
                            string CartQuantity = userservice.GetBindCart22().Compute("Sum(Qty)", "").ToString();


                        }

                    }
                }
            }
        }
    }
}
