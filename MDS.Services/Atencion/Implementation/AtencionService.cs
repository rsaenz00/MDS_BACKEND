using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace MDS.Services.Atencion.Implementation
{
    public class AtencionService : IAtencionService
    {
        private readonly IUnitOfWork _uow;

        public AtencionService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetAtenciones()
        {
            try
            {
                List<DbContext.Entities.Atencion> Atencions = new List<DbContext.Entities.Atencion>();

                Atencions = await _uow.ExecuteStoredProcAll<DbContext.Entities.Atencion>("SPRMDS_LIST_ATENCION");

                List<AtencionDto> listAtencions = new List<AtencionDto>();

                listAtencions = Atencions.Select(s => new AtencionDto
                {
                    id_atencion = s.CATE_ID,
                    id_persona = s.CPER_ID,
                    id_empresa = s.CEMP_ID,
                    id_clinica = s.CCLI_ID,
                    id_motivo = s.CMOT_ID,
                    id_plan = s.CPLA_ID,
                    telefono = s.SATE_TELEFONO,
                    anexo = s.SATE_ANEXO,
                    horario_trabajo = s.SATE_HORARIO_TRABAJO,
                    cargo = s.SATE_CARGO,
                    relato = s.SATE_RELATO,
                    fecha_accidente = s.DATE_FECHA_ACCIDENTE,
                    hora_accidente = s.DATE_HORA_ACCIDENTE,
                    observacion = s.SATE_OBSERVACION,
                    primera_atencion = s.SATE_PRIMERA_ATENCION,
                    metodo_validacion = s.SATE_METODO_VALIDACION,
                    hoja_atencion = s.SATE_HOJA_ATENCION,
                    ubigeo = s.CUBI_UBIGEO,
                    skill = s.NATE_SKILL,
                    motivo_skill = s.NATE_MOTIVO_SKILL,
                    centro_clinico = s.FATE_CENTRO_CLINICO,
                    empresa = s.FATE_EMPRESA,
                    corredor_seguro = s.FATE_CORREDOR_SEGURO,
                    paciente_asegurado = s.FATE_PACIENTE_ASEGURADO,
                    persona_reporta_clinica = s.SATE_PERSONA_REPORTA_CLINICA,
                    persona_reporta_asegurado = s.SATE_PERSONA_REPORTA_ASEGURADO,
                    persona_reporta_empresa = s.SATE_PERSONA_REPORTA_EMPRESA,
                    persona_reporta_seguro = s.SATE_PERSONA_REPORTA_SEGURO,
                    estado = s.FATE_ESTADO
                }).ToList();

                if (!Atencions.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listAtencions);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetAtencionesBandeja()
        {
            try
            {
                List<DbContext.Entities.AtencionBandeja> Atencions = new List<DbContext.Entities.AtencionBandeja>();

                Atencions = await _uow.ExecuteStoredProcAll<DbContext.Entities.AtencionBandeja>("SPRMDS_LIST_ATENCION");

                List<AtencionBandejaDto> listAtencions = new List<AtencionBandejaDto>();

                listAtencions = Atencions.Select(s => new AtencionBandejaDto
                {
                    cod_atencion = s.cod_atencion,
                    tipo_atencion = s.tipo_atencion,
                    estado = s.estado,
                    fecha_creacion = s.fecha_creacion,
                    hora_creacion = s.hora_creacion,
                    documento_identidad = s.documento_identidad,
                    numero = s.numero,
                    paciente = s.paciente,
                    fecha_nacimiento = s.fecha_nacimiento,
                    clinica = s.clinica,
                    empresa = s.empresa,
                    empresa_ruc = s.empresa_ruc,
                    usuario_creacion = s.usuario_creacion,
                    motivo = s.motivo,
                    plan = s.plan,
                    skill = s.skill
                }).ToList();

                if (!Atencions.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listAtencions);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddAtencion(AtencionDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoPersona", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@inCodigoEmpresa", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_empresa },
                    new SqlParameter("@inCodigoClinica", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_clinica },
                    new SqlParameter("@inCodigoMotivo", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_motivo },
                    new SqlParameter("@inCodigoPlan", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_plan },
                    new SqlParameter("@isTelefoono", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.telefono },
                    new SqlParameter("@isAnexo", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.anexo },
                    new SqlParameter("@isHorarioTrabajo", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.horario_trabajo },
                    new SqlParameter("@isCargo", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cargo },
                    new SqlParameter("@isRelato", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.relato },
                    new SqlParameter("@isFechaAccidente", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fecha_accidente },
                    new SqlParameter("@isHoraAccidente", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.hora_accidente },
                    new SqlParameter("@isObservacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.observacion },
                    new SqlParameter("@isPrimeraAtencion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.primera_atencion },
                    new SqlParameter("@isMetodoValidacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.metodo_validacion },
                    new SqlParameter("@isHojaAtencion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.hoja_atencion },
                    new SqlParameter("@isUbigeo", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.ubigeo },
                    new SqlParameter("@isSkill", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.skill },
                    new SqlParameter("@isMotivoSkill", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.motivo_skill },
                    new SqlParameter("@isCentroClinico", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.centro_clinico },
                    new SqlParameter("@isEmpresa", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.empresa },
                    new SqlParameter("@isCorredorSeguro", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.corredor_seguro },
                    new SqlParameter("@isPacienteAsegurado", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.paciente_asegurado },
                    new SqlParameter("@isPersonaReportaClinica", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona_reporta_clinica },
                    new SqlParameter("@isPersonaReportaEmpresa", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona_reporta_empresa },
                    new SqlParameter("@isPersonaReportaSeguro", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona_reporta_seguro },
                    new SqlParameter("@isPersonaReportaAsegurado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona_reporta_asegurado },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_ATENCION", parameters);

                dto.id_atencion = Convert.ToInt64(response);

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