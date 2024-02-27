using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
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

        Task<ServiceResponse> GetBlogs();
        Task<ServiceResponse> GetBlog(long blogId);
        Task<ServiceResponse> AddBlog(BlogDto dto);
        Task<ServiceResponse> UpdateBlog(BlogDto dto);
        Task<ServiceResponse> DeleteBlog(BlogDto dto);
    }
}

