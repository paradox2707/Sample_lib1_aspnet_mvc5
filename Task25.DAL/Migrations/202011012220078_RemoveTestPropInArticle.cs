namespace Task25.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTestPropInArticle : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Articles", "TestMigration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "TestMigration", c => c.String());
        }
    }
}
