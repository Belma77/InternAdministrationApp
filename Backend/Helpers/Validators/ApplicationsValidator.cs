using Backend.Models;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.Validators
{
    public class ApplicationsValidator : AbstractValidator<AddApplicationDto>
    {
        public ApplicationsValidator()
        {
            RuleFor(u => u.FirstName).NotNull().NotEmpty();
            RuleFor(u => u.LastName).NotNull().NotEmpty();
            RuleFor(u => u.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(u => u.CoverLetter).NotNull().NotEmpty();
            RuleFor(u => u.CV).NotNull().NotEmpty();
            RuleFor(u => u.EducationLevel).NotNull().NotEmpty();

        }
    }
    
    public class AppStatusValidator : AbstractValidator<AppUpdateStatus>
    {
        public AppStatusValidator()
        {
            RuleFor(u => u.ApplicationId).NotEmpty().NotNull();
            RuleFor(u => u.Status).NotEmpty().NotNull();
        }
    }
    
   
}
