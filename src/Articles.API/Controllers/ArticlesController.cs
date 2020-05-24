using Articles.Core.Application.Articles.Commands.CreateArticle;
using Articles.Core.Application.Articles.Commands.DeleteArticle;
using Articles.Core.Application.Articles.Commands.UpdateArticle;
using Articles.Core.Application.Articles.Queries.GetArticleDetail;
using Articles.Core.Application.Articles.Queries.GetArticleList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Articles.API.Controllers
{
    public class ArticlesController : BaseController
    {     
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateArticleCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdateArticleCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteArticleCommand { Id = id });

            return NoContent();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ArticleDetailVM>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetArticleDetailQuery { ArticleId = id }));
        }
        [HttpGet]
        public async Task<ActionResult<GetArticleListVM>> GetAll()
        {
            return Ok(await Mediator.Send(new GetArticlesListQuery()));
        }
    }
}
