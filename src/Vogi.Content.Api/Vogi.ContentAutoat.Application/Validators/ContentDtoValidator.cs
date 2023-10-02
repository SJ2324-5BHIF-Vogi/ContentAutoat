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
    public class ContentDtoValidator : AbstractValidator<ContentDto>
    {
        public ContentDtoValidator()
        {
            RuleFor(x => x.Titel)
                .NotEmpty().WithMessage("Titel darf nicht leer sein.")
                .MaximumLength(200).WithMessage("Titel darf nicht länger als 200 Zeichen sein.");

            RuleFor(x => x.Data)
                .NotEmpty().WithMessage("Data darf nicht leer sein.");
        }
    }
}
