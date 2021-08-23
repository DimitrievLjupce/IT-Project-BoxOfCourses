namespace BoxOfCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LanguagesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "LanguageId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "LanguageId");
            DropTable("dbo.Languages");
        }
    }
}
