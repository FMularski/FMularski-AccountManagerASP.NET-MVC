using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

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
            if( Context.Users.SingleOrDefault(u => u.Login == login) != null)    // found user with given login = login used
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

            return Content("User \"" + login + "\" has been successfully registered.");
        }
    }
}