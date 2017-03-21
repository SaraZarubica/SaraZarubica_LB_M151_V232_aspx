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

        public void Delete(int id)
        {
            Highscore dbHighscore = dbContext.Highscores.Where(x => x.Id == id).FirstOrDefault();
            dbContext.Highscores.Remove(dbHighscore);
            dbContext.SaveChanges();
        }

    }
}
