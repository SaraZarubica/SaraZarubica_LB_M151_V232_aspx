using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class PlayedCategories
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("HighScore")]
        public int HighScoreId { get; set; }
        public int CategoryId { get; set; }

        // virtuals
        public Highscore HighScore { get; set; }
    }
}
