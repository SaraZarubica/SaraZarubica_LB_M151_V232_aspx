
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

        private DataContext DbContext
        {
            get
            {
                if(_dbContext == null)
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
                    _catRep = new  CategoryRepository();
                }
                return _catRep;
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
                && x.Id == cat.Id ) != null);
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
    }
}
