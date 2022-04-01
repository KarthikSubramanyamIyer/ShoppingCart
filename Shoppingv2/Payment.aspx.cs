using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoppingv2
{
    public partial class Payment : System.Web.UI.Page
    {
        PaymentService paymentservice = new PaymentService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPriceData2();
                genAutoNum();
                BindCartNumber();
                BindOrderProducts();
                BindPriceData();
                InsertOrderProducts();
                EmptyCart();

            }
        }

        public void BindPriceData()
        {

        }

        private void BindPriceData2()
        {

        }

        protected void btnPaytm_Click(object sender, EventArgs e)
        {
        }


        public void BindCartNumber()
        {
        }

        private void genAutoNum()
        {

        }

        private void BindOrderProducts()
        {

        }

        protected void btnCart2_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void BtnPlaceNPay_Click(object sender, EventArgs e)
        {

        }

        private void InsertOrderProducts()
        {

        }

        private void EmptyCart()
        {

        }
    }
}