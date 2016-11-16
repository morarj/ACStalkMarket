namespace ACStalkMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateWeekPatterns : DbMigration
    {
        public override void Up()
        {
            
            Sql("INSERT INTO WEEKPATTERNS (Id, Name) VALUES (1, 'Declining')");
            Sql("INSERT INTO WEEKPATTERNS (Id, Name) VALUES (2, 'Low Spike')");
            Sql("INSERT INTO WEEKPATTERNS (Id, Name) VALUES (3, 'High Spike')");
            Sql("INSERT INTO WEEKPATTERNS (Id, Name) VALUES (4, 'Random')");
           
        }
        
        public override void Down()
        {
            
        }
    }
}
