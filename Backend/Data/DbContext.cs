using Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Backend.Data
{
    public class DataContext:IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Applications>().HasData(
             new Applications { Id = 1, FirstName = "test", LastName = "test", EducationLevel = 0, Email = "test@hotmail.com", Status = 0, CoverLetter = ""},
             new Applications { Id = 3, FirstName = "test3", LastName = "test3", EducationLevel = 0, Email = "test3@hotmail.com", Status = 0, CoverLetter = "" }

            ); ;
            modelBuilder.Entity<Selection>().HasData(
            new Selection { Id = 1, StartDate =new DateTime(2022, 2,1), EndDate = new DateTime(2022, 3, 1), Name="internship", Description="desc" }

            );
        }

        public DbSet<Applications> Applications { get; set; }
        public DbSet<Selection> Selections { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
