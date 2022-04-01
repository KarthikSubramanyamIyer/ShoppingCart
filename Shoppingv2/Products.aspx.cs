using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoppingv2
{
    public partial class Products : System.Web.UI.Page
    {
        ProductServices productService = new ProductServices();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["BuyNow"] == "YES")
                    {

                    }
                    BindProductRepeater();
                    //BindCartNumber();

                }
            }
            else
            {
                if (Request.QueryString["BuyNow"] == "YES")
                {
                    Response.Redirect("SignIn.aspx");
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }

        }
        //protected override void InitializeCulture()
        //{
        //    CultureInfo ci = new CultureInfo("en-IN");
        //    ci.NumberFormat.CurrencySymbol = "₹";
        //    Thread.CurrentThread.CurrentCulture = ci;

        //    base.InitializeCulture();
        //}

        private void BindProductRepeater()
        {
            {
                rptrProducts.DataSource = productService.GetProducts();
                rptrProducts.DataBind();
                if (productService.GetProducts().Rows.Count <= 0)
                {
                    Label1.Text = "Sorry! Currently no products in this category.";
                }
                else
                {
                    Label1.Text = "Showing All Products";
                }
            }
        }

        protected void btnCart2_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Cart.aspx");
        }

        //public void BindCartNumber()
        //{
        //    if (Session["USERID"] != null)
        //    {
        //        string UserIDD = Session["USERID"].ToString();
        //        {
        //            SqlCommand cmd = new SqlCommand("SP_BindCartNumberz")
        //            {
        //                CommandType = CommandType.StoredProcedure
        //            };
        //            cmd.Parameters.AddWithValue("@UserID", UserIDD);

        //            {

        //                if (CartQuantity.Rows.Count > 0)
        //                {
        //                    string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();
        //                    CartBadge.InnerText = CartQuantity;
        //                }
        //                else
        //                {
        //                    // _ = CartBadge.InnerText == 0.ToString();
        //                    CartBadge.InnerText = "0";
        //                }
        //            }
        //        }
        //    }
        //}


        protected void txtFilterGrid1Record_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterGrid1Record.Text != string.Empty)
            {

                string qr = "select A.*,B.*,C.Name ,A.PPrice-A.PSelPrice as DiscAmount,B.Name as ImageName, C.Name as BrandName from tblProducts A inner join tblBrands C on C.BrandID =A.PBrandID  cross apply( select top 1 * from tblProductImages B where B.PID= A.PID order by B.PID desc )B where  A.PName like '" + txtFilterGrid1Record.Text + "%' order by A.PID desc";

                if (productService.GetProducts().Rows.Count > 0)
                {
                    rptrProducts.DataSource = productService;
                    rptrProducts.DataBind();
                }
                else
                {

                }
            }
            else
            {
                BindProductRepeater();
            }

        }
    }
}