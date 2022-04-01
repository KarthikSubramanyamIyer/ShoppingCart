using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoppingv2
{
    public partial class Default : System.Web.UI.Page
    {
        DefaultService defaultservice = new DefaultService();
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Request.QueryString["UserLogin"] == "YES")
                {
                    Response.Redirect("UserHome.aspx?UserLogin=YES");
                }

                if (Session["Username"] != null)
                {
                    //lblSuccess.Text = "Login Success, Welcome <b>" + Session["Username"].ToString() + "</b>";

                    if (!this.IsPostBack)
                    {
                        BindProductRepeater();
                        btnSignUP.Visible = false;
                        btnSignIN.Visible = false;
                        btnlogout.Visible = true;
                    }

                }
                else
                {
                    BindProductRepeater();
                    btnSignUP.Visible = true;
                    btnSignIN.Visible = true;
                    btnlogout.Visible = false;
                    //Response.Redirect("Default.aspx");
                    Response.Write("<script type='text/javascript'>alert('Login plz')</script>");

                }
            }

            public void BindCartNumber()
            {
                if (Request.Cookies["CartPID"] != null)
                {
                    string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                    string[] ProductArray = CookiePID.Split(',');
                    int ProductCount = ProductArray.Length;
                    pCount.InnerText = ProductCount.ToString();
                }
                else
                {
                    pCount.InnerText = 0.ToString();
                }
            }

            protected void btnlogout_Click(object sender, EventArgs e)
            {
                Session["Username"] = null;
                Session.RemoveAll();
                Response.Redirect("Default.aspx");
            }

            private void BindProductRepeater()
            {



                rptrProducts.DataSource = defaultservice.GetProducts();
                rptrProducts.DataBind();
                if (defaultservice.GetProducts().Rows.Count <= 0)
                {
                    //Label1.Text = "Sorry! Currently no products in this category.";
                    pCount.InnerHtml = "0";
                }
                else
                {
                    //Label1.Text = "Showing All Products";
                }



            }

            protected override void InitializeCulture()
            {
                CultureInfo ci = new CultureInfo("en-IN");
                ci.NumberFormat.CurrencySymbol = "₹";
                Thread.CurrentThread.CurrentCulture = ci;

                base.InitializeCulture();
            }
        
    }
}