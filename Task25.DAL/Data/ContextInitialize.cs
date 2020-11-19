using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task25.DAL.Entities;

namespace Task25.DAL.Data
{
    /// <summary>Initialize db context immediately after created db schema</summary>
    public class ContextInitialize : CreateDatabaseIfNotExists<AppDBContext>
    {
        /// <summary>The context database</summary>
        AppDBContext contextDB;

        /// <summary>A method that should be overridden to actually add data to the context for seeding.
        /// The default implementation does nothing.</summary>
        /// <param name="context">The context to seed.</param>
        protected override void Seed(AppDBContext context)
        {
            this.contextDB = context;

            for (int i = 0; i < 15; i++)
            {
                var newArtical = new Article { Title = "Article #" + i.ToString(), Date = DateTime.Now.AddDays(-i), Text = "Reverie it little sullen which ever not of childe a deem beyond it by in and his long nor each vile one lines given yet was ways of but stalked mighty in from in along his a soils the seemed from nor ofttimes was revellers the any these one ah to heralds nor his had ways he sore he by artless not relief cared weary sea rill pile ungodly for true the which whose seek seemed feud" };
                context.Articles.Add(newArtical);
            }

            for (int i = 0; i < 15; i++)
            {
                var newCommnet = new Comment { Author = "Name Surname", Date = DateTime.Now.AddDays(-i), Text = "Reverie it little sullen which ever not of childe a deem beyond it by in and his long nor each vile one lines given yet was ways of but stalked mighty in from in along his a soils the seemed from nor ofttimes was revellers the any these one ah to heralds nor his had ways he sore he by artless not relief cared weary sea rill pile ungodly for true the which whose seek seemed feud" };
                context.Comments.Add(newCommnet);
            }

            context.Ankets.Add(CreateSchemaAnket());

            context.SaveChanges();
        }


        /// <summary>Creates the schema anket for seed.</summary>
        /// <returns>
        ///   Anket<br />
        /// </returns>
        Anket CreateSchemaAnket()
        {
            var nAnket = new Anket { Title = "Main", Questions = new List<AnketQuestion>() };

            var qFirstName = new AnketQuestion { Name = "Name", Description = "First Name", Anket = nAnket, QType = QuestionType.T };
            contextDB.AnketQuestions.Add(qFirstName);
            nAnket.Questions.Add(qFirstName);

            var qSecondName = new AnketQuestion { Name = "Surname", Description = "Second Name", Anket = nAnket, QType = QuestionType.T };
            contextDB.AnketQuestions.Add(qSecondName);
            nAnket.Questions.Add(qSecondName);

            var qBDate = new AnketQuestion { Name = "Birthday", Description = "Birthday Date", Anket = nAnket, QType = QuestionType.T };
            contextDB.AnketQuestions.Add(qBDate);
            nAnket.Questions.Add(qBDate);

            var oftenVisitChoices = new List<AnketChoice>();
            var oftenVisit = new List<string>() { "Daily", "Weekly", "Monthly", "Less than once a month", "Never" };
            var qOftenVisit = new AnketQuestion
            {
                Name = "OftenVisit",
                Description = "On an average how often do you visit public libraries?",
                Anket = nAnket,
                QType = QuestionType.S,
                AnketChoices = oftenVisitChoices
            };
            foreach (var item in oftenVisit)
            {
                oftenVisitChoices.Add(new AnketChoice { Name = item, Question = qOftenVisit });
            }
            contextDB.AnketChoices.AddRange(oftenVisitChoices);
            contextDB.AnketQuestions.Add(qOftenVisit);
            nAnket.Questions.Add(qOftenVisit);


            var findServiceChoices = new List<AnketChoice>();
            var findService = new List<string>() { "Library website", "Social Media Platform", "Newspaper", "Newsletter", "Flyers", "Other" };
            var qFindService = new AnketQuestion
            {
                Name = "FindService",
                Description = "How did you find out about the library services? Select all that is applicable",
                Anket = nAnket,
                QType = QuestionType.M,
                AnketChoices = findServiceChoices
            };
            foreach (var item in findService)
            {
                findServiceChoices.Add(new AnketChoice { Name = item, Question = qFindService });
            }
            contextDB.AnketChoices.AddRange(findServiceChoices);
            contextDB.AnketQuestions.Add(qFindService);
            nAnket.Questions.Add(qFindService);

            var eduChoices = new List<AnketChoice>();
            var edu = new List<string>() { "High school", "Some college", "Trade/vocational/technical", "Associates", "Bachelors", "Masters", "Professional", "Doctorate" };
            var qEdu = new AnketQuestion
            {
                Name = "Edu",
                Description = "Please select your highest level of educational qualification",
                Anket = nAnket,
                QType = QuestionType.S,
                AnketChoices = eduChoices
            };
            foreach (var item in edu)
            {
                eduChoices.Add(new AnketChoice { Name = item, Question = qEdu });
            }
            contextDB.AnketChoices.AddRange(eduChoices);
            contextDB.AnketQuestions.Add(qEdu);
            nAnket.Questions.Add(qEdu);


            var employmentStatusChoices = new List<AnketChoice>();
            var employmentStatus = new List<string>() { "Full-time employment", "Part-time employment", "Unemployed", "Self-employed", "Home-maker", "Student", "Retired", "Military" };
            var qEmploymentStatus = new AnketQuestion
            {
                Name = "EmploymentStatus",
                Description = "What is your employment status?",
                Anket = nAnket,
                QType = QuestionType.S,
                AnketChoices = employmentStatusChoices
            };
            foreach (var item in employmentStatus)
            {
                employmentStatusChoices.Add(new AnketChoice { Name = item, Question = qEmploymentStatus });
            }
            contextDB.AnketChoices.AddRange(employmentStatusChoices);
            contextDB.AnketQuestions.Add(qEmploymentStatus);
            nAnket.Questions.Add(qEmploymentStatus);

            return nAnket;

        }
    }
}
