namespace ACStalkMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTownModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PeopleId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PeopleId, cascadeDelete: true)
                .Index(t => t.PeopleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Towns", "PeopleId", "dbo.People");
            DropIndex("dbo.Towns", new[] { "PeopleId" });
            DropTable("dbo.Towns");
        }
    }
}
