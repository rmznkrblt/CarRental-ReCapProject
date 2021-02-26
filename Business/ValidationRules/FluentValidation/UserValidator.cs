using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Email).EmailAddress();
            RuleFor(m => m.Password)
                .NotNull().WithMessage("Please enter your password");
        }
    }
}
