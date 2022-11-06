using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Backend.Areas.Identity.Data;
using Backend.Models;
using Backend.Models.Enums;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using Backend.Services.ApplicationService;
using Backend.Repository.AppRepo;
using AutoMapper;
using Backend.Repository.SelectionRepo;
using Backend.Services.SelectionService;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddAutoMapper(typeof(Program).Assembly);

        // Add services to the container.
        builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DataContext>();
        builder.Services.AddScoped<IApplicationService, ApplicationService>();
        builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
        builder.Services.AddScoped<ISelectionService, SelectionService>();
        
        builder.Services.AddScoped<ISelectionRepository, SelectionRepository>();

        //builder.Services.AddScoped<IMapper, Mapper>();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.User.AllowedUserNameCharacters = null;
            //options.Password.RequiredUniqueChars = 1;

            // Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;


            // User settings.
            options.User.AllowedUserNameCharacters = null;
            options.User.AllowedUserNameCharacters = "";



            //options.User.RequireUniqueEmail = false;
        });
        var app = builder.Build();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
        
        
    }
}

