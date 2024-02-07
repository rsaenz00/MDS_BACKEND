using MDS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MDS.DbContext.Enums;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Services;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using Microsoft.Data.SqlClient;
using System.Data;
using MDS.DbContext.Entities;
using System.Numerics;


namespace MDS.Services.Blog.Implementation
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _uow;

        public BlogService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<BlogDto> AddBlog(BlogDto dto)
        {
            try
            {
                var dbBlog = new DbContext.Entities.Blog
                {
                    Url = dto.Url
                };

                SqlParameter[] parameters =
                {
                    new SqlParameter("@param", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dbBlog.Url },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_BLOG", parameters);

                dto.Id = Convert.ToInt64(response);
                dto.Url = dto.Url;

                return dto;
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return null;
            }
        }

        public async Task<BlogDto> GetBlog(long blogId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@param", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = blogId },
                };

                DbContext.Entities.Blog blog = new DbContext.Entities.Blog();

                blog = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Blog>("SPRMDS_LIST_BLOG_BY_PARAM", parameters);

                if (blog == null)
                    return null;
 
                return new BlogDto { Id = blog.Id, Url = blog.Url };
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return null;
            }
        }

        public async Task<List<BlogDto>> GetBlogs()
        {
            try
            {
                List<DbContext.Entities.Blog> blogs = new List<DbContext.Entities.Blog>();

                blogs = await _uow.ExecuteStoredProcAll<DbContext.Entities.Blog>("SPRMDS_LIST_BLOGS");
                
                if (!blogs.Any())
                    return null;

                return blogs.Select(s => new BlogDto { Id = s.Id, Url = s.Url }).ToList();
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return null;
            }
        }

        public async Task<BlogDto> UpdateBlog(BlogDto dto)
        {
            try
            {
                var dbBlog = new DbContext.Entities.Blog
                {
                    Id = dto.Id,
                    Url = dto.Url
                };

                SqlParameter[] parameters =
                {
                    new SqlParameter("@param", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dbBlog.Id },
                    new SqlParameter("@param2", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dbBlog.Url },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_BLOG", parameters);

                dto.Id = Convert.ToInt64(response);
                dto.Url = dto.Url;

                return dto;
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return null;
            }
        }
        public async Task<BlogDto> DeleteBlog(BlogDto dto) 
        {
            try
            {
                var dbBlog = new DbContext.Entities.Blog
                {
                    Id = dto.Id
                };

                SqlParameter[] parameters =
                {
                    new SqlParameter("@param", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dbBlog.Id },
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_DELETE_BLOG", parameters);

                dto.Id = Convert.ToInt64(response);
                dto.Url = "borrado";

                return dto;
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return null;
            }
        }
    }
}
