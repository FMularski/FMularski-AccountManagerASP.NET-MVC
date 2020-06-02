using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AccountManager
{
    public class AccountManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AccountManagerContext() : base("name=AccountManager") { }
    }
}