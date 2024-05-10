namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Footers",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MenuGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        URL = c.String(nullable: false, maxLength: 250),
                        DisplayOrder = c.Int(),
                        GropuID = c.Int(nullable: false),
                        Taget = c.String(maxLength: 50),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuGroups", t => t.GropuID, cascadeDelete: true)
                .Index(t => t.GropuID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 250),
                        CustomerAddress = c.String(nullable: false, maxLength: 256),
                        CustomerPhoneNumber = c.String(nullable: false, maxLength: 256),
                        CustomerEmail = c.String(nullable: false, maxLength: 256),
                        CustomerMessage = c.String(nullable: false, maxLength: 256),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        PaymentMethod = c.String(),
                        PaymentStatuss = c.String(),
                        Statuss = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OderDetails",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256),
                        CategoryID = c.Int(nullable: false),
                        Image = c.String(maxLength: 256),
                        MoreImage = c.String(storeType: "xml"),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(precision: 18, scale: 2),
                        Warranty = c.Int(),
                        Description = c.String(maxLength: 500),
                        Content = c.String(),
                        HomeFlag = c.Boolean(),
                        HotFlag = c.Boolean(),
                        ViewCount = c.Int(),
                        Tags = c.String(),
                        Quantity = c.Int(nullable: false),
                        Createdate = c.DateTime(),
                        CreareBy = c.String(maxLength: 256),
                        UpdateBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                        MetakeyWord = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategoryes", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductCategoryes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Alias = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 500),
                        ParentID = c.Int(),
                        DisplayOrder = c.Int(),
                        Image = c.String(maxLength: 256),
                        HomeFlag = c.Boolean(),
                        Createdate = c.DateTime(),
                        CreareBy = c.String(maxLength: 256),
                        UpdateBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                        MetakeyWord = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.TagID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(maxLength: 50),
                        Type = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.ProductTags", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.ProductCategoryes");
            DropForeignKey("dbo.OderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Menus", "GropuID", "dbo.MenuGroups");
            DropIndex("dbo.ProductTags", new[] { "TagID" });
            DropIndex("dbo.ProductTags", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.OderDetails", new[] { "ProductID" });
            DropIndex("dbo.OderDetails", new[] { "OrderID" });
            DropIndex("dbo.Menus", new[] { "GropuID" });
            DropTable("dbo.Tags");
            DropTable("dbo.ProductTags");
            DropTable("dbo.ProductCategoryes");
            DropTable("dbo.Products");
            DropTable("dbo.OderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Menus");
            DropTable("dbo.MenuGroups");
            DropTable("dbo.Footers");
        }
    }
}
