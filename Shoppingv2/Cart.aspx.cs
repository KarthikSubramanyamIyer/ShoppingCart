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
using ServiceLayer;

namespace Shoppingv2
{
    public partial class Cart : System.Web.UI.Page
    {
        CartServices cartservices = new CartServices();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        private void BindProductcart()
        {
           

        }

        protected void btnRemoveCart_Click(object sender, EventArgs e)
        {

        }
        protected void btnBuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Payment.aspx");
        }
    }
}