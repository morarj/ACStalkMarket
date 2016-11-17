namespace ACStalkMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateWeekModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Weeks", "TurnipSellingPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Weeks", "TurnipSellingPrice", c => c.Int());
        }
    }
}
