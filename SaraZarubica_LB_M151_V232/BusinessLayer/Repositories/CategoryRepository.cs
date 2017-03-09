using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class CategoryRepository
    {
        DataContext dbContext;

        public CategoryRepository()
        {
            dbContext = new DataContext();
        }

        public List<Category> GetAllCategories()
        {
           return dbContext.Categories.ToList();
        }

        public Category getCategoryById(int id)
        {
            return dbContext.Categories.Find(id);
        }

        public int CountQuestionFromCategory(int id)
        {
            return dbContext.Questions.Where(x => x.CategoryId == id).Count();
        }
        public void Save(Category c)
        {
            if (c.Id < 1)
            {
                dbContext.Categories.Add(c);
            }
            else
            {
                Category dbCategory = dbContext.Categories.Find(c.Id);
                dbContext.Entry(dbCategory).CurrentValues.SetValues(c);
            }
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Category dbCategory = dbContext.Categories.Where(x => x.Id == id).FirstOrDefault();
            dbContext.Categories.Remove(dbCategory);
            dbContext.SaveChanges();
        }

        public List<Category> GetAllCategoriesFromUserId(int userId)
        {
            List<Category> c = dbContext.Categories.Where(x =>
            x.UserId == userId).ToList();

            return c;
        }
    }
}
