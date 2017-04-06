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
            List<int> catIds = h.PlayedCategories.Select(x => x.CategoryId).ToList();
            List<PlayedCategories> doubleItems = dbContext.PlayedCategories
                .Where(x => catIds.Contains(x.CategoryId) && x.HighScoreId == h.Id).ToList();

            if (doubleItems.Count() > 1)
            {
                for (int i = 0; i < doubleItems.Count; i++)
                {
                    var doubleItem = doubleItems[i];
                    if (doubleItems.Where(x => x.CategoryId ==
                    doubleItem.CategoryId && x.HighScoreId == doubleItem.HighScoreId).Count() > 1)
                    {
                        dbContext.PlayedCategories.Remove(doubleItem);
                        doubleItems.RemoveAt(i);
                    }
                }
            }
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Highscore dbHighscore = dbContext.Highscores.Where(x => x.Id == id).FirstOrDefault();
            RemovePlayedCategories(dbHighscore.PlayedCategories);
            dbContext.Highscores.Remove(dbHighscore);
            dbContext.SaveChanges();
        }

        public List<Highscore> GetAllHighscores()
        {
            List<Highscore> hs = dbContext.Highscores.OrderByDescending(x => x.WeightedPoints).ToList();
            return hs;
        }

        public void RemovePlayedCategories(List<PlayedCategories> playedC)
        {
            while (playedC.Count > 0)
            {
                dbContext.PlayedCategories.Remove(playedC[0]);
            }
            dbContext.SaveChanges();
        }
    }
}
