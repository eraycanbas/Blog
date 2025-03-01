using Blog.Application.BlogPost.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly IMediator _mediator;

        public BlogPostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("api/blogposts")]
        public async Task<IActionResult> CreateBlogPost([FromBody] BlogPostCreateCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _mediator.Send(command);
            return Ok(new { Message = "Blog post created successfully." });
        }
    }
}