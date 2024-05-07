using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.Usuario
{
    public interface IUsuarioService : IService
    {
        Task<ServiceResponse> GetAllUsuario();
        Task<ServiceResponse> GetUsuario();
        Task<ServiceResponse> GetUsuarios();
        Task<ServiceResponse> AddUsuario();
        Task<ServiceResponse> UpdateUsuario();
        Task<ServiceResponse> DeleteUsuario();
        Task<ServiceResponse> LoginUsuario(UsuarioDto dto);
    }
}
