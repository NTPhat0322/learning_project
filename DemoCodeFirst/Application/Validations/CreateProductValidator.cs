using DemoCodeFirst.Api.DTOs;
using FluentValidation;

namespace DemoCodeFirst.Application.Validations
{
    public class CreateProductValidator : AbstractValidator<CreateProductRequestDTO>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price must be non-negative");
            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity must be non-negative");
        }
    }
}
