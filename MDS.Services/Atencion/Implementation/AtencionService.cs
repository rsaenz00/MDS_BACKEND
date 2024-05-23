using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using System.Globalization;
using Microsoft.Data.SqlClient;
using MDS.DbContext.Entities;

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
        public async Task<ServiceResponse> GetAtencionesBandeja(string fechaInicio, string fechaFin, string condicion)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isFechaInicio", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = fechaInicio },
                    new SqlParameter("@isFechaFin", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = fechaFin },
                    new SqlParameter("@isCondicion", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = condicion },
                };

                int reporte = 0;
                List<DbContext.Entities.AtencionBandejaSctr> AtencionesSctr = new List<DbContext.Entities.AtencionBandejaSctr>();
                List<DbContext.Entities.AtencionBandejaOtrasLlamadas> AtencionesOtrasLlamadas = new List<DbContext.Entities.AtencionBandejaOtrasLlamadas>();

                List<AtencionBandejaDto> listAtenciones = new List<AtencionBandejaDto>();

                if (condicion.Equals("1"))
                {
                    reporte = 1;

                    AtencionesSctr = await _uow.ExecuteStoredProcByParam<DbContext.Entities.AtencionBandejaSctr>("SPRMDS_LIST_ATENCION", parameters);

                    listAtenciones = AtencionesSctr.Select(s => new AtencionBandejaDto
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
                }
                else
                {
                    reporte = 2;

                    AtencionesOtrasLlamadas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.AtencionBandejaOtrasLlamadas>("SPRMDS_LIST_ATENCION", parameters);

                    listAtenciones = AtencionesOtrasLlamadas.Select(s => new AtencionBandejaDto
                    {
                        cod_atencion = s.cod_atencion,
                        estado = s.estado,
                        fecha_creacion = s.fecha_creacion,
                        hora_creacion = s.hora_creacion,
                        motivo = s.motivo,
                        procedencia = s.procedencia,
                        clinica = s.clinica,
                        departamento = s.departamento,
                        provincia = s.provincia,
                        distrito = s.distrito,
                        persona_reporta = s.persona_reporta,
                        motivo_de_llamada = s.motivo_de_llamada,
                        usuario_creacion = s.usuario_creacion,
                        skill = s.skill
                    }).ToList();
                }

                if (reporte == 0)
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listAtenciones);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetAtencionByCodigo(string cod_atencion)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoAtencion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = cod_atencion }
                };

                List<DbContext.Entities.Atencion> Atencions = new List<DbContext.Entities.Atencion>();

                Atencions = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Atencion>("SPRMDS_LIST_ATENCION_BY_CODIGO", parameters);

                List<AtencionDto> listAtencions = new List<AtencionDto>();

                listAtencions = Atencions.Select(s => new AtencionDto
                {
                    cod_atencion = s.cod_atencion,
                    paciente = s.paciente,
                    fecha_nacimiento = s.fecha_nacimiento,
                    edad = s.edad,
                    sexo = s.sexo,
                    documento_identidad = s.documento_identidad,
                    numero_documento_id = s.numero_documento_id,
                    fecha_creacion = s.fecha_creacion,
                    hora_atencion = s.hora_atencion,
                    descripcion_ipress = s.descripcion_ipress,
                    ipress_telefono = s.ipress_telefono,
                    ipress_anexo = s.ipress_anexo,
                    empresa = s.empresa,
                    empresa_ruc = s.empresa_ruc,
                    horario_trabajo = s.horario_trabajo,
                    puesto_cargo = s.puesto_cargo,
                    relato = s.relato,
                    fecha_accidente = s.fecha_accidente,
                    hora_accidente = s.hora_accidente,
                    tipo_atencion = s.tipo_atencion,
                    tipo_pase_atencion = s.tipo_pase_atencion,
                    motivo = s.motivo,
                    observacion = s.observacion,
                    ipress_primera_ate = s.ipress_primera_ate
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
        public async Task<ServiceResponse> AddAtencion(AtencionMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoPersona", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@inCodigoEmpresa", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_empresa },
                    new SqlParameter("@inCodigoClinica", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_clinica },
                    new SqlParameter("@inCodigoMotivo", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_motivo },
                    new SqlParameter("@inCodigoPlan", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.id_plan },
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
                    new SqlParameter("@isCentroClinico", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.centro_clinico },
                    new SqlParameter("@isEmpresa", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.empresa },
                    new SqlParameter("@isCorredorSeguro", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.corredor_seguro },
                    new SqlParameter("@isPacienteAsegurado", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.paciente_asegurado },
                    new SqlParameter("@isPersonaReportaClinica", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona_reporta_clinica },
                    new SqlParameter("@isPersonaReportaEmpresa", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona_reporta_empresa },
                    new SqlParameter("@isPersonaReportaSeguro", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona_reporta_seguro },
                    new SqlParameter("@isPersonaReportaAsegurado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.persona_reporta_asegurado },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@inEstado", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.estado },
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

        //By Henrry Torres
        public async Task<ServiceResponse> DeleteAtencion(AtencionMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoAtencion", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_atencion },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_eliminacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_DELETE_ATENCION", parameters);

                dto.id_atencion = Convert.ToInt64(response);
                dto.observacion = "borrado";

                return ServiceResponse.ReturnSuccess();

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

    }
}