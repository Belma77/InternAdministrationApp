using Backend.Models;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.Validators
{
   
    public class UserValidator : AbstractValidator<AddEditorDto>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotNull().NotEmpty();
            RuleFor(u => u.LastName).NotNull().NotEmpty();
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(u => u.Password).NotNull().NotEmpty();

        }
    }
   
    public class LoginValidator : AbstractValidator<UserLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Username).NotEmpty().NotNull();
            RuleFor(u => u.Password).NotEmpty().NotNull();

        }
    }
    }
