using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.UI.Xaml.Data;

namespace Make_It_Stick.Data
{
    internal class AppDbContext : DbContext
    {
        public const string ConnectionString = "server=localhost;user=root;password=;database=makeitstick";

        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString,
            ServerVersion.Parse("8.4.3"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quiz>().HasData(new Quiz { Id = 1, Name = "Test Quiz" });
            modelBuilder.Entity<Question>().HasData(new Question { Id = 1, Text = "Wat is de hoofdstad van Nederland?" });
            modelBuilder.Entity<Answer>().HasData(new Answer { Id = 1, Text = "Amsterdam" });
        }
    }
}
