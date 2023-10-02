using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;

namespace Vogi.ContentAutoat.Application.Validators
{
    public class ContentGetAllDtoValidator:AbstractValidator<ContentGetAllDto>
    {
        public ContentGetAllDtoValidator()
        {
            RuleFor(x => x.Page)
                 .GreaterThanOrEqualTo(1).WithMessage("Page muss größer oder gleich 1 sein.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize muss größer oder gleich 1 sein.")
                .LessThanOrEqualTo(100).WithMessage("PageSize muss kleiner oder gleich 100 sein.");

            RuleFor(x => x.User)
                .NotEmpty().When(x => x.User.HasValue).WithMessage("User darf nicht leer sein.");

            RuleFor(x => x.VorGrenze)
                .NotEmpty().When(x => x.VorGrenze.HasValue).WithMessage("VorGrenze darf nicht leer sein.")
                .LessThanOrEqualTo(x => x.NachGrenze).When(x => x.NachGrenze.HasValue && x.VorGrenze.HasValue).WithMessage("VorGrenze muss vor oder gleich NachGrenze sein.");

            RuleFor(x => x.NachGrenze)
                .NotEmpty().When(x => x.NachGrenze.HasValue).WithMessage("NachGrenze darf nicht leer sein.")
                .GreaterThanOrEqualTo(x => x.VorGrenze).When(x => x.VorGrenze.HasValue && x.NachGrenze.HasValue).WithMessage("NachGrenze muss nach oder gleich VorGrenze sein.");
        }
    }
}
