using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class AnswerRepository
    {
        DataContext dbContext;

        public AnswerRepository()
        {
            dbContext = new DataContext();
        }

        public void SaveAnswer(Answer a)
        {
            if(a.Id > 0)
            {
                Answer dbAnswer = dbContext.Answers.Find(a.Id);
                dbContext.Entry(dbAnswer).CurrentValues.SetValues(a);
            }
            else
            {
                dbContext.Answers.Add(a);
            }
            dbContext.SaveChanges();
           
        }
        public List<Answer> getAnswersFromQuestion(int qId)
        {
            List<Answer> answers = dbContext.Answers.Where(x => x.QuestionId == qId).ToList();
            return answers;
        }
        public bool checkAnswer(int id)
        {
           Answer answer = dbContext.Answers.Find(id);
           return answer.Correctness;
        }

        public void Save(List<Answer> listAnswer)
        {
            foreach(var a in listAnswer)
            {
                SaveAnswer(a);
            }
        }

     
    }
}
