using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;

namespace MDS.Services.Seguimiento.Implementation
{
    public class SeguimientoService : ISeguimientoService
    {
        private readonly IUnitOfWork _uow;

        public SeguimientoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetSeguimientoByAtencion(string cod_atencion)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoAtencion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = cod_atencion }
                };

                List<DbContext.Entities.SeguimientoList> seguimientos = new List<DbContext.Entities.SeguimientoList>();

                seguimientos = await _uow.ExecuteStoredProcByParam<DbContext.Entities.SeguimientoList>("SPRMDS_LIST_SEGUIMIENTO_BY_ATENCION", parameters);

                List<SeguimientoDto> listSeguimientos = new List<SeguimientoDto>();

                listSeguimientos = seguimientos.Select(s => new SeguimientoDto { cod_atencion = s.cod_atencion, fecha_creacion = s.fecha_creacion,hora_creacion=s.hora_creacion, observacion = s.observacion, usuario = s.usuario, servicio=s.servicio }).ToList();

                /*if (!listClinicas.Any())
                    return ServiceResponse.Return404();*/

                return ServiceResponse.ReturnResultWith200(listSeguimientos);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddSeguimientoSctr(SeguimientoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isCodigoAtencion", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.cod_atencion },
                    new SqlParameter("@isObservacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.observacion },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_SEGUIMIENTO_SCTR", parameters);

                dto.cod_atencion = response.ToString();

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

    }
}