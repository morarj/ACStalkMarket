namespace ACStalkMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenders : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT GENDERS ON");
            Sql("INSERT INTO GENDERS (Id, GenderName) VALUES (1, 'Male')");
            Sql("INSERT INTO GENDERS (Id, GenderName) VALUES (2, 'Female')");
            Sql("INSERT INTO GENDERS (Id, GenderName) VALUES (3, 'Other')");
            Sql("SET IDENTITY_INSERT GENDERS OFF");
        }
        
        public override void Down()
        {
        }
    }
}
