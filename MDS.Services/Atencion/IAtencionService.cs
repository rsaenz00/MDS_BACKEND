using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Atencion
{
    public interface IAtencionService : IService
    {
        //By Henrry Torres
        Task<ServiceResponse> GetAtenciones();

        //By Henrry Torres
        Task<ServiceResponse> GetAtencionesBandeja();

        //By Henrry Torres
        Task<ServiceResponse> AddAtencion(AtencionDto dto);
    }
}

