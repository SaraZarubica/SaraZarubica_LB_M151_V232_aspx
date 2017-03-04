using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class AnswerAnswered
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [ForeignKey("GameStatus")]
        public int GameStatusId { get; set; }
        public bool Correctness { get; set; }

        // Lazy loadig Properties
        public virtual Question Question { get; set; }
        public virtual GameStatus GameStatus { get; set; }
    }
}
