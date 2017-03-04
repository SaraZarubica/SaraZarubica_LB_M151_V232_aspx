using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataLayer.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string CategoryText { get; set; }

        // Lazy Loading
        public virtual List<Question> Questions { get; set; }
        public virtual User User { get; set; }
    }
}