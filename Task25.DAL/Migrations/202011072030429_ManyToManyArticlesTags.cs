namespace Task25.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyArticlesTags : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TegArticles", newName: "ArticleTegs");
            DropPrimaryKey("dbo.ArticleTegs");
            AddPrimaryKey("dbo.ArticleTegs", new[] { "Article_Id", "Teg_Id" });
            CreateStoredProcedure(
                "dbo.ArticleTeg_Insert",
                p => new
                    {
                        Article_Id = p.Int(),
                        Teg_Id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[ArticleTegs]([Article_Id], [Teg_Id])
                      VALUES (@Article_Id, @Teg_Id)"
            );
            
            CreateStoredProcedure(
                "dbo.ArticleTeg_Delete",
                p => new
                    {
                        Article_Id = p.Int(),
                        Teg_Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[ArticleTegs]
                      WHERE (([Article_Id] = @Article_Id) AND ([Teg_Id] = @Teg_Id))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.ArticleTeg_Delete");
            DropStoredProcedure("dbo.ArticleTeg_Insert");
            DropPrimaryKey("dbo.ArticleTegs");
            AddPrimaryKey("dbo.ArticleTegs", new[] { "Teg_Id", "Article_Id" });
            RenameTable(name: "dbo.ArticleTegs", newName: "TegArticles");
        }
    }
}
