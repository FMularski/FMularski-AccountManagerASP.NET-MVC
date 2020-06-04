using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountManager.Models;

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
    }
}