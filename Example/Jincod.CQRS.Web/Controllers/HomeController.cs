using System.Threading.Tasks;
using Jincod.CQRS.Commands;
using Jincod.CQRS.Domain;
using Jincod.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Jincod.CQRS.Web.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ICommandProcessor _commandProcessor;
        private readonly IQueryProcessor _queryProcessor;

        public HomeController(IQueryProcessor queryProcessor, ICommandProcessor commandProcessor)
        {
            _queryProcessor = queryProcessor;
            _commandProcessor = commandProcessor;
        }

        [HttpGet]
        public async Task<SimpleEntity> GetAsync()
        {
            var entity = await _queryProcessor
                .ProcessAsync<SimpleEntity, SimpleQueryContext>(new SimpleQueryContext());

            return entity;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SimpleCommand command)
        {
            await _commandProcessor.ProcessAsync(command);

            return Ok(new {command.Id});
        }
    }
}
