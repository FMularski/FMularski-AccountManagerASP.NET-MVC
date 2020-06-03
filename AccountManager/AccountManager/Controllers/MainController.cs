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
    public class MainController : Controller
    {
        private AccountManagerContext Context;
        private static string Login = string.Empty;

        public MainController()
        {
            Context = new AccountManagerContext();
        }

        // GET: Main
        public ActionResult Index()
        {
            if (TempData["login"] != null)
                Login = TempData["login"].ToString();


            User user = Context.Users.Single(u => u.Login == Login);

            MainViewModel mvm = new MainViewModel
            {
                Login = user.Login,
                Accounts = Context.Accounts.Where(a => a.UserId == user.Id).ToList()
            };

            return View("Index", mvm);
        }

        public ActionResult ShowPassword(int id)
        {
            Account account = Context.Accounts.Single(a => a.Id == id);
            User user = Context.Users.Single(u => u.Id == account.UserId);

            string pin = Interaction.InputBox("Enter PIN to show password.",
               "Show password", "", 1, 1);

            if (!pin.Equals(user.Pin))
            {
                MainViewModel mvm = new MainViewModel
                {
                    Login = user.Login,
                    Accounts = Context.Accounts.Where(a => a.UserId == id).ToList()
                };

                MessageBox.Show("Invalid pin.", "Error");
                return RedirectToAction("Index", mvm);
            }

            ShowPasswordViewModel spvm = new ShowPasswordViewModel
            {
                UserLogin = user.Login,
                Title = account.Title,
                Login = account.Login,
                Email = account.Email,
                Password = account.Password

            };

            return View("ShowPassword", spvm);
        }

        //public ActionResult Edit(int id)
        //{
        //    Account account = Context.Accounts.Single(a => a.Id == id);
        //    User user = Context.Users.Single(u => u.Id == account.UserId);


        //}
    }
}