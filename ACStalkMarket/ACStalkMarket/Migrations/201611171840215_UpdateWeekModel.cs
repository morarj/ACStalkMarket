namespace ACStalkMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateWeekModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weeks", "SellingDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Weeks", "SellingDate");
        }
    }
}
