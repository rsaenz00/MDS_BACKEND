using MDS.Dto;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.Blog
{
    public interface IBlogService : IService
    {
        Task<List<BlogDto>> GetBlogs();
        Task<BlogDto> GetBlog(long blogId);
        Task<BlogDto> AddBlog(BlogDto dto);
        Task<BlogDto> UpdateBlog(BlogDto dto);
        Task<BlogDto> DeleteBlog(BlogDto dto);
    }
}

