using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.Cliente
{
    public interface IClienteService : IService
    {
        Task<ServiceResponse> GetClientes();

        Task<ServiceResponse> GetCliente(long clienteId);

        Task<ServiceResponse> AddCliente(MantenimientoClienteDto dto);
    }
}
