using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountManager.Models
{
    public class AccountFormViewModel
    {
        public string Mode { get; set; }
        public string UserLogin { get; set; }
        public int AccountId { get; set; }
        public string Login { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}