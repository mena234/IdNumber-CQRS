using FluentValidation;
using IdNumber.Application.Queries;
using Salary.API.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdNumber.Application.Validations
{
    public class createIdnumberCommandValidator : AbstractValidator<idNumberViewModel>
    {
        public createIdnumberCommandValidator()
        {
            RuleFor(command => command.salary).LessThan(10000).NotEmpty().WithMessage("The Salary Must be less than 10000");
        }
    }
}
