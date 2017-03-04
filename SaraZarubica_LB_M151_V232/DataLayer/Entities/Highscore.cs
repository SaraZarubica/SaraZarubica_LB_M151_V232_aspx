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
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public int Rank { get; set; }
        public int WeightedPoints { get; set; }
        public int Points { get; set; }
        public DateTime? GameDuration { get; set; }
        //kategorie

        // Lazy loadig Properties
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
       
    }
}