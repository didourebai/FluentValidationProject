using FluentValidation;
using FluentValidationProject.Models;

namespace FluentValidationProject.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeModel>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(0, 10).WithMessage("Please ensure that you have entered your name"); 
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Age).InclusiveBetween(18, 60);
            RuleFor(x => x.Address).SetValidator(new AddressValidator());
            RuleFor(x => x.Age).NotNull().When(x => x.Address != null);
            RuleForEach(x => x.AddressLines).NotNull()
                .Must(x => x.Length <= 10).WithMessage("No more than 10 addresses are allowed");
                ;
        }
    }
}
