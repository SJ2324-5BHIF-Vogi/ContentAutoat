using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vogi.ContentAutoat.Domain.Dtos;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;

namespace Vogi.Content.Api.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly Mediator _mediator;
        public ContentController(Mediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult Add(ContentAddDto contenDto) 
        {
            var guid = _mediator.Send(contenDto);
            return Ok(guid);
        }

        [HttpPatch]
        public IActionResult Update([FromRoute()] Guid Guid, [FromBody()] ContentUpdateDto contenDto)
        {
            var guid = _mediator.Send(contenDto);
            return Ok(guid);
        }

        [HttpDelete]
        public IActionResult Delete([FromRoute()] Guid Guid)
        {
            var dto = new ContentDeleteDto() { guid = Guid };
            _mediator.Send(dto);
            return Ok();
        }

        [HttpGet("{Guid}")]
        public IActionResult Get([FromRoute()]Guid Guid)
        {
            var dto = new ContentGetDto() { guid = Guid };
            var result = _mediator.Send(dto);
            return Ok(result);
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var dto = new ContentGetAllDto();
            _mediator.Send(dto);
            return Ok();
        }
    }
}
