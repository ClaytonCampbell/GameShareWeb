namespace GameShare.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserConsole", "InventoryId", "dbo.Inventory");
            AddForeignKey("dbo.UserConsole", "InventoryId", "dbo.Inventory", "InventoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserConsole", "InventoryId", "dbo.Inventory");
            AddForeignKey("dbo.UserConsole", "InventoryId", "dbo.Inventory", "InventoryId");
        }
    }
}
