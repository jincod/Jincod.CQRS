using Jincod.CQRS.Commands;
using Jincod.CQRS.Domain;
using Jincod.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Jincod.CQRS.Web.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ICommandProcessor _commandProcessor;
        private readonly IQueryProcessor _queryProcessor;

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
        public IActionResult Post([FromBody] SimpleCommand command)
        {
            _commandProcessor.Process(command);

            return Ok(new {command.Id});
        }
    }
}
