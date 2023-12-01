using FluentValidation;

namespace BasicExample.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; } = new Address();
    }

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleSet("Names", () =>
            {
                RuleFor(x => x.FirstName)
                    .NotEmpty();
                RuleFor(x => x.LastName)
                    .NotEmpty();
            });

            RuleFor(x => x.Age)
                .NotEmpty()
                .ExclusiveBetween(0, 150);

            RuleFor(x => x.Address)
                .SetValidator(new AddressValidator());
        }
    }
}
