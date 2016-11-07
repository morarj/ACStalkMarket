namespace ACStalkMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPeopleAndGender : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        GenderName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        BirthDate = c.DateTime(),
                        GenderId = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .Index(t => t.GenderId);
            
            AddColumn("dbo.AspNetUsers", "PeopleId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "PeopleId");
            AddForeignKey("dbo.AspNetUsers", "PeopleId", "dbo.People", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "PeopleId", "dbo.People");
            DropForeignKey("dbo.People", "GenderId", "dbo.Genders");
            DropIndex("dbo.AspNetUsers", new[] { "PeopleId" });
            DropIndex("dbo.People", new[] { "GenderId" });
            DropColumn("dbo.AspNetUsers", "PeopleId");
            DropTable("dbo.People");
            DropTable("dbo.Genders");
        }
    }
}
