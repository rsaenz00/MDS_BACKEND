using Azure;
using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.DbContext.Entities;
using MDS.Dto;
using MDS.Dto.List;
using MDS.Infrastructure.Helper;
using MDS.Services.Blog;
using MDS.Services.Blog.Implementation;
using MDS.Services.Usuario;
using MDS.Utility.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MDS.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsuario()
        {
            var response = await _usuarioService.GetAllUsuario();
            var pl = JsonConvert.DeserializeObject<List<UsuarioDto>>(response.ResultData.ToJsonNoFormat());

            return Ok(pl);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUsuario(LoginUsuarioViewModel model)
        {
            UsuarioDto dto = new UsuarioDto
            {
                usuario = model.usuario,
                contrasena = model.contrasena,
                ip = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
            };

            var response = await _usuarioService.LoginUsuario(dto);

            return ReturnFormattedResponse(response);
        }

        [HttpGet("GetContrasena")]
        public async Task<IActionResult> GetContrasena(LoginUsuarioViewModel model)
        {
            UsuarioDto dto = new UsuarioDto
            {
                usuario = model.usuario,
                contrasena = model.contrasena,
                ip = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
            };

            var response = await _usuarioService.LoginUsuario(dto);

            return ReturnFormattedResponse(response);
        }

        [HttpGet("GetUsuario")]
        public async Task<IActionResult> GetUsuario(LoginUsuarioViewModel model)
        {
            UsuarioDto dto = new UsuarioDto
            {
                usuario = model.usuario,
                contrasena = model.contrasena,
                ip = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
            };

            var response = await _usuarioService.LoginUsuario(dto);

            return ReturnFormattedResponse(response);
        }

        [HttpPut("UpdateUsuario")]
        public async Task<IActionResult> UpdateUsuario(LoginUsuarioViewModel model)
        {
            UsuarioDto dto = new UsuarioDto
            {
                usuario = model.usuario,
                contrasena = model.contrasena,
                ip = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
            };

            var response = await _usuarioService.LoginUsuario(dto);

            return ReturnFormattedResponse(response);
        }

        [HttpDelete("DeleteUsuario")]
        public async Task<IActionResult> DeleteUsuario(LoginUsuarioViewModel model)
        {
            UsuarioDto dto = new UsuarioDto
            {
                usuario = model.usuario,
                contrasena = model.contrasena,
                ip = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
            };

            var response = await _usuarioService.LoginUsuario(dto);

            return ReturnFormattedResponse(response);
        }
        [HttpPost("AddUsuario")]
        public async Task<IActionResult> AddUsuario(LoginUsuarioViewModel model)
        {
            UsuarioDto dto = new UsuarioDto
            {
                usuario = model.usuario,
                contrasena = model.contrasena,
                ip = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
            };

            var response = await _usuarioService.LoginUsuario(dto);

            return ReturnFormattedResponse(response);
        }
    }
}
