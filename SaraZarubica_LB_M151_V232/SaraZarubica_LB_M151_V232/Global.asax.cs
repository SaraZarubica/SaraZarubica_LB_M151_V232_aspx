using BusinessLayer.Repositories;
using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SaraZarubica_LB_M151_V232
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var dbContext = new DataContext();
            if (dbContext.Database.Exists())
            {
                if (dbContext.Users.Count() < 1)
                {
                    CreateDb(dbContext);
                }
            }
            else{
                CreateDb(dbContext);
            }
        }

        public void CreateDb(DataContext dbContext)
        {    
            Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
            CreateData(dbContext);
            
        }

        public void CreateData(DataContext dbContext)
        {
            UserRepository uRep = new UserRepository();
            uRep.Register("Admin", "admin1234", Roll.Admin);
            User admin = uRep.GetUserByUserName("Admin");

            Category katFahrzeug = new Category() { CategoryText = "Fahrzeug", UserId = admin.Id};
            dbContext.Categories.Add(katFahrzeug);
            dbContext.SaveChanges();

            Category katAllgemein = new Category() { CategoryText = "Allgemein", UserId = admin.Id };
            dbContext.Categories.Add(katAllgemein);
            dbContext.SaveChanges();

            Category katMathematik = new Category() { CategoryText = "Mathematik", UserId = admin.Id };
            dbContext.Categories.Add(katMathematik);
            dbContext.SaveChanges();

            Question q1 = new Question();
            Answer a1_1 = new Answer() {  AnswerText = "Luzern", UserId = admin.Id, Correctness = false};
            Answer a2_1 = new Answer() {AnswerText = "Zürich", UserId = admin.Id, Correctness = false};
            Answer a3_1 = new Answer() { AnswerText = "Bern", UserId = admin.Id, Correctness = true };
            Answer a4_1 = new Answer() { AnswerText = "Basel", UserId = admin.Id, Correctness = false };


            q1.CategoryId = katAllgemein.Id;
            q1.UserId = admin.Id;
            q1.QuestionText = "Was ist die Hauptstadt der Schweiz?";
            q1.Answers.AddRange(new List<Answer>() { a1_1, a2_1, a3_1, a4_1 });
            dbContext.Questions.Add(q1);
            dbContext.SaveChanges();

            Question q2 = new Question();
            Answer a1_2 = new Answer() { AnswerText = "Gelb", UserId = admin.Id, Correctness = false };
            Answer a2_2 = new Answer() { AnswerText = "Weiss", UserId = admin.Id, Correctness = false };
            Answer a3_2 = new Answer() { AnswerText = "Rot", UserId = admin.Id, Correctness = true };
            Answer a4_2 = new Answer() { AnswerText = "Schwarz", UserId = admin.Id, Correctness = false };


            q2.CategoryId = katAllgemein.Id;
            q2.UserId = admin.Id;
            q2.QuestionText = "Welche Farbe können Bienen nicht sehen?";
            q2.Answers.AddRange(new List<Answer>() { a1_2, a2_2, a3_2, a4_2 });
            dbContext.Questions.Add(q2);
            dbContext.SaveChanges();

            Question q3 = new Question();
            Answer a1_3 = new Answer() { AnswerText = "Bambi", UserId = admin.Id, Correctness = false };
            Answer a2_3 = new Answer() { AnswerText = "Höhle", UserId = admin.Id, Correctness = false };
            Answer a3_3 = new Answer() { AnswerText = "Einhorn", UserId = admin.Id, Correctness = true };
            Answer a4_3 = new Answer() { AnswerText = "Elch", UserId = admin.Id, Correctness = false };


            q3.CategoryId = katAllgemein.Id;
            q3.UserId = admin.Id;
            q3.QuestionText = "Passwort zum Schulzimmer?";
            q3.Answers.AddRange(new List<Answer>() { a1_3, a2_3, a3_3, a4_3 });
            dbContext.Questions.Add(q3);
            dbContext.SaveChanges();

            Question q4 = new Question();
            Answer a1_4 = new Answer() { AnswerText = "Bank", UserId = admin.Id, Correctness = false };
            Answer a2_4 = new Answer() { AnswerText = "Hund", UserId = admin.Id, Correctness = false };
            Answer a3_4 = new Answer() { AnswerText = "Huhn", UserId = admin.Id, Correctness = true };
            Answer a4_4 = new Answer() { AnswerText = "Maus", UserId = admin.Id, Correctness = false };


            q4.CategoryId = katAllgemein.Id;
            q4.UserId = admin.Id;
            q4.QuestionText = "Lied: Ich wollt ich wär ein..?";
            q4.Answers.AddRange(new List<Answer>() { a1_4, a2_4, a3_4, a4_4 });
            dbContext.Questions.Add(q4);
            dbContext.SaveChanges();

            Question q5 = new Question();
            Answer a1_5 = new Answer() { AnswerText = "Madonna", UserId = admin.Id, Correctness = false };
            Answer a2_5 = new Answer() { AnswerText = "Britney Spears", UserId = admin.Id, Correctness = false };
            Answer a3_5 = new Answer() { AnswerText = "Justin Bieber", UserId = admin.Id, Correctness = true };
            Answer a4_5 = new Answer() { AnswerText = "Austin Mahone", UserId = admin.Id, Correctness = false };


            q5.CategoryId = katAllgemein.Id;
            q5.UserId = admin.Id;
            q5.QuestionText = "Wer singt das Lied Baby?";
            q5.Answers.AddRange(new List<Answer>() { a1_5, a2_5, a3_5, a4_5 });
            dbContext.Questions.Add(q5);
            dbContext.SaveChanges();

            Question q6 = new Question();
            Answer a1_6 = new Answer() { AnswerText = "Dsds", UserId = admin.Id, Correctness = false };
            Answer a2_6 = new Answer() { AnswerText = "Hans und Petra", UserId = admin.Id, Correctness = false };
            Answer a3_6 = new Answer() { AnswerText = "Germanys Next Topmodel", UserId = admin.Id, Correctness = true };
            Answer a4_6 = new Answer() { AnswerText = "Sing", UserId = admin.Id, Correctness = false };


            q6.CategoryId = katAllgemein.Id;
            q6.UserId = admin.Id;
            q6.QuestionText = "Heidi Klum ist zu sehen in..?";
            q6.Answers.AddRange(new List<Answer>() { a1_6, a2_6, a3_6, a4_6 });
            dbContext.Questions.Add(q6);
            dbContext.SaveChanges();

            Question q7 = new Question();
            Answer a1_7 = new Answer() { AnswerText = "Fernsehn", UserId = admin.Id, Correctness = false };
            Answer a2_7 = new Answer() { AnswerText = "Elefanten", UserId = admin.Id, Correctness = false };
            Answer a3_7 = new Answer() { AnswerText = "Apfel", UserId = admin.Id, Correctness = true };
            Answer a4_7 = new Answer() { AnswerText = "ICT", UserId = admin.Id, Correctness = false };


            q7.CategoryId = katAllgemein.Id;
            q7.UserId = admin.Id;
            q7.QuestionText = "Bütschgi gehört zum?";
            q7.Answers.AddRange(new List<Answer>() { a1_7, a2_7, a3_7, a4_7 });
            dbContext.Questions.Add(q7);
            dbContext.SaveChanges();

            Question q8 = new Question();
            Answer a1_8 = new Answer() { AnswerText = "Octday", UserId = admin.Id, Correctness = false };
            Answer a2_8 = new Answer() { AnswerText = "Juneday", UserId = admin.Id, Correctness = false };
            Answer a3_8 = new Answer() { AnswerText = "Mayday", UserId = admin.Id, Correctness = true };
            Answer a4_8 = new Answer() { AnswerText = "Janday", UserId = admin.Id, Correctness = false };


            q8.CategoryId = katAllgemein.Id;
            q8.UserId = admin.Id;
            q8.QuestionText = "Not Signal im internationalen Funkverkehr?";
            q8.Answers.AddRange(new List<Answer>() { a1_8, a2_8, a3_8, a4_8 });
            dbContext.Questions.Add(q8);
            dbContext.SaveChanges();

            Question q9 = new Question();
            Answer a1_9 = new Answer() { AnswerText = "3 Geister", UserId = admin.Id, Correctness = false };
            Answer a2_9 = new Answer() { AnswerText = "5 Ziegen", UserId = admin.Id, Correctness = false };
            Answer a3_9 = new Answer() { AnswerText = "7 Zwerge", UserId = admin.Id, Correctness = true };
            Answer a4_9 = new Answer() { AnswerText = "17 Prinzen", UserId = admin.Id, Correctness = false };


            q9.CategoryId = katAllgemein.Id;
            q9.UserId = admin.Id;
            q9.QuestionText = "Schneewittchen und die ?";
            q9.Answers.AddRange(new List<Answer>() { a1_9, a2_9, a3_9, a4_9 });
            dbContext.Questions.Add(q9);
            dbContext.SaveChanges();

            Question q10 = new Question();
            Answer a1_10 = new Answer() { AnswerText = "Mathematik", UserId = admin.Id, Correctness = false };
            Answer a2_10 = new Answer() { AnswerText = "Wirtschaft", UserId = admin.Id, Correctness = false };
            Answer a3_10 = new Answer() { AnswerText = "Medizin", UserId = admin.Id, Correctness = true };
            Answer a4_10 = new Answer() { AnswerText = "Kunst", UserId = admin.Id, Correctness = false };


            q10.CategoryId = katAllgemein.Id;
            q10.UserId = admin.Id;
            q10.QuestionText = "Zu welchem Bereich gehört der Pathologe?";
            q10.Answers.AddRange(new List<Answer>() { a1_10, a2_10, a3_10, a4_10 });
            dbContext.Questions.Add(q10);
            dbContext.SaveChanges();
        }
    }
}