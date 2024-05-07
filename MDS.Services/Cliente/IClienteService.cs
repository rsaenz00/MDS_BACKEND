using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Cliente
{
    public interface IClienteService : IService
    {
        //By Henrry Torres
        Task<ServiceResponse> GetClienteByRuc(string ruc);
    }
}

