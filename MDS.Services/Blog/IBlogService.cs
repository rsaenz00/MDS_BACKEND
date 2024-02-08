using MDS.Dto;
using MDS.Infrastructure.DbUtility;
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
        Task<Response> GetBlogs();
        Task<Response> GetBlog(long blogId);
        Task<Response> AddBlog(BlogDto dto);
        Task<Response> UpdateBlog(BlogDto dto);
        Task<Response> DeleteBlog(BlogDto dto);
    }
}

