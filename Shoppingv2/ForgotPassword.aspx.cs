using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shoppingv2
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        ForgotPasswordService forgotpasswordservice = new ForgotPasswordService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPass_Click(object sender, EventArgs e)
        {


            if (forgotpasswordservice.GetUsers().Rows.Count != 0)
            {
                String myGUID = Guid.NewGuid().ToString();
                int UserId = Convert.ToInt32(forgotpasswordservice.GetUsers().Rows[0][0]);


                //Send reset link via Email

                String ToEmailAddress = forgotpasswordservice.GetUsers().Rows[0][7].ToString();
                String UserName = forgotpasswordservice.GetUsers().Rows[0][1].ToString();
                String EmailBody = "Hi ," + UserName + ",<br/><br/> Click The Link Below to Reset Your Password<br/><br/> https://localhost:44326/RecoverPassword.aspx?UserId =" + myGUID;

                MailMessage PasswordRecMail = new MailMessage("Your Email", ToEmailAddress);//Enter  Mail Id Here from where the message has to be sent
                PasswordRecMail.Body = EmailBody;
                PasswordRecMail.IsBodyHtml = true;
                PasswordRecMail.Subject = "Reset PassWord";

                //SmtpClient SMTP = new SmtpClient("smtp.gmail.com",587);
                //SMTP.Credentials = new NetworkCredential()
                //{
                //    UserName = "YourEmail@Example.com",//Personal Mail Id
                //    Password = "YourPassword"//Personal Password

                //};
                //SMTP.EnableSsl = true;
                //SMTP.Send(PasswordRecMail);

                using (SmtpClient Client = new SmtpClient())
                {
                    Client.EnableSsl = true;
                    Client.UseDefaultCredentials = false;
                    Client.Credentials = new NetworkCredential("Youremail", "sdfsdi@12345");
                    Client.Host = "smtp.gmail.com";
                    Client.Port = 587;
                    Client.DeliveryMethod = SmtpDeliveryMethod.Network;

                }

                ////------------

                lblResetPassMsg.Text = "Reset Link sent ! Check Your Email For Reseting Password";
                lblResetPassMsg.ForeColor = System.Drawing.Color.Green;
                txtEmailId.Text = string.Empty;
            }
            else
            {
                lblResetPassMsg.Text = "Oops This Email Does Not Exist .... plz Try again";
                lblResetPassMsg.ForeColor = System.Drawing.Color.Red;
                txtEmailId.Text = string.Empty;
                txtEmailId.Focus();
            }

        }
    }
}