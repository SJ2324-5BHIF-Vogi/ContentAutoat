using FluentValidation;
using MassTransit;
using MediatR;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Domain.Dtos.Mediator.Base;
namespace Vogi.ContentAutoat.Api.Consumer
{
    public class ContentDetailedConsumer : IConsumer<ContentGetDto>
    {

        private readonly IMediator _mediator;
        private readonly IValidator<ContentGetDto> _validator;

        public ContentDetailedConsumer(IMediator mediator, IValidator<ContentGetDto> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public Task Consume(ConsumeContext<ContentGetDto> context)
        {
            _validator.ValidateAndThrow(context.Message);
            var guid = _mediator.Send(context.Message);
            return guid;
        }
    }
}
