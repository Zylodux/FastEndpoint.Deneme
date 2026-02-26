using FastEndpoint.Deneme.Test;
using FastEndpoints;
using FluentValidation;

namespace FastEndpoint.Deneme.TestFastendpoint
{
    public class TestValidator : Validator<Request>
    {
        public TestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("your name is required!")
                .MinimumLength(5)
                .WithMessage("your name is too short!");

            RuleFor(x => x.Age)
                .NotEmpty()
                .WithMessage("we need your age!")
                .GreaterThan(18)
                .WithMessage("you are not legal yet!");
        }
    }
}
