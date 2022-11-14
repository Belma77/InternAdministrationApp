using Backend.Models;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.Validators
{
   
    public class SelectionCommentValidator : AbstractValidator<AddSelectionComment>
    {
        public SelectionCommentValidator()
        {
            RuleFor(u => u.SelectionId).NotNull();
            RuleFor(u => u.Comment).NotNull().NotEmpty();

        }
    }

    public class ApplicationCommentValidator : AbstractValidator<AddAppComment>
    {
        public ApplicationCommentValidator()
        {
            RuleFor(u => u.ApplicationId).NotNull();
            RuleFor(u => u.Comment).NotNull().NotEmpty();

        }
    }
    
}
