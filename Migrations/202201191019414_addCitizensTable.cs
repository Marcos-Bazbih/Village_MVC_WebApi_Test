namespace Village_MVC_WebApi_Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCitizensTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citizens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        FatherName = c.String(),
                        Gender = c.String(),
                        IsBornInVillage = c.Boolean(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Citizens");
        }
    }
}
