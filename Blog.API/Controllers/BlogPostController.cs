using Blog.Application.Commands.BlogPosts.CreateBlogPost;
using Blog.Application.Commands.BlogPosts.DeleteBlogPost;
using Blog.Application.Commands.BlogPosts.UpdateBlogPost;
using Blog.Application.Commands.Comments.AddComment;
using Blog.Application.Interfaces;
using Blog.Application.Queries;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly ICommandHandler<CreateBlogPostCommand> _createBlogPostCommandHandler;
        private readonly ICommandHandler<UpdateBlogPostCommand> _updateBlogPostCommandHandler;
        private readonly ICommandHandler<DeleteBlogPostCommand> _deleteBlogPostCommandHandler;
        private readonly IQueryHandler<GetBlogPostByIdQuery, BlogPost> _getBlogPostByIdQueryHandler;

        public BlogPostController(
         ICommandHandler<CreateBlogPostCommand> createBlogPostCommandHandler,
         ICommandHandler<UpdateBlogPostCommand> updateBlogPostCommandHandler,
         ICommandHandler<DeleteBlogPostCommand> deleteBlogPostCommandHandler,
         IQueryHandler<GetBlogPostByIdQuery, BlogPost> getBlogPostByIdQueryHandler)
        {
            _createBlogPostCommandHandler = createBlogPostCommandHandler;
            _updateBlogPostCommandHandler = updateBlogPostCommandHandler;
            _deleteBlogPostCommandHandler = deleteBlogPostCommandHandler;
            _getBlogPostByIdQueryHandler = getBlogPostByIdQueryHandler;
        }

        [HttpPost]
        [Route("api/blogposts")]
        public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _createBlogPostCommandHandler.HandleAsync(command);
            return Ok(new { Message = "Blog post created successfully." });
        }

        // Endpoint: Get a blog post by ID
        [HttpGet]
        [Route("api/blogposts/{id}")]
        public async Task<IActionResult> GetBlogPostById(int id)
        {
            var query = new GetBlogPostByIdQuery { BlogPostId = id };
            var blogPost = await _getBlogPostByIdQueryHandler.HandleAsync(query);

            if (blogPost == null)
                return NotFound(new { Message = "Blog post not found." });

            return Ok(blogPost);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlogPost(int id, [FromBody] UpdateBlogPostCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != command.BlogPostId)
                return BadRequest("BlogPostId in the URL and body do not match.");

            await _updateBlogPostCommandHandler.HandleAsync(command);
            return Ok(new { Message = "Blog post updated successfully." });
        }

        // Delete a blog post
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            var command = new DeleteBlogPostCommand { BlogPostId = id };
            await _deleteBlogPostCommandHandler.HandleAsync(command);
            return Ok(new { Message = "Blog post deleted successfully." });
        }
    }
}