using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using AccountManager.Models;
using Microsoft.VisualBasic;

namespace AccountManager.Controllers
{
    public class SettingsController : Controller
    {
        private AccountManagerContext Context;
        private static string Login = string.Empty;

        public SettingsController()
        {
            Context = new AccountManagerContext();
        }

        // GET: Settings
        public ActionResult Index()
        {
            if (TempData["login"] != null)
                Login = TempData["login"].ToString();


            User user = Context.Users.Single(u => u.Login == Login);

            SettingsViewModel svm = new SettingsViewModel { UserLogin = Login };


            return View("Index", svm);
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            User user = Context.Users.Single(u => u.Login == Login);


            string verificationCode = new Random().Next(100000, 999999).ToString();
            EmailManager.SendEmail(user.Email, "changePassword", user.Login, verificationCode);

            string code = Interaction.InputBox("A verification code has been sent to " +
               "your email address. Enter it in order to change your password.",
               "Authorization", "", 1, 1);

            if (code.Equals(verificationCode))
                return View("ChangePassword");
            else
            {
                MessageBox.Show("Invalid verification code, please try again.", "Invalid verification code.");
                SettingsViewModel svm = new SettingsViewModel { UserLogin = Login };

                return View("Index", svm);
            }
        }

        [HttpPost]
        public ActionResult ChangePassword(string password, string confirm)
        {
            SettingsViewModel svm = new SettingsViewModel { UserLogin = Login };

            if (!password.Equals(confirm))
            {
                MessageBox.Show("New password and password confirmation do not match.", "Error");
                return View("ChangePassword");
            }
            else
            {
                User userInDb = Context.Users.Single(u => u.Login == Login);
                userInDb.Password = password;
                Context.SaveChanges();
                MessageBox.Show("Password has been successfully changed.", "Success");
            }

            return View("Index", svm);
        }

        [HttpGet]
        public ActionResult ChangePin()
        {
            User user = Context.Users.Single(u => u.Login == Login);


            string verificationCode = new Random().Next(100000, 999999).ToString();
            EmailManager.SendEmail(user.Email, "changePin" +
                "", user.Login, verificationCode);

            string code = Interaction.InputBox("A verification code has been sent to " +
               "your email address. Enter it in order to change your PIN.",
               "Authorization", "", 1, 1);

            if (code.Equals(verificationCode))
                return View("ChangePin");
            else
            {
                MessageBox.Show("Invalid verification code, please try again.", "Invalid verification code.");
                SettingsViewModel svm = new SettingsViewModel { UserLogin = Login };

                return View("Index", svm);
            }
        }

        [HttpPost]
        public ActionResult ChangePin(string pin, string confirm)
        {
            SettingsViewModel svm = new SettingsViewModel { UserLogin = Login };

            if (!pin.Equals(confirm))
            {
                MessageBox.Show("New PIN and PIN confirmation do not match.", "Error");
                return View("ChangePin");
            }
            else
            {
                User userInDb = Context.Users.Single(u => u.Login == Login);
                userInDb.Pin = pin;
                Context.SaveChanges();
                MessageBox.Show("PIN has been successfully changed.", "Success");
            }

            return View("Index", svm);
        }
    }
}