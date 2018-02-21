using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FormularzZDataBase.Models;

namespace FormularzZDataBase.BusinessLogic
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.PostCode).Matches("\\d\\d-\\d\\d\\d").WithMessage("Enter correct post code");
        }
    }
}