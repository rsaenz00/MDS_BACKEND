using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Atencion
{
    public interface IAtencionService : IService
    {

        //By Henrry Torres
        Task<ServiceResponse> GetAtencionesBandeja(string fechaInicio, string fechaFin, string condicion);

        //By Henrry Torres
        Task<ServiceResponse> GetAtencionByCodigo(string cod_atencion);

        //By Henrry Torres
        Task<ServiceResponse> AddAtencion(AtencionMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> UpdateAtencion(AtencionMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> DeleteAtencion(AtencionMtoDto dto);
    }
}

