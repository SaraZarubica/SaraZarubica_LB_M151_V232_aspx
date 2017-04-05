﻿
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using System.Linq;
using BusinessLayer.Repositories;
using DataLayer.Entities;

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
        public void CountQuestionFromCategory()
        {
            var dbCategory = DbContext.Categories.FirstOrDefault();
            Assert.IsTrue(dbCategory != null);

            var countQuestion = CatRep.CountQuestionFromCategory(dbCategory.Id);
            var dbCountQuestion = DbContext.Questions.Where(x => x.CategoryId == dbCategory.Id).Count();

            Assert.AreEqual(dbCountQuestion, countQuestion);
            Assert.AreEqual(countQuestion, dbCategory.Questions.Count);
        }

        [TestMethod]
        public void getCategoryById()
        {
            var dbCategory = DbContext.Categories.FirstOrDefault();
            Assert.IsTrue(dbCategory != null);

            var category = CatRep.getCategoryById(dbCategory.Id);

            Assert.AreEqual(dbCategory.Id, category.Id);
            Assert.AreEqual(dbCategory.CategoryText, category.CategoryText);
        }

        [TestMethod]
        public void SetQuestionStatisticsOneUp()
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
        public void checkAnswersFromQuestion()
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
        public void saveHighscore()
        {
            var dbHighscore = new Highscore();
            dbHighscore.GameDuration = 5;
            dbHighscore.MomentOfGame = DateTime.Now;
            dbHighscore.PlayedCategories = DbContext.PlayedCategories.ToList();
            dbHighscore.Name = "Sara";
            dbHighscore.Points = 30;
            Assert.IsTrue(dbHighscore != null);

            HRep.Save(dbHighscore);
            int id = dbHighscore.Id;

            HRep.Delete(id);

            Assert.IsTrue(dbHighscore == null);
        }
    }
}
