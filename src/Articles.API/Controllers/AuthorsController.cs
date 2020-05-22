using Articles.Core.Application.Authors.Commands.CreateAuthor;
using Articles.Core.Application.Authors.Commands.UpdateAuthor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace Articles.API.Controllers
{
    public class AuthorsController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateAuthorCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdateAuthorCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
