namespace ACStalkMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeekModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeekPatterns",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Weeks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PeopleId = c.Int(nullable: false),
                        TownId = c.Int(nullable: true),
                        WeekValuesId = c.Int(nullable: false),
                        WeekPatternId = c.Byte(nullable: false),
                        StartingDate = c.DateTime(nullable: false),
                        TurnipStartingPrice = c.Byte(nullable: false),
                        BellsInvestment = c.Int(nullable: false),
                        WeekActive = c.Boolean(nullable: false),
                        Profit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PeopleId, cascadeDelete: true)
                .ForeignKey("dbo.Towns", t => t.TownId)
                .ForeignKey("dbo.WeekPatterns", t => t.WeekPatternId, cascadeDelete: true)
                .ForeignKey("dbo.WeekValues", t => t.WeekValuesId, cascadeDelete: true)
                .Index(t => t.PeopleId)
                .Index(t => t.TownId)
                .Index(t => t.WeekValuesId)
                .Index(t => t.WeekPatternId);
            
            CreateTable(
                "dbo.WeekValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        monAM = c.Short(nullable: false),
                        monPM = c.Short(nullable: false),
                        tueAM = c.Short(nullable: false),
                        tuePM = c.Short(nullable: false),
                        wedAM = c.Short(nullable: false),
                        wedPM = c.Short(nullable: false),
                        thuAM = c.Short(nullable: false),
                        thuPM = c.Short(nullable: false),
                        friAM = c.Short(nullable: false),
                        friPM = c.Short(nullable: false),
                        satAM = c.Short(nullable: false),
                        satPM = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weeks", "WeekValuesId", "dbo.WeekValues");
            DropForeignKey("dbo.Weeks", "WeekPatternId", "dbo.WeekPatterns");
            DropForeignKey("dbo.Weeks", "TownId", "dbo.Towns");
            DropForeignKey("dbo.Weeks", "PeopleId", "dbo.People");
            DropIndex("dbo.Weeks", new[] { "WeekPatternId" });
            DropIndex("dbo.Weeks", new[] { "WeekValuesId" });
            DropIndex("dbo.Weeks", new[] { "TownId" });
            DropIndex("dbo.Weeks", new[] { "PeopleId" });
            DropTable("dbo.WeekValues");
            DropTable("dbo.Weeks");
            DropTable("dbo.WeekPatterns");
        }
    }
}
