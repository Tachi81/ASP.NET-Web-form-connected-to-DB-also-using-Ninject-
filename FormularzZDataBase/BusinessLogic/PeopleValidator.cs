using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FormularzZDataBase.Models;
using FormularzZDataBase.Repository;

namespace FormularzZDataBase.BusinessLogic
{
    public class PeopleValidator : AbstractValidator<People>
    {
        public PeopleValidator()
        {
            RuleFor(x => x.Name).Empty().WithMessage("Enter your Name");
        }
    }
}