namespace BoxOfCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class review : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReviewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Comment = c.String(nullable: false),
                        ReviewValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReviewModels");
        }
    }
}
