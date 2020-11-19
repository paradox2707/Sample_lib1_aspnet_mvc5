using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task25.DAL.Entities;

namespace Task25.DAL.Data
{
    /// <summary>Connection to DB Sourse and create DB context</summary>
    public class AppDBContext : DbContext
    {
        static AppDBContext()
        {
            Database.SetInitializer<AppDBContext>(new CreateDatabaseIfNotExists<AppDBContext>());
            Database.SetInitializer(new ContextInitialize());
        }

        /// <summary>Initializes a new instance of the <see cref="AppDBContext" /> class.</summary>
        public AppDBContext() : base("Task25")
        {

        }
        /// <summary>Initializes a new instance of the <see cref="AppDBContext" /> class.</summary>
        public AppDBContext(string connectionString) : base(connectionString)
        {

        }

        /// <summary>Gets or sets the articles.</summary>
        /// <value>The articles.</value>
        public DbSet<Article> Articles { get; set; }
        /// <summary>Gets or sets the comments.</summary>
        /// <value>The comments.</value>
        public DbSet<Comment> Comments { get; set; }
        /// <summary>Gets or sets the ankets.</summary>
        /// <value>The ankets.</value>
        public DbSet<Anket> Ankets { get; set; }
        /// <summary>Gets or sets the anket responses.</summary>
        /// <value>The anket responses.</value>
        public DbSet<AnketResponse> AnketResponses { get; set; }
        /// <summary>Gets or sets the anket questions.</summary>
        /// <value>The anket questions.</value>
        public DbSet<AnketQuestion> AnketQuestions { get; set; }
        /// <summary>Gets or sets the anket choices.</summary>
        /// <value>The anket choices.</value>
        public DbSet<AnketChoice> AnketChoices { get; set; }
        /// <summary>Gets or sets the answers CheckBox.</summary>
        /// <value>The answers CheckBox.</value>
        public DbSet<AnswerCheckBox> AnswersCheckBox { get; set; }

        public DbSet<Teg> Tegs { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder
        //      .Entity<Article>()
        //      .HasMany(p => p.Tegs)
        //      .WithMany(t => t.Articles)
        //      .MapToStoredProcedures( s => 
        //        s.Insert(i => i.HasName("ArticleTegs_Insert")
        //           .LeftKeyParameter(a => a.Id, "Article_Id")
        //           .RightKeyParameter(t => t.Id, "Teg_Id"))
        //        .Delete(d => d.HasName("ArticleTegs_Delete")
        //           .LeftKeyParameter(a => a.Id, "Article_Id")
        //           .RightKeyParameter(t => t.Id, "Teg_Id")));
        //}
    }

}
