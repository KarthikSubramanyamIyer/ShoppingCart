using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoppingv2
{
        public partial class ProductView : System.Web.UI.Page
        {
            ProductViewService productviewservice = new ProductViewService();

            readonly Int32 myQty = 1;
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Request.QueryString["PID"] != null)
                {
                    if (!IsPostBack)
                    {
                        BindProductImage();
                        BindProductDetails();
                        BindCartNumber();
                    }
                }
                else
                {
                    Response.Redirect("~/Products.aspx");
                }
            }

            private void BindProductDetails()
            {

                {

                    rptrProductDetails.DataSource = productviewservice.GetProducts();
                    rptrProductDetails.DataBind();
                }
            }
            private void BindProductImage()
            {

            //     rptrImage.DataSource = productviewservice.GetProductImages();
            //     rptrImage.DataBind();
        }



        protected string GetActiveImgClass(int ItemIndex)
            {
                if (ItemIndex == 0)
                {
                    return "active";
                }
                else
                {
                    return "";

                }
            }

            protected void rptrProductDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    string BrandID = (e.Item.FindControl("hfBrandID") as HiddenField).Value;
                    string CatID = (e.Item.FindControl("hfCatID") as HiddenField).Value;
                    string SubCatID = (e.Item.FindControl("hfSubCatID") as HiddenField).Value;
                    string GenderID = (e.Item.FindControl("hfGenderID") as HiddenField).Value;

                    RadioButtonList rblSize = e.Item.FindControl("rblSize") as RadioButtonList;

                    {

                        rblSize.DataSource = productviewservice.GetSizes();
                        rblSize.DataTextField = "sizename";
                        rblSize.DataValueField = "sizeid";
                        rblSize.DataBind();
                    }


                }
            }

            protected void btnAddtoCart_Click(object sender, EventArgs e)
            {
                string SelectedSize = string.Empty;
                foreach (RepeaterItem item in rptrProductDetails.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        var rbList = item.FindControl("rblSize") as RadioButtonList;
                        SelectedSize = rbList.SelectedValue;
                        var lblError = item.FindControl("lblError") as Label;
                        lblError.Text = "";
                    }
                }

                if (SelectedSize != "")
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                    if (Request.Cookies["CartPID"] != null)
                    {
                        string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                        CookiePID = CookiePID + "," + PID + "-" + SelectedSize;
                        HttpCookie CartProducts = new HttpCookie("CartPID");
                        CartProducts.Values["CartPID"] = CookiePID;
                        CartProducts.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(CartProducts);
                    }
                    else
                    {
                        HttpCookie CartProducts = new HttpCookie("CartPID");
                        CartProducts.Values["CartPID"] = PID.ToString() + "-" + SelectedSize;
                        CartProducts.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(CartProducts);
                    }
                    AddToCartProduction();
                    Response.Redirect("ProductView.aspx?PID=" + PID);
                }
                else
                {
                    foreach (RepeaterItem item in rptrProductDetails.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            var lblError = item.FindControl("lblError") as Label;
                            lblError.Text = "Please select a size";
                        }
                    }

                }
            }

            protected override void InitializeCulture()
            {
                CultureInfo ci = new CultureInfo("en-IN");
                ci.NumberFormat.CurrencySymbol = "₹";
                Thread.CurrentThread.CurrentCulture = ci;

                base.InitializeCulture();
            }

            public void BindCartNumber()
            {
                if (Session["USERID"] != null)
                {
                    string UserIDD = Session["USERID"].ToString();

                    SqlCommand cmd = new SqlCommand("SP_BindCartNumberz")
                    {
                        CommandType = CommandType.StoredProcedure
                    };


                    cmd.Parameters.AddWithValue("@UserID", UserIDD);



                    if (productviewservice.GetBindCartNumberz().Rows.Count > 0)
                    {
                        string CartQuantity = productviewservice.GetBindCartNumberz().Compute("Sum(Qty)", "").ToString();
                        //CartBage.InnerText = CartQuantity;

                    }
                    else
                    {
                        //CartBage.InnerText = 0.ToString();
                    }


                }
            }

            private void AddToCartProduction()
            {
                if (Session["Username"] != null)
                {
                    Int32 UserID = Convert.ToInt32(Session["USERID"].ToString());
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);


                    {

                        SqlCommand cmd = new SqlCommand("SP_IsProductExistInCart")
                        {
                            CommandType = CommandType.StoredProcedure
                        };
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@PID", PID);

                        {


                            if (productviewservice.GetAddToCartProducton().Rows.Count > 0)
                            {
                                Int32 updateQty = Convert.ToInt32(productviewservice.GetAddToCartProducton().Rows[0]["Qty"].ToString());
                                SqlCommand myCmd = new SqlCommand("SP_UpdateCart")
                                {
                                    CommandType = CommandType.StoredProcedure
                                };
                                myCmd.Parameters.AddWithValue("@Quantity", updateQty + 1);
                                myCmd.Parameters.AddWithValue("@CartPID", PID);
                                myCmd.Parameters.AddWithValue("@UserID", UserID);
                                Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                                BindCartNumber();

                            }
                            else
                            {
                                SqlCommand myCmd = new SqlCommand("SP_InsertCart")
                                {
                                    CommandType = CommandType.StoredProcedure
                                };
                                myCmd.Parameters.AddWithValue("@UID", UserID);
                                myCmd.Parameters.AddWithValue("@PID", Session["CartPID"].ToString());
                                myCmd.Parameters.AddWithValue("@PName", Session["myPName"].ToString());
                                myCmd.Parameters.AddWithValue("@PPrice", Session["myPPrice"].ToString());
                                myCmd.Parameters.AddWithValue("@PSelPrice", Session["myPSelPrice"].ToString());
                                myCmd.Parameters.AddWithValue("@Qty", myQty);
                                Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());

                                BindCartNumber();

                            }
                        }
                    }
                }
                else
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                    Response.Redirect("Signin.aspx?rurl=" + PID);
                }
            }

            protected void btnCart2_ServerClick(object sender, EventArgs e)
            {
                Response.Redirect("Cart.aspx");
            }
        }
}
