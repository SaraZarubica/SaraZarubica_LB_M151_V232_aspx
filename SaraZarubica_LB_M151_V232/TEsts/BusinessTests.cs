
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using System.Linq;
using BusinessLayer.Repositories;
using DataLayer.Entities;
using System.Collections.Generic;

namespace TEsts
{
    [TestClass]
    public class BusinessTests
    {
        private DataContext _dbContext;
        private CategoryRepository _catRep;
        private AnswerRepository _aRep;
        private QuestionRepository _qRep;
        private HighScoreRepository _hRep;
        private UserRepository _uRep;

        private DataContext DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new DataContext();
                }
                return _dbContext;
            }
        }

        private CategoryRepository CatRep
        {
            get
            {
                if (_catRep == null)
                {
                    _catRep = new CategoryRepository();
                }
                return _catRep;
            }
        }

        private AnswerRepository ARep
        {
            get
            {
                if (_aRep == null)
                {
                    _aRep = new AnswerRepository();
                }
                return _aRep;
            }
        }

        private QuestionRepository QRep
        {
            get
            {
                if (_qRep == null)
                {
                    _qRep = new QuestionRepository();
                }
                return _qRep;
            }
        }

        private HighScoreRepository HRep
        {
            get
            {
                if (_hRep == null)
                {
                    _hRep = new HighScoreRepository();
                }
                return _hRep;
            }
        }

        private UserRepository URep
        {
            get
            {
                if (_uRep == null)
                {
                    _uRep = new UserRepository();
                }
                return _uRep;
            }
        }

        [TestMethod]
        public void GetAllCategoriesTest()
        {
            int dbCatCount = DbContext.Categories.Count();
            var businessItems = CatRep.GetAllCategories();
            int businessCount = businessItems.Count();
            foreach (Category cat in DbContext.Categories)
            {
                Assert.IsTrue(businessItems.FirstOrDefault(x => x.CategoryText == cat.CategoryText
                && x.Id == cat.Id) != null);
            }

            Assert.AreEqual(dbCatCount, businessCount);
        }

        [TestMethod]
        public void CountQuestionFromCategoryTest()
        {
            var dbCategory = DbContext.Categories.FirstOrDefault();
            Assert.IsTrue(dbCategory != null);

            var countQuestion = CatRep.CountQuestionFromCategory(dbCategory.Id);
            var dbCountQuestion = DbContext.Questions.Where(x => x.CategoryId == dbCategory.Id).Count();

            Assert.AreEqual(dbCountQuestion, countQuestion);
            Assert.AreEqual(countQuestion, dbCategory.Questions.Count);
        }

        [TestMethod]
        public void getCategoryByIdTest()
        {
            var dbCategory = DbContext.Categories.FirstOrDefault();
            Assert.IsTrue(dbCategory != null);

            var category = CatRep.getCategoryById(dbCategory.Id);

            Assert.AreEqual(dbCategory.Id, category.Id);
            Assert.AreEqual(dbCategory.CategoryText, category.CategoryText);
        }

        [TestMethod]
        public void GetCategoriesByIdsTest()
        {
            List<int> dbCategorieIds = DbContext.Categories.Select(x => x.Id).ToList();
            if(dbCategorieIds.Count < 1)
            {
                throw new Exception("No Categories there to test");
            }


            var categories = CatRep.GetCategoriesByIds(dbCategorieIds);
            List<int> categorieIds = categories.Select(x => x.Id).ToList();

            Assert.IsTrue(dbCategorieIds.Count == categorieIds.Count);
            foreach(int id in dbCategorieIds)
            {
                Assert.IsTrue(categorieIds.Contains(id));
            }
        }

        [TestMethod]
        public void SetQuestionStatisticsOneUpTest()
        {
            var dbQuestion = DbContext.Questions.FirstOrDefault();
            Assert.IsTrue(dbQuestion != null);

            var questionCorectness = dbQuestion.CorrectCount;
            var questionAnswered = dbQuestion.AnsweredCount;
            var questionTrueOrFalse = true;

            QRep.SetQuestionStatisticsOneUp(questionTrueOrFalse, dbQuestion.Id);

            var question = QRep.getQuestionById(dbQuestion.Id);
            Assert.AreNotEqual(questionCorectness, question.CorrectCount);

            dbQuestion.CorrectCount = questionCorectness;
        }

        [TestMethod]
        public void GetQuestionByIdTest()
        {
            var dbQuestion = DbContext.Questions.FirstOrDefault();
            var dbQuestionId = dbQuestion.Id;
            Assert.IsTrue(dbQuestionId > 0);

            Question q = QRep.getQuestionById(dbQuestionId);

            Assert.AreEqual(dbQuestion.Id, q.Id);
            Assert.AreEqual(dbQuestion.QuestionText, q.QuestionText);
        }

        [TestMethod]
        public void GetCategoryTextByCategoryIdTest()
        {
            var dbQuestion = DbContext.Questions.FirstOrDefault();
            var dbQuestionCategoryId = dbQuestion.CategoryId;
            Assert.IsTrue(dbQuestionCategoryId > 0);

            Category dbC = DbContext.Categories.Find(dbQuestionCategoryId);
            Assert.IsTrue(dbC != null);
            var dbCText = dbC.CategoryText;

            var cText = QRep.getCategoryTextByCategoryId(dbQuestionCategoryId);

            Assert.AreEqual(dbCText, cText);

        }

        [TestMethod]
        public void checkAnswersFromQuestionTest()
        {
            var question = DbContext.Questions.FirstOrDefault();

            var answers = question.Answers;

            int correctAnswer = 0;
            int falseAnswer = 0;
            for (int i = 0; i < answers.Count; i++)
            {
                if (ARep.checkAnswer(answers[i].Id))
                {
                    correctAnswer++;
                }
                else
                {
                    falseAnswer++;
                }
            }

            Assert.IsTrue(correctAnswer == 1 && falseAnswer == 3);
        }

        [TestMethod]
        public void GetAnswersFromQuestionTest()
        {
            var dbQuestion = DbContext.Questions.FirstOrDefault();
            Assert.IsTrue(dbQuestion != null);
            var dbQuestionId = dbQuestion.Id;

            var dbAnswers = dbQuestion.Answers;

            var answers = ARep.getAnswersFromQuestion(dbQuestionId);

            Assert.AreEqual(dbAnswers.Count, answers.Count);
            Assert.AreEqual(dbAnswers[0].Id, answers[0].Id);
            Assert.AreEqual(dbAnswers[0].QuestionId, answers[0].QuestionId);

        }

        [TestMethod]
        public void GetAllHighscoresTest()
        {
            var dbHighscores = DbContext.Highscores.OrderByDescending(x => x.WeightedPoints).ToList();
            Assert.IsTrue(dbHighscores != null);

            var highscores = HRep.GetAllHighscores();

            Assert.AreEqual(dbHighscores.Count, highscores.Count);
            Assert.AreEqual(dbHighscores[0].Id, highscores[0].Id);
            Assert.AreEqual(dbHighscores[0].Name, highscores[0].Name);

        }

        [TestMethod]
        public void getHighscoreByIdTest()
        {
            var dbHighscore = DbContext.Highscores.FirstOrDefault();
            Assert.IsTrue(dbHighscore != null);

            var highscore = HRep.getHighscoreById(dbHighscore.Id);

            Assert.AreEqual(dbHighscore.Id, highscore.Id);
            Assert.AreEqual(dbHighscore.Name, highscore.Name);
            Assert.AreEqual(dbHighscore.Points, highscore.Points);

        }

        [TestMethod]
        public void GetAllQuestionsTest()
        {
            var dbUser = DbContext.Users.FirstOrDefault();
            Assert.IsTrue(dbUser != null);

            var dbQuestions = dbUser.Questions.ToList();

            var questions = URep.GetAllQuestions(dbUser.Id);

            Assert.AreEqual(dbQuestions[0].Id, questions[0].Id);
            Assert.AreEqual(dbQuestions[0].QuestionText, questions[0].QuestionText);

        }

        [TestMethod]
        public void SaveHighscoreTest()
        {
            var highscore = new Highscore();
            highscore.GameDuration = 5;
            highscore.MomentOfGame = DateTime.Now;
            highscore.PlayedCategories = DbContext.PlayedCategories.ToList();
            highscore.Name = "Sara_TestMethod_Highscore";
            highscore.Points = 30;

            HRep.Save(highscore);
            int id = highscore.Id;
            Assert.IsTrue(id > 0);
            Highscore dbHighscore = DbContext.Highscores.FirstOrDefault(x => x.Name == highscore.Name && x.Id == highscore.Id);
            Assert.IsTrue(dbHighscore != null);
            HRep.Delete(id);
            dbHighscore = DbContext.Highscores.FirstOrDefault(x => x.Name == highscore.Name && x.Id == highscore.Id);
            Assert.IsTrue(dbHighscore == null);
        }

        [TestMethod]
        public void SaveQuestion()
        {

            User admin = URep.GetUserByUserName("Admin");

            var question = new Question();
            Answer a1_3 = new Answer() { AnswerText = "Bambi", UserId = admin.Id, Correctness = false };
            Answer a2_3 = new Answer() { AnswerText = "Höhle", UserId = admin.Id, Correctness = false };
            Answer a3_3 = new Answer() { AnswerText = "Einhorn", UserId = admin.Id, Correctness = true };
            Answer a4_3 = new Answer() { AnswerText = "Elch", UserId = admin.Id, Correctness = false };


            question.CategoryId = CatRep.GetAllCategoriesFromUserId(admin.Id).FirstOrDefault().Id;
            question.UserId = admin.Id;
            question.QuestionText = "Passwort zum Schulzimmer?";
            question.Answers.AddRange(new List<Answer>() { a1_3, a2_3, a3_3, a4_3 });

            QRep.Save(question);
            int id = question.Id;
            Assert.IsTrue(id > 0);
            Question dbQuestion = DbContext.Questions.FirstOrDefault(x => x.QuestionText == question.QuestionText && x.Id == question.Id);
            Assert.IsTrue(dbQuestion != null);

            QRep.Delete(question.Id);
            dbQuestion = DbContext.Questions.FirstOrDefault(x => x.QuestionText == question.QuestionText && x.Id == question.Id);
            Assert.IsTrue(dbQuestion == null);
        }

        [TestMethod]
        public void SaveCategoryTest()
        {
            User admin = URep.GetUserByUserName("Admin");

            var category = new Category();
            category.CategoryText = "hallo";
            category.Questions = null;
            category.UserId = admin.Id;

            CatRep.Save(category);
            int id = category.Id;
            Assert.IsTrue(id > 0);
            Category dbCategory = DbContext.Categories.FirstOrDefault(x => x.CategoryText == category.CategoryText && x.Id == category.Id);
            Assert.IsTrue(dbCategory != null);
            CatRep.Delete(id);
            dbCategory = DbContext.Categories.FirstOrDefault(x => x.CategoryText == category.CategoryText && x.Id == category.Id);
            Assert.IsTrue(dbCategory == null);
        }
    }
}
