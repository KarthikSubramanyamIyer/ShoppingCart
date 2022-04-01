using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoppingv2
{
    public partial class SignUp : System.Web.UI.Page
    {
        SignUpService signupservice = new SignUpService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtsignup_Click(object sender, EventArgs e)
        {
            if (isformvalid())
            {
                Response.Write("<script> alert('Registration Successfully done'); </script>");
                clr();

                lblMsg.Text = "Registration Successfully done";
                lblMsg.ForeColor = System.Drawing.Color.Green;


                Response.Redirect("~/SignIn.aspx");
            }
            else
            {
                Response.Write("<script> alert('Registration Failed'); </script>");
                lblMsg.Text = "All Fields are Manatory";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool isformvalid()
        {
            if (txtUname.Text == "")
            {
                Response.Write("<script> alert('User Name not Valid'); </script>");
                return false;
            }
            else if (txtPass.Text == "")
            {
                Response.Write("<script> alert('Password not Valid'); </script>");
                return false;
            }
            else if (txtCpass.Text != txtPass.Text)
            {
                Response.Write("<script> alert('Confirm Password not Valid'); </script>");
                return false;
            }
            else if (txtMno.Text == "")
            {
                Response.Write("<script> alert('MobileNo not Valid'); </script>");
                return false;
            }
            else if (txtAdd.Text == "")
            {
                Response.Write("<script> alert('Address not Valid'); </script>");
                return false;
            }
            else if (txtPin.Text == "")
            {
                Response.Write("<script> alert('Pincode not Valid'); </script>");
                return false;
            }
            else if (txtEmail.Text == "")
            {
                Response.Write("<script> alert('Email not Valid'); </script>");
                return false;
            }
            return true;
        }

        private void clr()
        {
            txtUname.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtCpass.Text = string.Empty;
            txtMno.Text = string.Empty;
            txtAdd.Text = string.Empty;
            txtPin.Text = string.Empty;
            txtEmail.Text = string.Empty;

        }
    }
}