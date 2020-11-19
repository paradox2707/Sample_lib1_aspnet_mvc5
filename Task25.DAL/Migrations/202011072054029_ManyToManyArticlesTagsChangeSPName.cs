namespace Task25.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyArticlesTagsChangeSPName : DbMigration
    {
        public override void Up()
        {
            RenameStoredProcedure(name: "dbo.ArticleTeg_Insert", newName: "ArticleTegs_Insert");
            RenameStoredProcedure(name: "dbo.ArticleTeg_Delete", newName: "ArticleTegs_Delete");
        }
        
        public override void Down()
        {
            RenameStoredProcedure(name: "dbo.ArticleTegs_Delete", newName: "ArticleTeg_Delete");
            RenameStoredProcedure(name: "dbo.ArticleTegs_Insert", newName: "ArticleTeg_Insert");
        }
    }
}
