using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class HighScoreRepository
    {
         
        DataContext dbContext;

        public HighScoreRepository()
        {
            dbContext = new DataContext();
        }

        public void SetHighScore(Highscore score)
        {
            dbContext.Highscores.Add(score);
        }

        public Highscore getHighscoreById(int id)
        {
            return dbContext.Highscores.Find(id);
        }
        public void Save(Highscore h)
        {
            if (h.Id > 0)
            {
                Highscore dbHighscore = dbContext.Highscores.Find(h.Id);
                dbContext.Entry(dbHighscore).CurrentValues.SetValues(h);
            }
            else
            {
                dbContext.Highscores.Add(h);
            }
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Highscore dbHighscore = dbContext.Highscores.Where(x => x.Id == id).FirstOrDefault();
            dbContext.Highscores.Remove(dbHighscore);
            dbContext.SaveChanges();
        }

        public List<Highscore> GetAllHighscores()
        {
            List<Highscore> hs = dbContext.Highscores.OrderBy(x => x.WeightedPoints).ToList();
            return hs;
        }

    }
}
