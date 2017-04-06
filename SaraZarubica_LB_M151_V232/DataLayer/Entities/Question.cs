using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataLayer.Entities
{
    public class Question
    {
        public Question()
        {
            Answers = new List<Answer>();
        }
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string QuestionText { get; set; }
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public virtual int AnsweredCount
        {
            get
            {
                return this.WrongCount + this.CorrectCount;
            }
        }

        // Lazy loadig Properties
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Answer> Answers { get; set; }
    }
}