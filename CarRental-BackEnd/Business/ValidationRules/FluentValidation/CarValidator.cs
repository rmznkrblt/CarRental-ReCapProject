using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.DailyPrice > 0);
            RuleFor(p => p.Description.Length > 2);
        }
    }
}
