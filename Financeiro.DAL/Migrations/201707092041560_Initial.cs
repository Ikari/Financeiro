namespace Financeiro.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        BankId = c.Int(nullable: false),
                        AccountActivity = c.Boolean(nullable: false),
                        Owner_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Owner_UserId)
                .Index(t => t.BankId)
                .Index(t => t.Owner_UserId);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        BankId = c.Int(nullable: false, identity: true),
                        BankNumber = c.String(),
                        BankName = c.String(),
                        BankActivity = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BankId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserActivity = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Ammount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        AccountId = c.Int(nullable: false),
                        Regularity = c.Int(),
                        Regularity1 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "Owner_UserId", "dbo.Users");
            DropForeignKey("dbo.Accounts", "BankId", "dbo.Banks");
            DropIndex("dbo.Transactions", new[] { "AccountId" });
            DropIndex("dbo.Accounts", new[] { "Owner_UserId" });
            DropIndex("dbo.Accounts", new[] { "BankId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Users");
            DropTable("dbo.Banks");
            DropTable("dbo.Accounts");
        }
    }
}
