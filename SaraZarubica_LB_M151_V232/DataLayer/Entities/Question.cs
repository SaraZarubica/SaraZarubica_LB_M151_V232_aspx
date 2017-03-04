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
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string QuestionText { get; set; }
  
        
        // Lazy loadig Properties
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Answer> Answers { get; set; }
    }
}