using FluentValidation;
using MassTransit;
using MediatR;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Domain.Dtos.Mediator.Base;
namespace Vogi.ContentAutoat.Api.Consumer
{
    public class ContentAddConsumer : IConsumer<ContentAddDto>
    {

        private readonly IMediator _mediator;
        private readonly IValidator<ContentAddDto> _validator;

        public ContentAddConsumer(IMediator mediator, IValidator<ContentAddDto> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        public Task Consume(ConsumeContext<ContentAddDto> context)
        {
            _validator.ValidateAndThrow(context.Message);
            var guid = _mediator.Send(context.Message);
            return guid;
        }
    }
}
