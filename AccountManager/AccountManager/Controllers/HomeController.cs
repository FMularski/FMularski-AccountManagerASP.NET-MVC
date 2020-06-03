using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace AccountManager.Controllers
{
    public class HomeController : Controller
    {
        private AccountManagerContext Context;

        public HomeController()
        {
            Context = new AccountManagerContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(string login, string email, string password, string confirm, string pin)
        {
            if ( Context.Users.SingleOrDefault(u => u.Login == login) != null)    // found user with given login = login used
            {
                MessageBox.Show("Login \"" + login + "\" is already used.", "Login used");
                return RedirectToAction("Index");
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Password too short");
                return RedirectToAction("Index");
            }

            if ( !password.Equals(confirm))
            {
                MessageBox.Show("Password and password confirmation do not match.", "No match");
                return RedirectToAction("Index");
            }

            string verificationCode = new Random().Next(100000, 999999).ToString();
            EmailManager.SendEmail(email, "greeting", login, verificationCode);

            string code = Interaction.InputBox("A verification code has been sent to " +
               "your email address. Enter it in order to verify your email account and proceed with the registration.",
               "Authorization", "", 1, 1);

            if ( !code.Equals(verificationCode))
            {
                MessageBox.Show("Invalid verification code, please try again.", "Invalid verification code.");
                return RedirectToAction("Index");
            }

            Context.Users.Add(new User { Login = login, Email = email, Password = password, Pin = pin });
            Context.SaveChanges();

            MessageBox.Show("User \"" + login + "\" has been successfully registered.", "Registration successful");
            return RedirectToAction("Index");
        }

        public ActionResult Remind()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Remind(string login, string email)
        {
            if (Context.Users.SingleOrDefault(u => u.Login == login) == null)
            {
                MessageBox.Show("Invalid login.", "Error");
                return RedirectToAction("Remind");
            }

            if ( !Context.Users.Single(u => u.Login == login).Email.Equals(email)) // if login does not match email
            {
                MessageBox.Show("Login does not match inserted email.", "Error");
                return RedirectToAction("Remind");
            }

            string verificationCode = new Random().Next(100000, 999999).ToString();
            EmailManager.SendEmail(email, "forgot", login, verificationCode);

            string code = Interaction.InputBox("A verification code has been sent to " +
               "your email address. Enter it in order to receive a reminder for your password.",
               "Password reminder requested", "", 1, 1);

            if (!code.Equals(verificationCode))
            {
                MessageBox.Show("Invalid verification code, please try again.", "Invalid verification code.");
                return RedirectToAction("Remind");
            }

            EmailManager.SendEmail(email, "reminder", Context.Users.Single(u => u.Login == login).Password);
            MessageBox.Show("Your password reminder request has been accepted. You will receive an email with your password.", "Success");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            if (Context.Users.SingleOrDefault(u => u.Login == login) == null)
            {
                MessageBox.Show("Invalid login.", "Error");
                return RedirectToAction("Index");
            }

            if ( !Context.Users.Single(u => u.Login == login).Password.Equals(password))
            {
                MessageBox.Show("Invalid password.", "Error");
                return RedirectToAction("Index");
            }

            EmailManager.SendEmail(Context.Users.Single(u => u.Login == login).Email, "alert", login, DateTime.Now.ToString());

            TempData["login"] = login;

            return RedirectToAction("Index", "Main");
        }
    }
}