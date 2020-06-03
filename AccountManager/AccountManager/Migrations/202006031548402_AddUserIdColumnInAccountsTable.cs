namespace AccountManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdColumnInAccountsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "UserId");
        }
    }
}
