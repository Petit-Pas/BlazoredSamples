using FluentValidation;

namespace BasicExample.Models
{
    public class Address
    {
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
    }

    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.StreetName)
                .NotEmpty();
            RuleFor(x => x.StreetNumber)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}