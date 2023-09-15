using CompoundInterestApi.Models;
using FluentValidation;

namespace CompoundInterestApi.Validators
{
    public class CompoundInterestValidator : AbstractValidator<CompoundInterest>
    {

        public CompoundInterestValidator()
        {
            // All validation operations were done with the fluentvalidation library in this class.
            RuleFor(model => model.Principal)
                .NotEmpty().WithMessage("Initial Amount cannot be empty.")
                .GreaterThan(0).WithMessage("Initial Amount must be greater than 0.");

            RuleFor(model => model.InterestRate)
                .NotEmpty().WithMessage("Interest Rate cannot be empty.")
                .GreaterThan(0).WithMessage("Interest Rate must be greater than 0.");

            RuleFor(model => model.Years)
                .NotEmpty().WithMessage("Number of Years cannot be empty.")
                .GreaterThan(0).WithMessage("Number of Years must be greater than 0.");
        }
    }
}
