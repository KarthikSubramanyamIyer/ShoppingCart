using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoppingv2
{
    public partial class RecoverPassword : System.Web.UI.Page
    {

        RecoveryPasswordService recoverpasswordservice = new RecoveryPasswordService();
        string GUIDvalue;

        int UId;
        protected void Page_Load(object sender, EventArgs e)
        {
            GUIDvalue = Request.QueryString["UserId"];

            if (GUIDvalue != null)
            {

                if (recoverpasswordservice.GetForgotPass().Rows.Count != 0)
                {
                    UId = Convert.ToInt32(recoverpasswordservice.GetForgotPass().Rows[0][1]);
                }
                else
                {
                    lblmsg.Text = "Your password reset Link is Expired or Invalid.. plz try agan";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }


            if (!IsPostBack)
            {
                if (recoverpasswordservice.GetForgotPass().Rows.Count != 0)
                {
                    txtConfirmPass.Visible = true;
                    txtNewPass.Visible = true;
                    lblNewPassword.Visible = true;
                    lblResetPassword.Visible = true;
                    btnResetPass.Visible = true;
                }
                else
                {
                    lblmsg.Text = "Your password reset Link is Expired or Invalid.. plz try agan";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
            }


        }

        protected void btnResetPass_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text != "" && txtConfirmPass.Text != "" && txtNewPass.Text == txtConfirmPass.Text)
            {
                {
                    txtNewPass.Text = "@Password";
                    Int64 UId = Convert.ToInt64(Request.QueryString["UserId"]);

                    Response.Write("<script> alert ('Password Reset Successfully done'); <script/>");
                    Response.Redirect("~/SignIn.aspx");

                }
            }
        }
    }
}