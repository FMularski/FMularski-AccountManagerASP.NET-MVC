using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountManager.Models
{
    public class ShowPasswordViewModel
    {
        public string UserLogin { get; set; }
        public string Login { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}