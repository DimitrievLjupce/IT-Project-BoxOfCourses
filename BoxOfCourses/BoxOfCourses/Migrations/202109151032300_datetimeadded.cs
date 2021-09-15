namespace BoxOfCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimeadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReviewModels", "CurrentDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReviewModels", "CurrentDate");
        }
    }
}
