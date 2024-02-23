using FluentValidation;
using MassTransit;
using MediatR;
using System.ComponentModel.DataAnnotations;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Domain.Dtos.Mediator.Base;
namespace Vogi.ContentAutoat.Api.Consumer
{
    public class ContentUpdateConsumer : IConsumer<ContentUpdateDto>
    {

        private readonly IMediator _mediator;
        private readonly IValidator<ContentUpdateDto> _validator;

        public ContentUpdateConsumer(IMediator mediator, IValidator<ContentUpdateDto> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public Task Consume(ConsumeContext<ContentUpdateDto> context)
        {
            _validator.ValidateAndThrow(context.Message);
            var task = _mediator.Send(context.Message);
            return task;
        }
    }
}
