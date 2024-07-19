using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.HistoriaClinica
{
    public interface IHistoriaClinicaService : IService
    {
        //SERVICIO SCTR
        //By Henrry Torres
        Task<ServiceResponse> GetHistoriasClinicasSctrBandeja(string fechaInicio, string fechaFin, string condicion);

        //By Henrry Torres
        Task<ServiceResponse> GetHistoriaClinicaSctrByCodigo(string cod_historia_clinica);

        //By Henrry Torres
        Task<ServiceResponse> GetHistoriasClinicasSctrFiltro(string fechaInicio, string fechaFin, string busqueda, string condicion);

        //By Henrry Torres
        Task<ServiceResponse> AddHistoriaClinicaSctr(HistoriaClinicaMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> UpdateHistoriaClinicaSctr(HistoriaClinicaMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> DeleteHistoriaClinicaSctr(HistoriaClinicaMtoDto dto);
        //FIN SERVICIO SCTR

        //SERVICIO MAD
        //By Henrry Torres
        Task<ServiceResponse> GetHistoriaClinicaMadByCodigo(int historiaClinicaId);
        //FIN SERVICIO MAD
    }
}

