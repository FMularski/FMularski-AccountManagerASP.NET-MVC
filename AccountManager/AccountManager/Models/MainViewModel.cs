using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountManager.Models
{
    public class MainViewModel
    {
        public string Login { get; set; }
        public List<Account> Accounts { get; set; }
    }
}