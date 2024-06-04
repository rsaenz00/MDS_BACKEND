using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Atencion
{
    public interface IAtencionService : IService
    {
        //SERVICIO SCTR
        //By Henrry Torres
        Task<ServiceResponse> GetAtencionesSctrBandeja(string fechaInicio, string fechaFin, string condicion);

        //By Henrry Torres
        Task<ServiceResponse> GetAtencionSctrByCodigo(string cod_atencion);

        //By Henrry Torres
        Task<ServiceResponse> GetAtencionesSctrFiltro(string fechaInicio, string fechaFin, string busqueda, string condicion);

        //By Henrry Torres
        Task<ServiceResponse> AddAtencionSctr(AtencionMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> UpdateAtencionSctr(AtencionMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> DeleteAtencionSctr(AtencionMtoDto dto);
        //FIN SERVICIO SCTR
    }
}

