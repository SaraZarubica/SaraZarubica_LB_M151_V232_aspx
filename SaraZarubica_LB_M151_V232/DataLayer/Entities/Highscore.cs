using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataLayer.Entities
{
    public class Highscore
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int GameDuration { get; set; } // as sec
        public DateTime MomentOfGame { get; set; }

        private double weightedPoints;
        public double WeightedPoints 
        {
            get
            {
                return weightedPoints;
            }
            set
            {
                weightedPoints = ((double)Points) / ((double)GameDuration);
            }
        }

        // Lazy loadig Properties
        public virtual List<PlayedCategories> PlayedCategories { get; set; }
    }
}