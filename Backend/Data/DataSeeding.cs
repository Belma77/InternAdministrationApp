using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Backend.Data
{
    public static class DataSeeding
    {
        
        public static void SeedUsers(ModelBuilder builder)
        {
            User user = new User()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            passwordHasher.HashPassword(user, "Admin*123");
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin*123");
            builder.Entity<User>().HasData(user);
        }
        public static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Editor", ConcurrencyStamp = "2", NormalizedName = "Editor" }
                );
        }
        public static void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }
        public static void SeedApplications(ModelBuilder builder)
        {
            builder.Entity<Applications>().HasData(
            new Applications { Id = 1, FirstName = "test", LastName = "test", EducationLevel = 0, Email = "test@hotmail.com", Status = 0, CoverLetter = "", CV = "" },
            new Applications { Id = 2, FirstName = "test2", LastName = "test2", EducationLevel = Models.Enums.EducationLevelEnum.Master, Email = "test2@hotmail.com", Status = Models.Enums.StatusEnum.Inselection, CoverLetter = "", CV = "" },
            new Applications { Id = 3, FirstName = "test3", LastName = "test3", EducationLevel = 0, Email = "test3@hotmail.com", Status = 0, CoverLetter = "", CV = "" },
            new Applications { Id = 4, FirstName = "novi", LastName = "prezime", EducationLevel = Models.Enums.EducationLevelEnum.Master, Email = "novi@hotmail.com", Status = Models.Enums.StatusEnum.Inselection, CoverLetter = "", CV = "" }
           );
        }
        public static void SeedSelections(ModelBuilder builder)
        {
            builder.Entity<Selection>().HasData(
           new Selection { Id = 1, StartDate = new DateTime(2022, 3, 10), EndDate = new DateTime(2022, 5, 10), Name = "JAP Development", Description = "desc" },
           new Selection { Id = 2, StartDate = new DateTime(2022, 2, 1), EndDate = new DateTime(2022, 3, 1), Name = "JAP QA", Description = "desc2" },
           new Selection { Id = 3, StartDate = new DateTime(2022, 3, 20), EndDate = new DateTime(2022, 6, 20), Name = "JAP Devops", Description = "desc3" }
           );
        }
    }
}
