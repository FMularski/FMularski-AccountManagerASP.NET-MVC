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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Account account = Context.Accounts.Single(a => a.Id == id);
            User user = Context.Users.Single(u => u.Id == account.UserId);

            string pin = Interaction.InputBox("Enter PIN to edit the account.",
               "Edit account", "", 1, 1);

            if (pin.Equals(user.Pin))
            {
                AccountFormViewModel afvm = new AccountFormViewModel
                {
                    Mode = "Edit",
                    AccountId = id,
                    UserLogin = user.Login,
                    Title = account.Title,
                    Login = account.Login,
                    Email = account.Email,
                    Password = account.Password
                };

                return View("AccountForm", afvm);
            }
            else
            {
                MainViewModel mvm = new MainViewModel
                {
                    Login = user.Login,
                    Accounts = Context.Accounts.Where(a => a.UserId == id).ToList()
                };

                MessageBox.Show("Invalid pin.", "Error");
                return RedirectToAction("Index", mvm);
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, string title, string login, string email, string password)
        {
            Account accountInDb = Context.Accounts.Single(a => a.Id == id);

            accountInDb.Title = title;
            accountInDb.Login = login;
            accountInDb.Email = email;
            accountInDb.Password = password;
            Context.SaveChanges();

            User user = Context.Users.Single(u => u.Id == accountInDb.UserId);

            MainViewModel mvm = new MainViewModel
            {
                Login = user.Login,
                Accounts = Context.Accounts.Where(a => a.UserId == user.Id).ToList()
            };

            return View("Index", mvm);
        }

        public ActionResult Delete(int id)
        {
            Account accountToDelete = Context.Accounts.Single(a => a.Id == id);
            User user = Context.Users.Single(u => u.Id == accountToDelete.UserId);

            string pin = Interaction.InputBox("Enter PIN to delete the account.",
              "Edit account", "", 1, 1);

            if (pin.Equals(user.Pin))
            {
                Context.Accounts.Remove(accountToDelete);
                Context.SaveChanges();
            }
            else
                MessageBox.Show("Invalid pin.", "Error");

            
            MainViewModel mvm = new MainViewModel
            {
                Login = user.Login,
                Accounts = Context.Accounts.Where(a => a.UserId == id).ToList()
            };

            return RedirectToAction("Index", mvm);
        }

        [HttpGet]
        public ActionResult Add()
        {
            NewAccountViewModel navm = new NewAccountViewModel { UserLogin = Login, Mode = "Add"};
            return View("NewAccountForm", navm);
        }

        [HttpPost]
        public ActionResult Add(string title, string login, string email, string password)
        {
            User user = Context.Users.Single(u => u.Login == Login);
            Account newAccount = new Account { Title = title, Login = login, Email = email, Password = password, UserId = user.Id };
            Context.Accounts.Add(newAccount);
            Context.SaveChanges();

            MainViewModel mvm = new MainViewModel
            {
                Login = user.Login,
                Accounts = Context.Accounts.Where(a => a.UserId == user.Id).ToList()
            };

            return RedirectToAction("Index", mvm);
        }
    }
}