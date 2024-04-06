using Microsoft.AspNetCore.Mvc;

namespace Vogl.Logging.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggerController : ControllerBase
    {
        private readonly LoggingService _loggingService;

        public LoggerController(LoggingService LoggingService)
        {
            _loggingService = LoggingService;
        }

        [HttpGet]
        public IEnumerable<LoggingData> GetAll()
        {
            return _loggingService.data;
        }

        [HttpPost]
        public Response Add(LoggingData loggingData)
        {
            _loggingService.data.Add(loggingData);
            return new Response()
            {
                Result = true
            };
        }
    }

    public class Response()
    {
        public bool Result { get; set; }
    }
}
