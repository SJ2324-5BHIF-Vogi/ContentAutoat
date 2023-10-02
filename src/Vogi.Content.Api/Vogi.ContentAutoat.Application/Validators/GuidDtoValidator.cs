using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Domain.Dtos.Mediator.Base;

namespace Vogi.ContentAutoat.Application.Validators
{
    public class GuidDtoValidator:AbstractValidator<GuidDto>
    {
        public GuidDtoValidator()
        {
            RuleFor(x => x.guid)
                .NotEqual(Guid.Empty).WithMessage("guid darf nicht leer sein.");
        }
    }
}
