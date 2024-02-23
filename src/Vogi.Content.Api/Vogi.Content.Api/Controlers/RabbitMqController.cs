using FluentValidation;
using MassTransit;
using MassTransit.Transports;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vogi.ContentAutoat.Domain.Dtos;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Domain.Dtos.Mediator.Base;

namespace Vogi.ContentAutoat.Api.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMqController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public RabbitMqController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public Task Add(ContentAddDto contenDto) 
        {
            return _publishEndpoint.Publish(contenDto);
        }

        [HttpPatch("{Guid}")]
        public Task Update([FromRoute()] Guid Guid, [FromBody()] ContentUpdateDto contenDto)
        {
            contenDto.Guid = Guid;
            return _publishEndpoint.Publish(contenDto);
        }

        [HttpDelete("{Guid}")]
        public Task Delete([FromRoute()] Guid Guid)
        {
            return _publishEndpoint.Publish(new ContentDeleteDto() { guid = Guid });
        }

        [HttpGet("{Guid}")]
        public Task Get([FromRoute()]Guid Guid)
        {
            var dto = new ContentGetDto() { guid = Guid };
            return _publishEndpoint.Publish(new ContentDeleteDto() { guid = Guid });
        }

        [HttpGet()]
        public Task GetAll([FromQuery()]int Page = 1, [FromQuery()] int PageSize= 100, [FromQuery()] Guid? User = null, [FromQuery()] DateTime? VorGrenze = null, [FromQuery()] DateTime? NachGrenze= null)
        {
            var dto = new ContentGetAllDto()
            {
                Page = Page,
                NachGrenze = NachGrenze,
                VorGrenze = VorGrenze,
                PageSize = PageSize,
                User = User
            };
            return _publishEndpoint.Publish(dto);
        }
    }
}
