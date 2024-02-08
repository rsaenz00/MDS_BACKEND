using Azure;
using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.DbContext.Entities;
using MDS.Dto;
using MDS.Infrastructure.DbUtility;
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
            var response = await _blogService.GetBlogs();

            if (response.codeResult == 200)
                return Ok(response);
            return StatusCode(500);
        }

        [HttpGet, Route("GetBlog")]
        public async Task<IActionResult> GetBlog(long blogId)
        {
            var response = await _blogService.GetBlog(blogId);
            if (response.codeResult == 200)
                return Ok(response);
            return StatusCode(500);
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

            var response = await _blogService.AddBlog(dto);
            if (response.codeResult == 200)
                return Ok(response);
            return StatusCode(500);
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

            var response = await _blogService.UpdateBlog(dto);
            if (response.codeResult == 200)
                return Ok(response);
            return StatusCode(500);
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

            var response = await _blogService.DeleteBlog(dto);
            if (response.codeResult == 200)
                return Ok(response);
            return StatusCode(500);
        }
    }
}
