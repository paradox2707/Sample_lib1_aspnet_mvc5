namespace Task25.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTegAndJoinToArticle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tegs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TegArticles",
                c => new
                    {
                        Teg_Id = c.Int(nullable: false),
                        Article_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teg_Id, t.Article_Id })
                .ForeignKey("dbo.Tegs", t => t.Teg_Id, cascadeDelete: true)
                .ForeignKey("dbo.Articles", t => t.Article_Id, cascadeDelete: true)
                .Index(t => t.Teg_Id)
                .Index(t => t.Article_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TegArticles", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.TegArticles", "Teg_Id", "dbo.Tegs");
            DropIndex("dbo.TegArticles", new[] { "Article_Id" });
            DropIndex("dbo.TegArticles", new[] { "Teg_Id" });
            DropTable("dbo.TegArticles");
            DropTable("dbo.Tegs");
        }
    }
}
