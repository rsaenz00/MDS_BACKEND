using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Cliente
{
    public interface IClienteService : IService
    {
        Task<ServiceResponse> GetClientes();

        Task<ServiceResponse> GetConsultaCliente(string vCondicion,string vBusqueda);

        Task<ServiceResponse> AddCliente(MantenimientoClienteDto dto);

        Task<ServiceResponse> GetClienteByRuc(string ruc);
    }
}

