namespace Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Again : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(unicode: false),
                        CategoryDescription = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(unicode: false),
                        UnitPrice = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Image = c.String(unicode: false),
                        CreatedAt = c.Long(nullable: false),
                        UpdatedAt = c.Long(nullable: false),
                        DeletedAt = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ProductName = c.String(unicode: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.OrderId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        PaymentTypeId = c.Int(nullable: false),
                        ShipName = c.String(unicode: false),
                        ShipAddress = c.String(unicode: false),
                        ShipPhone = c.String(unicode: false),
                        TotalPrice = c.Double(nullable: false),
                        CreateAt = c.Long(nullable: false),
                        UpdateAt = c.Long(nullable: false),
                        DeleteAt = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
