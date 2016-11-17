namespace ACStalkMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTurnipSellingPriceToWeekModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weeks", "TurnipSellingPrice", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Weeks", "TurnipSellingPrice");
        }
    }
}
