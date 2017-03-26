using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    
    public class QuestionRepository
    {
        DataContext dbContext;

        public QuestionRepository()
        {
            dbContext = new DataContext();
        }

        public List<Question> GetQuestionsFromCategories(List<int> catIds, List<int> playedQuestions)
        {
            List<Question> q = dbContext.Questions.Where(x =>
            catIds.Contains(x.CategoryId)  &&
            !playedQuestions.Contains(x.Id)).ToList();

            return q;
        }

        public int GetQuestionsSize(List<int> ids)
        {
            var questionsSize = dbContext.Questions.Where(x => ids.Contains(x.CategoryId)).Count();
            return questionsSize;
        }
        public List<Question> GetAllQuestionsFromUserId(int userId)
        {
            List<Question> q = dbContext.Questions.Where(x =>
            x.UserId == userId).ToList();

            return q;
        }

        public Question getQuestionById(int id)
        {
           return dbContext.Questions.Find(id);
        }

        public void Save(Question q)
        {
            if (q.Id < 1)
            {
                dbContext.Questions.Add(q);
            }
            else
            {
                Question dbQuestion = dbContext.Questions.Find(q.Id);
                dbContext.Entry(dbQuestion).CurrentValues.SetValues(q);
            }
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Question dbQuestion = dbContext.Questions.Where(x => x.Id ==id).Include(x=> x.Answers).FirstOrDefault();
            dbContext.Answers.RemoveRange(dbQuestion.Answers);
            dbContext.SaveChanges();
            dbContext.Questions.Remove(dbQuestion);
            dbContext.SaveChanges();
        }

        public void SetQuestionStatisticsOneUp(bool rightAnswered, int id)
        {
            Question question = dbContext.Questions.Find(id);
            if (rightAnswered)
            {
                question.CorrectCount += 1;
            }
            else
            {
                question.WrongCount += 1;
            }
            dbContext.SaveChanges();
        }

    }
    
}
