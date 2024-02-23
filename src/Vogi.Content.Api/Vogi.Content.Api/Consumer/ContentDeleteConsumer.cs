using FluentValidation;
using MassTransit;
using MediatR;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Domain.Dtos.Mediator.Base;
namespace Vogi.ContentAutoat.Api.Consumer
{
    public class ContentDeleteConsumer : IConsumer<ContentDeleteDto>
    {

        private readonly IMediator _mediator;
        private readonly IValidator<ContentDeleteDto> _contentDeleteDto;

        public ContentDeleteConsumer(IMediator mediator, IValidator<ContentDeleteDto> validator)
        {
            _mediator = mediator;
            _contentDeleteDto = validator;
        }

        public Task Consume(ConsumeContext<ContentDeleteDto> context)
        {
            _contentDeleteDto.ValidateAndThrow(context.Message);
            var task = _mediator.Send(context.Message);
            return task;
        }
    }
}
