using MDS.Dto;
using MDS.Dto.Resources;
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
        Task<ServiceResponse> GetHistoriasClinicasSctrFiltro(string fechaInicio, string fechaFin, string busqueda, string condicion, int reporte);

        //By Henrry Torres
        Task<ServiceResponse> AddHistoriaClinicaSctr(HistoriaClinicaMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> UpdateHistoriaClinicaSctr(HistoriaClinicaMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> DeleteHistoriaClinicaSctr(HistoriaClinicaMtoDto dto);
        //FIN SERVICIO SCTR

        //SERVICIO AMBULANCIA
        //By Henrry Torres
        Task<ServiceResponse> GetHistoriasClinicasAmbulanciaBandeja(AmbulanciaResource dto);

        //By Henrry Torres
        Task<ServiceResponse> AddHistoriaClinicaAmbulanciaOrientacionMedica(HistoriaClinicaMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> AddHistoriaClinicaAmbulancia(HistoriaClinicaMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> AddHistoriaClinicaAmbulanciaEvento(HistoriaClinicaMtoDto dto);

        //By Henrry Torres
        Task<ServiceResponse> DeleteHistoriaClinicaAmbulancia(HistoriaClinicaMtoDto dto);
        //FIN SERVICIO AMBULANCIA

        //SERVICIO MAD
        //By Henrry Torres
        Task<ServiceResponse> GetHistoriaClinicaMadByCodigo(int historiaClinicaId);

        //By Willian Vilca
        Task<ServiceResponse> GetHistoriaClinica_Mad_Aseguradora(string vAseguradora);

        //By Willian Vilca
        Task<ServiceResponse> AddHistoriaClinicaSiteds(SitedsMtoDto dto);

        //By Willian Vilca
        Task<ServiceResponse> GetHistoriaClinica_Mad_Ubigeo_Codigo(string vDepartamento, string vProvincia, string vDistrito);
        //FIN SERVICIO MAD
    }
}

