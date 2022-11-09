using Backend.Models;
using Backend.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Backend.Data
{
    public class DataContext:IdentityDbContext<User,IdentityRole, string>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Applications>().HasData(
             new Applications { Id = 1, FirstName = "test", LastName = "test", EducationLevel = 0, Email = "test@hotmail.com", Status = 0, CoverLetter = "", CV = "" },
             new Applications { Id = 2, FirstName = "test2", LastName = "test2", EducationLevel = Models.Enums.EducationLevel.Master, Email = "test2@hotmail.com", Status = Models.Enums.Status.Inselection, CoverLetter = "", CV="" },
             new Applications { Id = 3, FirstName = "test3", LastName = "test3", EducationLevel = 0, Email = "test3@hotmail.com", Status = 0, CoverLetter = "", CV="" },
             new Applications { Id = 4, FirstName = "novi", LastName = "prezime", EducationLevel = Models.Enums.EducationLevel.Master, Email = "novi@hotmail.com", Status = Models.Enums.Status.Inselection, CoverLetter = "", CV = "" }

            ); 
            modelBuilder.Entity<Selection>().HasData(
            new Selection { Id = 1, StartDate =new DateTime(2022, 2,1), EndDate = new DateTime(2022, 3, 1), Name="internship/1", Description="desc" },
            new Selection { Id = 2, StartDate = new DateTime(2022, 2, 1), EndDate = new DateTime(2022, 3, 1), Name = "internship/2", Description = "desc2" },
            new Selection { Id = 3, StartDate = new DateTime(2022, 2, 1), EndDate = new DateTime(2022, 3, 1), Name = "internship/3", Description = "desc3" }

            );
        }

        public DbSet<Applications> Applications { get; set; }
        public DbSet<Selection> Selections { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
