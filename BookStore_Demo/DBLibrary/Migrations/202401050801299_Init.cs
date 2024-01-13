namespace DBLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false),
                        Age = c.String(),
                        Telephone = c.String(nullable: false),
                        IdentityID = c.String(maxLength: 18),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookCoverUrl = c.String(),
                        BookTypeID = c.Int(nullable: false),
                        BookTag = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookTypes", t => t.BookTypeID, cascadeDelete: true)
                .Index(t => t.BookTypeID);
            
            CreateTable(
                "dbo.BookTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false),
                        Age = c.String(),
                        Telephone = c.String(),
                        IdentityID = c.String(maxLength: 18),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderID = c.Long(nullable: false),
                        Address = c.String(nullable: false),
                        BookID = c.String(),
                        Num = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        CustomID = c.Int(nullable: false),
                        Custom_Telephone = c.String(nullable: false),
                        OrderTime = c.DateTime(),
                        ClearOrNot = c.Boolean(),
                        ReceiptOrNot = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminId = c.Int(nullable: false),
                        BookId = c.String(),
                        Num = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        PurchaseTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "BookTypeID", "dbo.BookTypes");
            DropIndex("dbo.Books", new[] { "BookTypeID" });
            DropTable("dbo.Purchases");
            DropTable("dbo.Orders");
            DropTable("dbo.Customs");
            DropTable("dbo.BookTypes");
            DropTable("dbo.Books");
            DropTable("dbo.Admins");
        }
    }
}
