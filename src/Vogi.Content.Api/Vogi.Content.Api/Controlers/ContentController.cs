using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vogi.Content.Api.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        public IActionResult Add() {
            return Ok();
        
        }


        public IActionResult Update()
        {
            return Ok();
        }


    }
}
