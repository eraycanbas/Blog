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

        //[HttpGet]
        //[Route("api/blogposts/{id}")]
        //public async Task<IActionResult> GetBlogPostById(int id)
        //{
        //    var query = new GetBlogPostByIdQuery { BlogPostId = id };
        //    var blogPost = await _getBlogPostByIdQueryHandler.HandleAsync(query);

        //    if (blogPost == null)
        //        return NotFound(new { Message = "Blog post not found." });

        //    return Ok(blogPost);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateBlogPost(int id, [FromBody] UpdateBlogPostCommand command)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    if (id != command.BlogPostId)
        //        return BadRequest("BlogPostId in the URL and body do not match.");

        //    await _updateBlogPostCommandHandler.HandleAsync(command);
        //    return Ok(new { Message = "Blog post updated successfully." });
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBlogPost(int id)
        //{
        //    var command = new DeleteBlogPostCommand { BlogPostId = id };
        //    await _deleteBlogPostCommandHandler.HandleAsync(command);
        //    return Ok(new { Message = "Blog post deleted successfully." });
        //}
    }
}