using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<RentalDetailDto>
    {
        public RentalValidator()
        {
            RuleFor(p => p.CustomerFirstName).NotEmpty();
            RuleFor(p => p.CustomerLastName).NotEmpty();
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p => p.CarName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
