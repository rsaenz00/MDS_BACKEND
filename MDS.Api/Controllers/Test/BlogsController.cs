using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services;
using MDS.Services.Blog;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers.Test
{
    
    [ApiController]
    [Route("[controller]")]
    public class BlogsController : BaseController
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet, Route("GetBlogs")]
        public async Task<IActionResult> GetBlogs()
        {
            var blogs = await _blogService.GetBlogs();
            return blogs != null ? Ok(blogs) : StatusCode(500);
        }

        [HttpGet, Route("GetBlog")]
        public async Task<IActionResult> GetBlog(long blogId)
        {
            var blog = await _blogService.GetBlog(blogId);
            return blog != null ? Ok(blog) : StatusCode(500);
        }

        [HttpPost, Route("AddBlog")]
        public async Task<IActionResult> AddBlog(CreateBlogViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            BlogDto dto = new BlogDto
            {
                Url = model.Url
            };

            var blog = await _blogService.AddBlog(dto);
            return blog != null ? Ok(blog) : StatusCode(500);
        }

        [HttpPut, Route("UpdateBlog")]
        public async Task<IActionResult> UpdateBlog(UpdateBlogViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            BlogDto dto = new BlogDto
            {
                Id = model.Id,
                Url = model.Url
            };

            var blog = await _blogService.UpdateBlog(dto);
            return blog != null ? Ok(blog) : StatusCode(500);
        }

        [HttpDelete, Route("DeleteBlog")]
        public async Task<IActionResult> DeleteBlog(DeleteBlogViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            BlogDto dto = new BlogDto
            {
                Id = model.Id
            };

            var blog = await _blogService.DeleteBlog(dto);
            return blog != null ? Ok(blog) : StatusCode(500);
        }
    }
}
