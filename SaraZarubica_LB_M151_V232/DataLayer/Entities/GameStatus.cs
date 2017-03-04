using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataLayer.Entities
{
    public class GameStatus
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public bool Joker_5050 { get; set; }
        public DateTime? StartGame { get; set; }
        public DateTime? EndGame { get; set; }
        public DateTime? GameDate { get; set; }


        // Lazy loadig Properties
        public virtual User User { get; set; }
        public virtual List<AnswerAnswered> AnswersAnswered { get; set; }
    }
}