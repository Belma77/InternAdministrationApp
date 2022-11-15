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

        public DbSet<Applications> Applications { get; set; }
        public DbSet<Selection> Selections { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            DataSeeding.SeedSelections(builder);
            DataSeeding.SeedApplications(builder);
            DataSeeding.SeedUsers(builder);
            DataSeeding.SeedUserRoles(builder);
            DataSeeding.SeedRoles(builder);
        }
        
    }
}
