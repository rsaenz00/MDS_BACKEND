using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;

namespace MDS.Services.Clinica.Implementation
{
    public class ClinicaService : IClinicaService
    {
        private readonly IUnitOfWork _uow;

        public ClinicaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetClinicas()
        {
            try
            {
                List<DbContext.Entities.Clinica> clinicas = new List<DbContext.Entities.Clinica>();

                clinicas = await _uow.ExecuteStoredProcAll<DbContext.Entities.Clinica>("SPRMDS_LIST_CLINICA");

                List<ClinicaDto> listClinicas = new List<ClinicaDto>();

                listClinicas = clinicas.Select(s => new ClinicaDto { id_clinica = s.CCLI_ID, clinica = s.CCLI_DESCRIPCION, ubigeo = s.CUBI_UBIGEO, direccion = s.SCLI_DIRECCION, telefono = s.SCLI_TELEFONO, afiliado = s.FCLI_AFILIADO, plan_huerfano_ilimitado = s.FCLI_PLAN_HUERFANO_ILIMITADO, estado = s.FCLI_ESTADO, departamento = s.SUBI_DEPARTAMENTO, provincia = s.SUBI_PROVINCIA, distrito = s.SUBI_DISTRITO }).ToList();

                if (!clinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetClinicasFiltro(string busqueda, string condicion)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isTextoBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = busqueda },
                    new SqlParameter("@isCondicion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = condicion },
                };

                List<DbContext.Entities.ClinicaFiltro> clinicas = new List<DbContext.Entities.ClinicaFiltro>();

                clinicas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.ClinicaFiltro>("SPRMDS_LIST_CLINICA_FILTRO", parameters);

                List<ClinicaFiltroDto> listClinicas = new List<ClinicaFiltroDto>();

                listClinicas = clinicas.Select(s => new ClinicaFiltroDto { id_clinica = s.CCLI_ID, clinica = s.CCLI_DESCRIPCION, direccion = s.SCLI_DIRECCION, telefono = s.SCLI_TELEFONO, ubigeo = s.CUBI_UBIGEO, departamento = s.SUBI_DEPARTAMENTO, provincia = s.SUBI_PROVINCIA, distrito = s.SUBI_DISTRITO }).ToList();

                /*if (!listClinicas.Any())
                    return ServiceResponse.Return404();*/

                return ServiceResponse.ReturnResultWith200(listClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddClinica(ClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isDescripcion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.clinica },
                    new SqlParameter("@isUbigeo", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.ubigeo },
                    new SqlParameter("@isDireccion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.direccion },
                    new SqlParameter("@isTelefono", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.telefono },
                    new SqlParameter("@isAfiliafo", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.afiliado },
                    new SqlParameter("@isPlanHuerfanoIlimitado", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.plan_huerfano_ilimitado },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@inEstado", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_CLINICA", parameters);

                dto.id_clinica = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> UpdateClinica(ClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoClinica", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_clinica},
                    new SqlParameter("@isDescripcion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.clinica },
                    new SqlParameter("@isUbigeo", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.ubigeo },
                    new SqlParameter("@isDireccion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.direccion },
                    new SqlParameter("@isTelefono", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.telefono },
                    new SqlParameter("@isAfiliafo", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.afiliado },
                    new SqlParameter("@isPlanHuerfanoIlimitado", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.plan_huerfano_ilimitado },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_modificacion },
                    new SqlParameter("@inEstado", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_CLINICA", parameters);

                dto.id_clinica = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> DeleteClinica(ClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoClinica", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_clinica},
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_DELETE_CLINICA", parameters);

                dto.id_clinica = Convert.ToInt64(response);
                dto.clinica = "borrado";

                return ServiceResponse.ReturnSuccess();

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

    }
}