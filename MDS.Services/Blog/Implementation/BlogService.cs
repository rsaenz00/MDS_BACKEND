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

        public async Task<Response> GetBlogs()
        {
            try
            {
                List<DbContext.Entities.Blog> blogs = new List<DbContext.Entities.Blog>();

                blogs = await _uow.ExecuteStoredProcAll<DbContext.Entities.Blog>("SPRMDS_LIST_BLOGS");

                List<BlogDto> listBlog = new List<BlogDto>();

                listBlog = blogs.Select(s => new BlogDto { Id = s.Id, Url = s.Url }).ToList();

                if (!listBlog.Any())
                    return new Response(200, "Sin datos", "No se encontraron registros", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), null);

                return new Response(200, "Datos encontrados", "Se encontró " + listBlog.Count() + " registros.", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), listBlog);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return new Response(500, "Error", e.Message, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), null);
            }
        }

        public async Task<Response> GetBlog(long blogId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@id", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = blogId },
                };

                List<DbContext.Entities.Blog> blogs = new List<DbContext.Entities.Blog>();

                blogs = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Blog>("SPRMDS_LIST_BLOG_BY_PARAM", parameters);

                if (!blogs.Any())
                    return new Response(200, "Sin datos", "No se encontraron registros", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), null);

                return new Response(200, "Registro encontrado", "Se encontró " + blogs.Count() + " registros.", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), blogs);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return new Response(500, "Error", e.Message, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), null);
            }
        }

        public async Task<Response> AddBlog(BlogDto dto)
        {
            try
            {
                var dbBlog = new DbContext.Entities.Blog
                {
                    Url = dto.Url
                };

                SqlParameter[] parameters =
                {
                    new SqlParameter("@url", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dbBlog.Url },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_BLOG", parameters);

                dto.Id = Convert.ToInt64(response);
                dto.Url = dto.Url;

                return new Response(200, "Registro agregado", "Se registró correctamente: " + dto.Url, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), dto);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return new Response(500, "Error", e.Message, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), dto);
            }
        }

        public async Task<Response> UpdateBlog(BlogDto dto)
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
                    new SqlParameter("@id", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dbBlog.Id },
                    new SqlParameter("@url", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dbBlog.Url },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_BLOG", parameters);

                dto.Id = Convert.ToInt64(response);
                dto.Url = dto.Url;

                return new Response(200, "Registro actualizado", "Se actualizó correctamente: " + dto.Id, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), dto);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return new Response(500, "Error", e.Message, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), dto);
            }
        }

        public async Task<Response> DeleteBlog(BlogDto dto)
        {
            try
            {
                var dbBlog = new DbContext.Entities.Blog
                {
                    Id = dto.Id
                };

                SqlParameter[] parameters =
                {
                    new SqlParameter("@id", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dbBlog.Id },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_DELETE_BLOG", parameters);

                dto.Id = Convert.ToInt64(response);
                dto.Url = "borrado";

                return new Response(200, "Registro eliminado", "Se eliminó correctamente: " + dto.Id, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), dto);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return new Response(500, "Error", e.Message, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), dto);
            }
        }
    }
}
