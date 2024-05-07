using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using Microsoft.Data.SqlClient;
using System.Data;
using MDS.Infrastructure.Helper;
using MDS.Services.Direccion;

namespace MDS.Services.Blog.Implementation
{
    public class DireccionService : IDireccionService
    {
        private readonly IUnitOfWork _uow;

        public DireccionService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetDirecciones(long CPER_ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoPersona", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = CPER_ID }
                };

                List<DbContext.Entities.Direccion> direcciones = new List<DbContext.Entities.Direccion>();

                direcciones = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Direccion>("SPRMDS_LIST_DIRECCION_BY_PERSONA", parameters);

                List<DireccionDto> listDireccion = new List<DireccionDto>();

                listDireccion = direcciones.Select(s => new DireccionDto { id_direccion = s.CDIR_ID, id_persona = s.CPER_ID, tipo_direccion = s.NDIR_TIPO_DIRECCION, descripcion = s.SDIR_DESCRIPCION, cod_departamento = s.SDIR_COD_DPTO, cod_provincia = s.SDIR_COD_PROV, cod_distrito = s.SDIR_COD_DIST, anexo = s.SDIR_ANEXO, celular = s.SDIR_TLF_CELULAR, telefono_fijo = s.SDIR_TLF_FIJO, nro_mz_lote = s.SDIR_NRO_LOTE, urbanizacion = s.SDIR_URBANIZACION, referencia = s.SDIR_REFERENCIA, dpto_interior = s.SDIR_INTERIOR }).ToList();

                if (!listDireccion.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listDireccion);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetDireccion(long CPER_ID, long CDIR_ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoPersona", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = CPER_ID },
                    new SqlParameter("@inCodigoDireccion", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = CDIR_ID },
                };

                List<DbContext.Entities.Direccion> direcciones = new List<DbContext.Entities.Direccion>();

                direcciones = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Direccion>("SPRMDS_LIST_DIRECCION", parameters);

                List<DireccionDto> listDireccion = new List<DireccionDto>();

                listDireccion = direcciones.Select(s => new DireccionDto { id_direccion = s.CDIR_ID, id_persona = s.CPER_ID, tipo_direccion = s.NDIR_TIPO_DIRECCION, descripcion = s.SDIR_DESCRIPCION, cod_departamento = s.SDIR_COD_DPTO, cod_provincia = s.SDIR_COD_PROV, cod_distrito = s.SDIR_COD_DIST, anexo = s.SDIR_ANEXO, celular = s.SDIR_TLF_CELULAR, telefono_fijo = s.SDIR_TLF_FIJO, nro_mz_lote = s.SDIR_NRO_LOTE, urbanizacion = s.SDIR_URBANIZACION, referencia = s.SDIR_REFERENCIA, dpto_interior = s.SDIR_INTERIOR }).ToList();

                if (!listDireccion.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listDireccion);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddDireccion(DireccionDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoDireccion", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.id_direccion },
                    new SqlParameter("@inCodigoPersona", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@inTipodireccion", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.tipo_direccion },
                    new SqlParameter("@isDescripcion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.descripcion },
                    new SqlParameter("@isCodigoDepartamento", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.cod_departamento },
                    new SqlParameter("@isCodigoProvincia", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.cod_provincia },
                    new SqlParameter("@isCodigoDistrito", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.cod_distrito },
                    new SqlParameter("@isAnexo", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.anexo },
                    new SqlParameter("@isTelefonoCelular", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.celular },
                    new SqlParameter("@isTelefonoFijo", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.telefono_fijo },
                    new SqlParameter("@isNroLote", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.nro_mz_lote },
                    new SqlParameter("@isUrbanizacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.urbanizacion },
                    new SqlParameter("@isReferencia", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.referencia },
                    new SqlParameter("@isInterior", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.dpto_interior },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_DIRECCION", parameters);

                dto.id_direccion = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> UpdateDireccion(DireccionDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoDireccion", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.id_direccion },
                    new SqlParameter("@inCodigoPersona", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@inTipodireccion", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.tipo_direccion },
                    new SqlParameter("@isDescripcion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.descripcion },
                    new SqlParameter("@isCodigoDepartamento", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.cod_departamento },
                    new SqlParameter("@isCodigoProvincia", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.cod_provincia },
                    new SqlParameter("@isCodigoDistrito", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.cod_distrito },
                    new SqlParameter("@isAnexo", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.anexo },
                    new SqlParameter("@isTelefonoCelular", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.celular },
                    new SqlParameter("@isTelefonoFijo", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.telefono_fijo },
                    new SqlParameter("@isNroLote", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.nro_mz_lote },
                    new SqlParameter("@isUrbanizacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.urbanizacion },
                    new SqlParameter("@isReferencia", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.referencia },
                    new SqlParameter("@isInterior", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.dpto_interior },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_modificacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_DIRECCION", parameters);

                dto.id_direccion = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> DeleteDireccion(DireccionDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoPersona", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@inCodigoDireccion", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_direccion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_DELETE_DIRECCION", parameters);

                dto.id_direccion = Convert.ToInt64(response);
                dto.descripcion = "borrado";

                return ServiceResponse.ReturnSuccess();

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }
    }
}