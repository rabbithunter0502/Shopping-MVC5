namespace Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOldPricetoProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "OldPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "OldPrice");
        }
    }
}
