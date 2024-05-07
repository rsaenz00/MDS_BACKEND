using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDS.Utility.Attributes;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime;
using MDS.Infrastructure.Settings;
using Microsoft.Extensions.Logging;
using MDS.Services.AuditoriaLogin;
using Azure.Core;
using Microsoft.AspNetCore.SignalR;
using MDS.Services.Hub;
using MDS.Services.Hub.Implementation;
using MDS.Services.UsuarioRol;
using MDS.Utility.Extensions;
using Newtonsoft.Json;
using MDS.Services.UsuarioRol.Implementation;
using MDS.Services.RolClaim;
using MDS.Services.UsuarioClaim;
using MDS.Services.UsuarioClaim.Implementation;
using MDS.Services.PaginaAccion;
using MDS.Services.PaginaAccion.Implementation;
using MDS.DbContext.Entities;
using Microsoft.AspNetCore.Routing;

namespace MDS.Services.Usuario.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAppSettings _appSettings;
        private readonly ILogger<UsuarioService> _logger;
        private readonly IAuditoriaLoginService _auditoriaService;
        private readonly IUsuarioRolService _usuarioRolService;
        private readonly IRolClaimService _rolClaimService;
        private readonly IUsuarioClaimService _usuarioClaimService;
        private readonly IPaginaAccionService _paginaAccionService;
        private readonly IHubContext<HubClienteService, IHubClienteService> _hubContext;

        public UsuarioService
        (
            IUnitOfWork uow, 
            IAppSettings appSettings, 
            ILogger<UsuarioService> logger, 
            IAuditoriaLoginService auditoriaService,
            IUsuarioRolService usuarioRolService,
            IRolClaimService rolClaimService,
            IUsuarioClaimService usuarioClaimService,
            IPaginaAccionService paginaAccionService,
            IHubContext<HubClienteService, 
            IHubClienteService> hubContext
        )
        {
            _uow = uow;
            _appSettings = appSettings;
            _logger = logger;
            _auditoriaService = auditoriaService;
            _usuarioRolService = usuarioRolService;
            _rolClaimService = rolClaimService;
            _usuarioClaimService = usuarioClaimService;
            _paginaAccionService = paginaAccionService;
            _hubContext = hubContext;
        }

        public async Task<ServiceResponse> AddUsuario()
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse> UpdateUsuario()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> DeleteUsuario()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> GetAllUsuario()
        {
            try
            {
                List<DbContext.Entities.Usuario> usuarios = new List<DbContext.Entities.Usuario>();

                usuarios = await _uow.ExecuteStoredProcAll<DbContext.Entities.Usuario>("SPRMDS_LIST_USUARIO");

                List<UsuarioDto> lstUsuario = new List<UsuarioDto>();

                if (!usuarios.Any())
                    return ServiceResponse.ReturnResultWith204();

                lstUsuario = usuarios.Select
                (
                    s => new UsuarioDto
                    { 
                        codigoUsuario = s.CUSR_ID,
                        usuario = s.SUSR_NOMBRE,
                        contrasena = s.SUSR_CONTRASENA,
                        nombres = s.SPER_NOMBRES,
                        apellidoPaterno = s.SPER_APELLIDO_PATERNO,
                        apellidoMaterno = s.SPER_APELLIDO_MATERNO,
                        email = s.SUSR_EMAIL_CORP,
                        telefonoMovil = s.SUSR_TLF_CELULAR_CORP,
                        estado = s.FUSR_ESTADO
                    }
                ).ToList();

                return ServiceResponse.ReturnResultWith200(lstUsuario);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        public async Task<ServiceResponse> GetUsuario()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> LoginUsuario(UsuarioDto dto)
        {
            try
            {
                var auditoria = new AuditoriaLoginDto
                {
                    usuario = dto.usuario,
                    origen = "WEB",
                    ip = dto.ip,
                    estado = ConstantsList.STATUS_SUCCESS.ToString(),
                    latitud = dto.latitud,
                    longitud = dto.longitud
                };

                SqlParameter[] parametroObtenerUsuario =
                {
                    new SqlParameter("@isNombreUsuario", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = (dto.usuario == null) ? DBNull.Value : dto.usuario},
                };

                var usuario = await _uow.ExecuteStoredProcObjectByParam<DbContext.Entities.Usuario>("SPRMDS_GET_USUARIO_BY_NAME", parametroObtenerUsuario);

                if (usuario != null)
                {
                    if (usuario.SUSR_CONTRASENA != dto.contrasena)
                    {
                        auditoria.estado = ConstantsList.STATUS_ERROR;
                        auditoria.descripcion = ConstantsList.AUTH_ERROR_WRONG_PASSWORD;
                        await _auditoriaService.AddAuditoriaLogin(auditoria);
                        return ServiceResponse.ReturnUnauthorized();
                    }

                    if (usuario.FUSR_ESTADO == ConstantsList.AUTH_STATUS_OFF)
                    {
                        auditoria.estado = ConstantsList.STATUS_ERROR;
                        auditoria.descripcion = ConstantsList.AUTH_ERROR_STATUS;
                        await _auditoriaService.AddAuditoriaLogin(auditoria);
                        return ServiceResponse.ReturnFailed(ConstantsList.STATUS_CODE_599, ConstantsList.AUTH_ERROR_STATUS);
                    }

                    if (usuario.NUSR_INTENTOS_FALLIDOS > ConstantsList.AUTH_MAX_ATTEMPS)
                    {
                        auditoria.estado = ConstantsList.STATUS_ERROR;
                        auditoria.descripcion = ConstantsList.AUTH_ERROR_MAX_ATTEMPS;
                        await _auditoriaService.AddAuditoriaLogin(auditoria);
                        return ServiceResponse.ReturnFailed(ConstantsList.STATUS_CODE_598, ConstantsList.AUTH_ERROR_MAX_ATTEMPS);
                    }
                    await _auditoriaService.AddAuditoriaLogin(auditoria);
                }
                else
                {
                    auditoria.estado = ConstantsList.STATUS_ERROR;
                    auditoria.descripcion = ConstantsList.AUTH_ERROR_NOT_EXISTS;
                    await _auditoriaService.AddAuditoriaLogin(auditoria);
                    return ServiceResponse.Return404();
                }

                var usuarioDto = new UsuarioDto 
                { 
                    codigoUsuario = usuario.CUSR_ID,
                    nombres = usuario.SPER_NOMBRES,
                    apellidoPaterno = usuario.SPER_APELLIDO_PATERNO,
                    apellidoMaterno = usuario.SPER_APELLIDO_MATERNO,
                    email = usuario.SUSR_EMAIL_CORP,
                    telefonoMovil = usuario.SUSR_TLF_CELULAR_CORP,
                    dobleFactor = usuario.FUSR_DOBLE_FACTOR,
                    emailConfirmacion = usuario.FUSR_EMAIL_CONFIRMACION,
                    intentosFallidos = usuario.NUSR_INTENTOS_FALLIDOS,
                    estado = usuario.FUSR_ESTADO,
                    usuario = usuario.SUSR_NOMBRE
                };

                var usuarioAuthDto = await BuildUsuarioAuth(usuarioDto);

                var usuarioEnLinea = new UsuarioEnLineaDto
                {
                    usuario = usuarioAuthDto.usuario,
                    id = usuarioAuthDto.id.ToString()
                };

                await _hubContext.Clients.All.Joined(usuarioEnLinea);

                return ServiceResponse.ReturnResultWith200(usuarioAuthDto);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return ServiceResponse.Return500(e);
            }
        }

        private async Task<UsuarioAuthDto> BuildUsuarioAuth(UsuarioDto dto) 
        {
            UsuarioAuthDto usuarioAuthDto = new UsuarioAuthDto();
            //List<AppClaimDto> appClaims = new List<AppClaimDto>();

            usuarioAuthDto.id = dto.codigoUsuario;
            usuarioAuthDto.usuario = dto.usuario;
            usuarioAuthDto.nombres = dto.nombres;
            usuarioAuthDto.apellidoPaterno = dto.apellidoPaterno;
            usuarioAuthDto.apellidoMaterno = dto.apellidoMaterno;
            usuarioAuthDto.email = dto.email;
            usuarioAuthDto.telefonoMovil = dto.telefonoMovil;
            usuarioAuthDto.esAutentificado = true;
            usuarioAuthDto.foto = "";
            var appClaimDtos = await this.GetUsuarioRolClaims(dto);
            usuarioAuthDto.claims = appClaimDtos;
            var claims = appClaimDtos.Select(c => new Claim(c.claimType,c.claimValue)).ToList();
            usuarioAuthDto.token = BuildJwtToken(usuarioAuthDto, claims, dto.codigoUsuario);
            usuarioAuthDto.menu = await this.CreateMenu(appClaimDtos);
                
                
                //"{navCap:'Home',},{displayName:'Starter',iconName:'home',route:'/',},{navCap:'Other',},{displayName:'MenuLevel',iconName:'box-multiple',route:'/menu-level',children:[{displayName:'Menu1',iconName:'point',route:'/menu-1',children:[{displayName:'Menu1',iconName:'point',route:'/menu-1',},{displayName:'Menu2',iconName:'point',route:'/menu-2',},],},{displayName:'Menu2',iconName:'point',route:'/menu-2',},],},{displayName:'Disabled',iconName:'ban',route:'/disabled',disabled:true,},{displayName:'Chip',iconName:'mood-smile',route:'/primary',chip:true,chipClass:'bg-primarytext-white',chipContent:'9',},{displayName:'Outlined',iconName:'mood-smile',route:'/outline',chip:true,chipClass:'b-1border-primarytext-primary',chipContent:'outlined',},{displayName:'ExternalLink',iconName:'star',route:'https://www.google.com/',external:true,},";

            return usuarioAuthDto;
        }
        private async Task<List<object>> CreateMenu(List<AppClaimDto> appClaimDtos) 
        {
            var menu = new List<object>();

            string nombreSeccion = "";
            string nombreSubSeccion = "";

            foreach (var claim in appClaimDtos) 
            {
                if (claim.seccion != nombreSeccion) 
                {
                    menu.Add(new { navCap = claim.seccion });
                    nombreSeccion = claim.seccion;
                }

                if (claim.nombreSubSeccion == "" || claim.nombreSubSeccion == null)
                {
                    menu.Add
                    (
                         new
                         {
                             displayName = StringExtensions.FirstCharToUpper(claim.nombrePaginaMenu),
                             iconName = claim.nombreIcono,
                             route = StringExtensions.FirstCharToUpper(claim.nombrePagina) == "Dashboard" ? "/" : claim.urlPagina.ToLower(),
                         }
                    );
                }
                else 
                {
                    if (claim.nombreSubSeccion != nombreSubSeccion)
                    {
                        var finalResult = appClaimDtos.Where(item => item.nombreSubSeccion == claim.nombreSubSeccion);
                        var subMenu = new List<object>();

                        foreach (var f in finalResult)
                        {
                            subMenu.Add
                            (
                                new
                                {
                                    displayName = StringExtensions.FirstCharToUpper(f.nombrePaginaMenu),
                                    iconName = f.nombreIcono,
                                    route = f.urlPagina
                                }
                            );
                        }


                        menu.Add
                        (
                             new
                             {
                                 displayName = StringExtensions.FirstCharToUpper(claim.nombreSubSeccion),
                                 iconName = claim.nombreIconoSubSeccion,
                                 children = subMenu
                             }
                        );
                        nombreSubSeccion = claim.nombreSubSeccion;
                    }
                }
            }

            return menu;
        }

        private async Task<List<AppClaimDto>> GetUsuarioRolClaims(UsuarioDto dto) 
        {
            var rspUsuarioClaim = await _usuarioClaimService.GetUsuarioClaim(dto.codigoUsuario);
            var usuarioClaimIds = JsonConvert.DeserializeObject<List<UsuarioClaimDto>>(rspUsuarioClaim.ResultData.ToJsonNoFormat());

            var rspRolClaim= await GetRolClaims(dto);

            var rspPaginaAccion = await _paginaAccionService.GetPaginaAccion();
            var paginaAccionIds = JsonConvert.DeserializeObject<List<PaginaAccionDto>>(rspPaginaAccion.ResultData.ToJsonNoFormat());

            List<AppClaimDto> listAppClaimDto = new List<AppClaimDto>();

            foreach (var paginaAccion in paginaAccionIds)
            {
                var appClaimDto = new AppClaimDto
                {
                    seccion = paginaAccion.nombreSeccion.ToUpper(),
                    nombrePaginaMenu = StringExtensions.FirstCharToUpper(paginaAccion.nombrePaginaMenu),
                    nombrePagina = StringExtensions.FirstCharToUpper(paginaAccion.nombrePagina),
                    nombreIcono = paginaAccion.nombreIcono,
                    nombreSubSeccion = paginaAccion.nombreSubSeccion,
                    nombreIconoSubSeccion = paginaAccion.nombreIconoSubSeccion,
                    urlPagina = paginaAccion.urlPagina.ToLower(),
                    claimType = $"{paginaAccion.nombrePagina.ToLower()}_{paginaAccion.nombreAccion.ToLower()}",
                    claimValue = "false"
                };

                if (usuarioClaimIds != null && (usuarioClaimIds.Any(c => c.codigoPagina == paginaAccion.codigoPagina && c.codigoAccion == paginaAccion.codigoAccion)))
                {
                    appClaimDto.claimValue = "true";
                }

                if (rspRolClaim != null && (rspRolClaim.Any(c => c.codigoPagina == paginaAccion.codigoPagina && c.codigoAccion == paginaAccion.codigoAccion)))
                {
                    appClaimDto.claimValue = "true";
                }

                listAppClaimDto.Add(appClaimDto);
            }

            return listAppClaimDto;
        }

        private async Task<List<RolClaimDto>> GetRolClaims(UsuarioDto dto)
        {
            var rspUsuarioRol = await _usuarioRolService.GetUsuarioRol(dto);

            var rolIds = JsonConvert.DeserializeObject<List<UsuarioRolDto>>(rspUsuarioRol.ResultData.ToJsonNoFormat()).Select(c => c.codigoRol).ToList();

            List<RolClaimDto> lstRolClaim = new List<RolClaimDto>();

            foreach (var roleId in rolIds)
            {
                var rspRolClaim = await _rolClaimService.GetRolClaim(roleId);

                var rolClaimIds = JsonConvert.DeserializeObject<List<RolClaimDto>>(rspRolClaim.ResultData.ToJsonNoFormat());

                foreach (var roleClaimId in rolClaimIds)
                {
                    if (!lstRolClaim.Any(c => c.codigoRolClaim == roleClaimId.codigoRolClaim && c.codigoAccion == roleClaimId.codigoAccion && c.codigoPagina == roleClaimId.codigoPagina && c.tipoClaim == roleClaimId.tipoClaim && c.valorClaim == roleClaimId.valorClaim))
                    {
                        lstRolClaim.Add(roleClaimId);
                    }
                }
            }
            return lstRolClaim;
        }

        protected string BuildJwtToken(UsuarioAuthDto usuarioAuthDto, IList<Claim> claims, int Id)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Key));
            claims.Add(new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub.ToString(), Id.ToString()));
            claims.Add(new Claim("email", usuarioAuthDto.email));
            // Create the JwtSecurityToken object
            var token = new JwtSecurityToken
            (
              issuer: _appSettings.Issuer,
              audience: _appSettings.Audience,
              claims: claims,
              notBefore: DateTime.UtcNow,
              expires: DateTime.UtcNow.AddMinutes(_appSettings.DurationInMinutes),
              signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha256)
            );
            // Create a string representation of the Jwt token
            return new JwtSecurityTokenHandler().WriteToken(token); ;
        }
    }
}
