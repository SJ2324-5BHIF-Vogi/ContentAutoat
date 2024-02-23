using FluentValidation;
using MassTransit;
using MediatR;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Domain.Dtos.Mediator.Base;
namespace Vogi.ContentAutoat.Api.Consumer
{
    public class ContentGetAllConsumer : IConsumer<ContentGetAllDto>
    {

        private readonly IMediator _mediator;
        private readonly IValidator<ContentGetAllDto> _validator;

        public ContentGetAllConsumer(IMediator mediator, IValidator<ContentGetAllDto> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public Task Consume(ConsumeContext<ContentGetAllDto> context)
        {
            _validator.ValidateAndThrow(context.Message);
            var task = _mediator.Send(context.Message);
            return task;
        }
    }
}
