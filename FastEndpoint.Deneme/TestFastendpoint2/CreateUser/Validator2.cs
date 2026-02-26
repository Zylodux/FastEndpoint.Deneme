using FastEndpoints;
using FluentValidation;


namespace FastEndpoint.Deneme.TestFastendpoint2.CreateUser
{
    public class Validator2 : Validator<Request2>
    {
        public Validator2()
        {
            RuleFor(x => x.Name)
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
