using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataLayer.Entities
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string AnswerText { get; set; }
        public bool Correctness { get; set; }


       

        // Lazy loadig Properties
        public virtual Question Question { get; set; }
        public virtual User User { get; set; }

    }
}