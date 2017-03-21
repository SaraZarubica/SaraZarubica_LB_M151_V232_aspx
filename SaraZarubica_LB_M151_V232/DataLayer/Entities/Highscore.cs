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
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int GameDuration { get; set; } // as sec
        public DateTime MomentOfGame { get; set; }
                                            

        public virtual int WeightedPoints
        {
            get
            {
                return Points / GameDuration;
            }
        }

        // Lazy loadig Properties
        public virtual Category Category { get; set; }
       
    }
}