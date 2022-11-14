using Backend.Models;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.Validators
{
    
    public class SelectionValidator : AbstractValidator<AddSelectionDto>
    {
        public SelectionValidator()
        {
            RuleFor(u => u.Name).NotNull().NotEmpty();
            RuleFor(u => u.Description).NotNull().NotEmpty();
            RuleFor(u => u.StartDate).NotEmpty().NotNull();
            RuleFor(u => u.EndDate).NotEmpty().NotNull().GreaterThan(u => u.StartDate);

        }
    }

    public class AppSelectionValidator : AbstractValidator<ApplicationToSelectionDto>
    {
        public AppSelectionValidator()
        {
            RuleFor(u => u.applicationId).NotEmpty().NotNull();
            RuleFor(u => u.selectionId).NotEmpty().NotNull();
        }
    }

    public class EditSelectionValidator : AbstractValidator<EditSelectionDto>
    {
        public EditSelectionValidator()
        {
            RuleFor(u => u.SelectionId).NotEmpty().NotNull();
            RuleFor(u => u.Name).NotEmpty().NotNull();
            RuleFor(u => u.StartDate).NotEmpty().NotNull();
            RuleFor(u => u.EndDate).NotEmpty().NotNull().GreaterThan(u=>u.StartDate);
            RuleFor(u => u.Description).NotEmpty().NotNull();

        }
    }
}
