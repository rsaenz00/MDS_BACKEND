using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;
using System;


namespace MDS.Services.Paciente.Implementation
{
    public class PacienteService : IPacienteService
    {
        private readonly IUnitOfWork _uow;

        public PacienteService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse> GetPacientes()
        {
            try
            {
                List<DbContext.Entities.Paciente> pacientes = new List<DbContext.Entities.Paciente>();

                pacientes = await _uow.ExecuteStoredProcAll<DbContext.Entities.Paciente>("SPRMDS_LIST_PACIENTE");

                List<PacienteDto> listPaciente = new List<PacienteDto>();

                listPaciente = pacientes.Select(p => new PacienteDto { id_paciente = p.CPAC_IDPACIENTE, id_persona = p.CPER_IDPERSONA, id_servicio = p.CSER_IDSERVICIO, estado = p.FPAC_ESTADO }).ToList();

                if (!pacientes.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listPaciente);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }


        public async Task<ServiceResponse> GetPaciente(string pacienteId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ID", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = pacienteId },
                };


                List<DbContext.Entities.Paciente> pacientes = new List<DbContext.Entities.Paciente>();

                pacientes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Paciente>("SPRMDS_LIST_PACIENTE_BY_PARAM", parameters);

                List<PacienteDto> listPaciente = new List<PacienteDto>();

                listPaciente = pacientes.Select(p => new PacienteDto { id_paciente = p.CPAC_IDPACIENTE, id_persona = p.CPER_IDPERSONA, id_servicio = p.CSER_IDSERVICIO, estado = p.FPAC_ESTADO }).ToList();

                if (!listPaciente.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listPaciente);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }



        public async Task<ServiceResponse> AddPaciente(MantenimientoPacienteDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CPER_IDPERSONA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CPER_IDPERSONA },
                    new SqlParameter("@CSER_IDSERVICIO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CSER_IDSERVICIO },
                    new SqlParameter("@DPAC_FINC", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.DPAC_FINC },
                    new SqlParameter("@SPAC_COD_PAR", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.SPAC_COD_PAR },
                    new SqlParameter("@DPAC_FCRE", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.DPAC_FCRE },
                    new SqlParameter("@FPAC_BOL_ACT", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FPAC_BOL_ACT },
                    new SqlParameter("@SPAC_OBS", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPAC_OBS },
                    new SqlParameter("@FPAC_FLG_CORREO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FPAC_FLG_CORREO },
                    new SqlParameter("@SPAC_USUCRE_EMAIL", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPAC_USUCRE_EMAIL },
                    new SqlParameter("@SPAC_USUMODIF_EMAIL", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPAC_USUMODIF_EMAIL },

                    new SqlParameter("@SPAC_FLAG_FICHA", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.SPAC_FLAG_FICHA },
                    new SqlParameter("@FPAC_FLAG_BLOQ", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FPAC_FLAG_BLOQ },
                    new SqlParameter("@FPAC_FLAG_VIP", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FPAC_FLAG_VIP },
                    new SqlParameter("@NPAC_CLASIFICACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NPAC_CLASIFICACION },
                    new SqlParameter("@SPAC_VIP", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPAC_VIP },
                    new SqlParameter("@NPAC_COD_SUBCLASIF", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NPAC_COD_SUBCLASIF },
                    new SqlParameter("@DPAC_FECHA_VIGENCIA", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.DPAC_FECHA_VIGENCIA },
                    new SqlParameter("@FPAC_FLG_REGISTRAR_PAC_TABLET", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FPAC_FLG_REGISTRAR_PAC_TABLET },
                    new SqlParameter("@FPAC_CLAVE", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FPAC_CLAVE },
                    new SqlParameter("@SPAC_TIPO_CLAVE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPAC_TIPO_CLAVE },

                    new SqlParameter("@SPAC_OBS_CLAVE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPAC_OBS_CLAVE },
                    new SqlParameter("@FPAC_CONSENT_INFORMADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FPAC_CONSENT_INFORMADO },
                    new SqlParameter("@FPAC_CONSENT_RECIBIR_INFO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FPAC_CONSENT_RECIBIR_INFO },
                    new SqlParameter("@FPAC_CONSENT_FIRMA_CONST", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FPAC_CONSENT_FIRMA_CONST },
                    new SqlParameter("@FPAC_CONSMT_RI", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FPAC_CONSMT_RI },
                    new SqlParameter("@FPAC_FLG_CONFLICTIVO_CALLMED", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FPAC_FLG_CONFLICTIVO_CALLMED },
                    new SqlParameter("@FPAC_FLG_ACTIVO_FARMACIA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FPAC_FLG_ACTIVO_FARMACIA },
                    new SqlParameter("@NPAC_NORDEN_OBS", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NPAC_NORDEN_OBS },
                    new SqlParameter("@SPAC_GRUPO_CRONICOS", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.SPAC_GRUPO_CRONICOS },
                    new SqlParameter("@FPAC_FLG_PAQUETE_SALUD", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FPAC_FLG_PAQUETE_SALUD },


                    new SqlParameter("@FPAC_ESTADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FPAC_ESTADO },
                    new SqlParameter("@NPAC_USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NPAC_USUARIO_CREACION },
                    new SqlParameter("@DPAC_FECHA_CREACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.DPAC_FECHA_CREACION },
                    new SqlParameter("@NPAC_USUARIO_MODIFICACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NPAC_USUARIO_MODIFICACION },
                    new SqlParameter("@DPAC_FECHA_MODIFICACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.DPAC_FECHA_MODIFICACION },

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_PACIENTE", parameters);

                dto.Id = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

    }
}
