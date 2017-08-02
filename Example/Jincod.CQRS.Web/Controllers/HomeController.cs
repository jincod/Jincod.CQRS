using Microsoft.AspNetCore.Mvc;
using Jincod.CQRS.Domain;
using Jincod.CQRS.Queries;
using Jincod.CQRS.Commands;

namespace Jincod.CQRS.Web.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandProcessor _commandProcessor;

        public HomeController(IQueryProcessor queryProcessor, ICommandProcessor commandProcessor)
        {
            _queryProcessor = queryProcessor;
            _commandProcessor = commandProcessor;
        }

        [HttpGet]
        public SimpleEntity Get()
        {
            return _queryProcessor
                .Process<SimpleEntity, SimpleQueryContext>(new SimpleQueryContext());
        }

        [HttpPost]
        public IActionResult Post([FromBody]SimpleCommand command)
        {
            _commandProcessor.Process(command);

            return Ok();
        }
    }
}
