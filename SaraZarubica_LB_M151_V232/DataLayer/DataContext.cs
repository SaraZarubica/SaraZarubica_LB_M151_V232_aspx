using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DefaultConnection") { }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerAnswered> AnswersAnswered { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Highscore> Highscores { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PlayedCategories> PlayedCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}
