using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows.Forms;

namespace AccountManager
{
    class EmailManager
    {
        public static void SendEmail(string to, string msgType, params string[] data)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Timeout = 10000;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(EmailManagerAccountData.Login, EmailManagerAccountData.Password);

                MailMessage mail = new MailMessage(EmailManagerAccountData.Login, to);
                mail.BodyEncoding = UTF8Encoding.UTF8;

                string subject = "";
                string body = "";

                switch (msgType)
                {
                    case "greeting":
                        subject = $"Hello {data[0]}!";
                        body = "Thank you for registering to Account Manager. Please verify your email address by " +
                            "entering verification code in your client window.\nPlease scroll down to see your code" +
                            ".\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n" +
                            ".\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n" +
                            $"Verification code: {data[1]}\n Always remember to keep your accounts safe!";

                        break;
                    case "forgot":
                        subject = "Password reminder requested";
                        body = $"You have requested a password reminder for your {data[0]} account. Please scroll down to see " +
                            "the verification code and enter it in your client window. " +
                            ".\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n" +
                            ".\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n" +
                            $"Verification code: {data[1]}\n Always remember to keep your accounts safe!";
                        break;
                    case "reminder":
                        subject = "Password reminder request accepted";
                        body = "Your request has been accepted. Please scroll down to see your password" +
                            ".\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n" +
                            ".\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n" +
                            $"Password: {data[0]}\nAlways remember to keep your accounts safe!";
                        break;
                    case "alert":
                        subject = "Login detected";
                        body = $"Login to your account {data[0]} has been detected in Account Manager at {data[1]}.\n" +
                            "Always remember to keep your accounts safe!";
                        break;
                    case "changePassword":
                        subject = "Password change requested";
                        body = $"You have requested password change for your {data[0]} account in Account Manager. " +
                            "In order to do that enter the verification code in your client window. Please scroll down to see the verification code" +
                            ".\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n" +
                            ".\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n" +
                            $"Verification code: {data[1]}\nAlways remember to keep your accounts safe!";
                        break;
                    case "changePin":
                        subject = "PIN change requested";
                        body = $"You have requested PIN change for your {data[0]} account in Account Manager. " +
                            "In order to do that enter the verification code in your client window. Please scroll down to see the verification code" +
                            ".\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n" +
                            ".\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n" +
                            $"Verification code: {data[1]}\nAlways remember to keep your accounts safe!";
                        break;
                    case "export":
                        subject = "Data export requested";
                        body = $"Data export has been requested for your {data[0]} account in AccountManager. " +
                             "In order to do that enter the verification code in your client window. Please scroll down to see the verification code" +
                            ".\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n" +
                            ".\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n.\n" +
                            $"Verification code: {data[1]}\nAlways remember to keep your accounts safe!";
                        break;
                }

                mail.Subject = subject;
                mail.Body = body;

                smtp.Send(mail);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
