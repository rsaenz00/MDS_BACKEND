using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;
using MDS.Dto.Resources;
using MDS.DbContext.Entities;

namespace MDS.Services.HistoriaClinica.Implementation
{
    public class HistoriaClinicaService : IHistoriaClinicaService
    {
        private readonly IUnitOfWork _uow;

        public HistoriaClinicaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //SERVICIO SCTR
        //By Henrry Torres
        public async Task<ServiceResponse> GetHistoriasClinicasSctrBandeja(string fechaInicio, string fechaFin, string condicion)
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
                List<DbContext.Entities.HistoriaClinicaBandejaSctr> HistoriasClinicasSctr = new List<DbContext.Entities.HistoriaClinicaBandejaSctr>();
                List<DbContext.Entities.HistoriaClinicaBandejaOtrasLlamadas> HistoriasClinicasOtrasLlamadas = new List<DbContext.Entities.HistoriaClinicaBandejaOtrasLlamadas>();

                List<HistoriaClinicaBandejaDto> listHistoriasClinicas = new List<HistoriaClinicaBandejaDto>();

                if (condicion.Equals("1"))
                {
                    reporte = 1;

                    HistoriasClinicasSctr = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaBandejaSctr>("SPRMDS_LIST_HISTORIA_CLINICA_SCTR", parameters);

                    listHistoriasClinicas = HistoriasClinicasSctr.Select(s => new HistoriaClinicaBandejaDto
                    {
                        cod_historia_clinica = s.cod_historia_clinica,
                        tipo_historia_clinica = s.tipo_historia_clinica,
                        estado = s.estado,
                        fecha_creacion = s.fecha_creacion,
                        hora_creacion = s.hora_creacion,
                        documento_identidad = s.documento_identidad,
                        numero = s.numero,
                        paciente = s.paciente,
                        fecha_nacimiento = s.fecha_nacimiento,
                        clinica = s.clinica,
                        departamento = s.departamento,
                        provincia = s.provincia,
                        distrito = s.distrito,
                        hoja_atencion = s.hoja_atencion,
                        medio_validacion = s.medio_validacion,
                        pase_atencion = s.pase_atencion,
                        observacion = s.observacion,
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

                    HistoriasClinicasOtrasLlamadas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaBandejaOtrasLlamadas>("SPRMDS_LIST_HISTORIA_CLINICA_SCTR", parameters);

                    listHistoriasClinicas = HistoriasClinicasOtrasLlamadas.Select(s => new HistoriaClinicaBandejaDto
                    {
                        cod_historia_clinica = s.cod_historia_clinica,
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

                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetHistoriaClinicaSctrByCodigo(string codHistoriaClinica)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoHistoriaClinica", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = codHistoriaClinica}
                };

                List<DbContext.Entities.HistoriaClinicaSctr> historiasClinicas = new List<DbContext.Entities.HistoriaClinicaSctr>();

                historiasClinicas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaSctr>("SPRMDS_LIST_HISTORIA_CLINICA_BY_CODIGO_SCTR", parameters);

                List<HistoriaClinicaDto> listHistoriasClinicas = new List<HistoriaClinicaDto>();

                listHistoriasClinicas = historiasClinicas.Select(s => new HistoriaClinicaDto
                {
                    cod_historia_clinica = s.cod_historia_clinica,
                    paciente = s.paciente,
                    fecha_nacimiento = s.fecha_nacimiento,
                    edad = s.edad,
                    sexo = s.sexo,
                    celular = s.celular,
                    pais = s.pais,
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
                    tipo_historia_clinica = s.tipo_historia_clinica,
                    pase_atencion = s.pase_atencion,
                    motivo = s.motivo,
                    observacion = s.observacion,
                    ipress_primera_ate = s.ipress_primera_ate,
                    id_clinica = s.id_clinica,
                    persona_reporta = s.persona_reporta,
                    id_cliente = s.id_cliente,
                    id_motivo = s.id_motivo,
                    numero_atencion = s.numero_atencion,
                    metodo_validacion = s.metodo_validacion,
                    hoja_atencion = s.hoja_atencion,
                    id_plan = s.id_plan,
                    skill = s.skill,
                    motivo_skill = s.motivo_skill,
                    id_clinica_primera_atencion = s.id_clinica_primera_atencion
                }).ToList();

                if (!historiasClinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetHistoriasClinicasSctrFiltro(string fechaInicio, string fechaFin, string? busqueda = null, string? condicion = null, int reporte = 0)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isFechaInicio", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = fechaInicio },
                    new SqlParameter("@isFechaFin", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = fechaFin },
                    new SqlParameter("@isTextoBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = busqueda },
                    new SqlParameter("@isCondicion", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = condicion },
                    new SqlParameter("@isReporte", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = reporte },
                };

                List<DbContext.Entities.HistoriaClinicaBandejaSctr> HistoriasClinicasSctr = new List<DbContext.Entities.HistoriaClinicaBandejaSctr>();
                List<DbContext.Entities.HistoriaClinicaBandejaOtrasLlamadas> HistoriasClinicasOtrasLlamadas = new List<DbContext.Entities.HistoriaClinicaBandejaOtrasLlamadas>();

                List<HistoriaClinicaBandejaDto> listHistoriasClinicas = new List<HistoriaClinicaBandejaDto>();

                if (reporte == 1)
                {
                    HistoriasClinicasSctr = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaBandejaSctr>("SPRMDS_LIST_HISTORIA_CLINICA_FILTRO_SCTR", parameters);

                    listHistoriasClinicas = HistoriasClinicasSctr.Select(s => new HistoriaClinicaBandejaDto
                    {
                        cod_historia_clinica = s.cod_historia_clinica,
                        tipo_historia_clinica = s.tipo_historia_clinica,
                        estado = s.estado,
                        fecha_creacion = s.fecha_creacion,
                        hora_creacion = s.hora_creacion,
                        documento_identidad = s.documento_identidad,
                        numero = s.numero,
                        paciente = s.paciente,
                        fecha_nacimiento = s.fecha_nacimiento,
                        clinica = s.clinica,
                        departamento = s.departamento,
                        provincia = s.provincia,
                        distrito = s.distrito,
                        hoja_atencion = s.hoja_atencion,
                        medio_validacion = s.medio_validacion,
                        pase_atencion = s.pase_atencion,
                        observacion = s.observacion,
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
                    HistoriasClinicasOtrasLlamadas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaBandejaOtrasLlamadas>("SPRMDS_LIST_HISTORIA_CLINICA_FILTRO_SCTR", parameters);

                    listHistoriasClinicas = HistoriasClinicasOtrasLlamadas.Select(s => new HistoriaClinicaBandejaDto
                    {
                        cod_historia_clinica = s.cod_historia_clinica,
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

                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddHistoriaClinicaSctr(HistoriaClinicaMtoDto dto)
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
                    new SqlParameter("@isHojaAtencion", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.hoja_atencion },
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
                    new SqlParameter("@inPaseAtencion", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.pase_atencion },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@inCodigoClinicaPrimeraAtencion", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_clinica_primera_atencion },
                    new SqlParameter("@inEstado", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_HISTORIA_CLINICA_SCTR", parameters);

                dto.cod_historia_clinica = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> UpdateHistoriaClinicaSctr(HistoriaClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoHistoriaClinica", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.cod_historia_clinica },
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
                    new SqlParameter("@isHojaAtencion", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.hoja_atencion },
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
                    new SqlParameter("@inPaseAtencion", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.pase_atencion },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@inCodigoClinicaPrimeraAtencion", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_clinica_primera_atencion },
                    new SqlParameter("@inEstado", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_UPDATE_HISTORIA_CLINICA_SCTR", parameters);

                dto.cod_historia_clinica = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> DeleteHistoriaClinicaSctr(HistoriaClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoHistoriaClinica", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.cod_historia_clinica },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_eliminacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_DELETE_HISTORIA_CLINICA", parameters);

                dto.cod_historia_clinica = Convert.ToInt64(response);
                dto.observacion = "borrado";

                return ServiceResponse.ReturnSuccess();

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }
        //FIN SERVICIO SCTR

        //SERVICIO AMBULANCIA
        //By Henrry Torres
        public async Task<ServiceResponse> GetHistoriasClinicasAmbulanciaBandeja(AmbulanciaResource dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    //new SqlParameter("@isCondicion", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = dto.condicion },
                    new SqlParameter("@isTextoBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.busqueda },
                    new SqlParameter("@isFechaInicio", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fechaDesde },
                    new SqlParameter("@isFechaFin", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fechaHasta },
                    new SqlParameter("@isUrgEmeTras", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flagUrgEmeTras },
                    new SqlParameter("@isEventos", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flagEventos },
                    new SqlParameter("@isOmedica", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flagOmedica },
                    new SqlParameter("@isCanceladas", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flagCanceladas },
                    new SqlParameter("@isFinalizadas", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flagFinalizadas },

                    /*new SqlParameter("@isCodigoAtencion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.codigoAtencion },
                    new SqlParameter("@isCodigoSited", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.codigoSited },
                    new SqlParameter("@isCotizado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cotizado },
                    new SqlParameter("@isEstado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@isAmbulanciaRespuesta", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.ambulanciaRespuesta },
                    new SqlParameter("@isServicio", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.servicio },
                    new SqlParameter("@isPaciente", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.paciente },
                    new SqlParameter("@isNumeroDocumento", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.numeroDocumento },
                    new SqlParameter("@isDepartamento", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.departamento },
                    new SqlParameter("@isProvincia", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.provincia },
                    new SqlParameter("@isDistrito", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.distrito },
                    new SqlParameter("@isDireccion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.direccion },
                    new SqlParameter("@isReferencia", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.referencia },
                    new SqlParameter("@isCliente", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cliente },
                    new SqlParameter("@isProveedor", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.proveedor },
                    new SqlParameter("@isAmbulancia", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.ambulancia },
                    new SqlParameter("@isTiempo", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.tiempo },
                    new SqlParameter("@isFechaEstimada", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fechaEstimada },
                    new SqlParameter("@isHoraEstimada", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.horaEstimada },
                    new SqlParameter("@isFechaLlegada", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fechaLlegada },
                    new SqlParameter("@isHoraLlegada", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.horaLlegada },
                    new SqlParameter("@isFechaFinAtencion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.fechaFinAtencion },
                    new SqlParameter("@isHoraFinAtencion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.horaFinAtencion },
                    new SqlParameter("@isTelefonoCelular", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.telefonoCelular },
                    new SqlParameter("@isUsuarioCreacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.usuarioCreacion },
                    new SqlParameter("@isFlagFueraCobertura", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.flagFueraCobertura },
                    new SqlParameter("@isFlagCitrix", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.flagCitrix },
                    new SqlParameter("@isCodigoProv", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.codigoProv },*/

                    new SqlParameter("@inIndex", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.Skip },
                    new SqlParameter("@inTamanoPagina", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.PageSize },
                };

                var listaAmbulancia = await _uow.ExecuteStoredProcPagination<DbContext.Entities.HistoriaClinicaBandejaAmbulancia>("SPRMDS_LIST_HISTORIA_CLINICA_AMBULANCIA", parameters, dto.Skip, dto.PageSize);

                return ServiceResponse.ReturnResultWith200(listaAmbulancia);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddHistoriaClinicaAmbulanciaOrientacionMedica(HistoriaClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    //TBLMDS_HISTORIA_CLINICA
                    new SqlParameter("@inCodigoEmpresa", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_empresa },
                    new SqlParameter("@inCodigoPersona", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@inEstado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@SHIS_CM_ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_ESTADO },
                    new SqlParameter("@NHIS_COD_ESTADO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_ESTADO },
                    new SqlParameter("@NHIS_CM_ORDEN", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_CM_ORDEN },
                    new SqlParameter("@FHIS_FLG_CM_NUEVA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_FLG_CM_NUEVA },
                    new SqlParameter("@SHIS_REF_DIR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_REF_DIR },
                    new SqlParameter("@SHIS_CM_REF_DIR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_REF_DIR },
                    new SqlParameter("@FHIS_FLAG_PROGRAMADA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_FLAG_PROGRAMADA },
                    new SqlParameter("@SHIS_F_PROG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_F_PROG },
                    new SqlParameter("@SHIS_COD_TIPO_PROG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_TIPO_PROG },
                    new SqlParameter("@SHIS_COD_DR_SOLICITADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_DR_SOLICITADO },
                    new SqlParameter("@FHIS_CM_DIRECTA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_CM_DIRECTA },
                    new SqlParameter("@SHIS_FLG_DIRECTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FLG_DIRECTO },
                    new SqlParameter("@FHIS_CM_DATOS_COMPLETOS", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_CM_DATOS_COMPLETOS },
                    new SqlParameter("@NHIS_TAR_ATE", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_TAR_ATE },
                    new SqlParameter("@SHIS_TIPO_SERVAMB_DRMAS", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_SERVAMB_DRMAS },
                    new SqlParameter("@SHIS_COD_AMB_TIPO_SERV", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_AMB_TIPO_SERV },
                    new SqlParameter("@NHIS_COASEGURO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_COASEGURO },
                    new SqlParameter("@SHIS_FLAGMONE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FLAGMONE },
                    new SqlParameter("@NHIS_CAMBIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CAMBIO },
                    new SqlParameter("@SHIS_FOR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FOR_ATE },
                    new SqlParameter("@SHIS_CM_MONEDA_DEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_MONEDA_DEN },
                    new SqlParameter("@NHIS_CM_DEN_CAMBIO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_CM_DEN_CAMBIO },
                    new SqlParameter("@SHIS_CM_DENOMINACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_DENOMINACION },
                    new SqlParameter("@SHIS_CONTACTO_PAC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CONTACTO_PAC },
                    new SqlParameter("@SHIS_CONTACTO_ASEG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CONTACTO_ASEG },
                    new SqlParameter("@SHIS_TIPO_SERVICIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_SERVICIO },
                    new SqlParameter("@NHIS_CLASIFICACION_PAC", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_CLASIFICACION_PAC },
                    new SqlParameter("@SHIS_TIPO_DOC_PAGO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_DOC_PAGO },
                    new SqlParameter("@SHIS_DESCRP_ZONA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_DESCRP_ZONA },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("isObservacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.observacion },
                    new SqlParameter("@NHIS_CLASIFICACION_PAC_CALLMED", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_CLASIFICACION_PAC_CALLMED },                    
                    //SITEDS
                    new SqlParameter("@SHIS_COD_AUT_PRESTACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_AUT_PRESTACION },
                    new SqlParameter("@SHIS_COD_ASEGURADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_ASEGURADO },
                    new SqlParameter("@SHIS_CM_ASEG_PRODUCTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_ASEG_PRODUCTO },
                    new SqlParameter("@SHIS_POLIZA_ASEGURADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_POLIZA_ASEGURADO },
                    new SqlParameter("@SHIS_POLIZA_CERTIFICADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_POLIZA_CERTIFICADO },
                    
                    //TBLMDS_HISTORIA_CLINICA_CALLMEDICO
                    new SqlParameter("@CPAR_ID_SOLICITUD", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CPAR_ID_SOLICITUD },
                    new SqlParameter("@inCodigoMotivo", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CPAR_ID_MOTIVO_CALLMEDICO },
                    new SqlParameter("@CPAR_ID_REFERENCIA_AMBULANCIA", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CPAR_ID_REFERENCIA_AMBULANCIA },
                    new SqlParameter("@CCEN_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CCEN_ID },
                    new SqlParameter("@CECM_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CECM_ID },

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_HISTORIA_CLINICA_AMBULANCIA_ORIENTACION_MEDICA", parameters);

                dto.cod_historia_clinica = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddHistoriaClinicaAmbulancia(HistoriaClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    //TBLMDS_HISTORIA_CLINICA
                    new SqlParameter("@inCodigoEmpresa", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_empresa },
                    new SqlParameter("@inCodigoPersona", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@inEstado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@SHIS_NOM_EMP", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_NOM_EMP },
                    new SqlParameter("@NHIS_EDAD_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_EDAD_ATE },
                    new SqlParameter("@SHIS_CEL_PAC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CEL_PAC },
                    new SqlParameter("@SHIS_CM_REF_DIR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_REF_DIR },
                    new SqlParameter("@NHIS_COD_TARIFA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_TARIFA },
                    new SqlParameter("@SHIS_F_PROG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_F_PROG },
                    new SqlParameter("@SHIS_COD_AMB_TIPO_SERV", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_AMB_TIPO_SERV },
                    new SqlParameter("@FHIS_FLAG_PROGRAMADA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_FLAG_PROGRAMADA },
                    new SqlParameter("@SHIS_PERSONAL_CONTACTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_PERSONAL_CONTACTO },
                    new SqlParameter("@DHIS_HOR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_HOR_ATE },
                    new SqlParameter("@SHIS_COD_EMP", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_EMP },
                    new SqlParameter("@SHIS_AMB_COD_DIS_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_COD_DIS_ORIGEN },
                    new SqlParameter("@SHIS_AMB_DES_DIS_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_DES_DIS_ORIGEN },
                    new SqlParameter("@SHIS_AMB_DIR_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_DIR_ORIGEN },
                    new SqlParameter("@SHIS_AMB_REF_DIR_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_REF_DIR_ORIGEN },
                    new SqlParameter("@DHIS_AMB_FECHA_INI", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_AMB_FECHA_INI },
                    new SqlParameter("@DHIS_AMB_HORA_INI", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_AMB_HORA_INI },
                    new SqlParameter("@DHIS_AMB_FECHA_FIN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_AMB_FECHA_FIN },
                    new SqlParameter("@DHIS_AMB_HORA_FIN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_AMB_HORA_FIN },
                    new SqlParameter("@SHIS_AMB_COD_DIS_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_COD_DIS_DESTINO },
                    new SqlParameter("@SHIS_AMB_DES_DIS_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_DES_DIS_DESTINO },
                    new SqlParameter("@SHIS_AMB_DIR_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_DIR_DESTINO },
                    new SqlParameter("@SHIS_AMB_REF_DIR_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_REF_DIR_DESTINO },
                    new SqlParameter("@SHIS_TIPO_SERVICIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_SERVICIO },
                    new SqlParameter("@NHIS_COD_PRIORIDAD_CALLMED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_PRIORIDAD_CALLMED },
                    new SqlParameter("@NHIS_COD_MOTIVO_ATE_CALLMED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_MOTIVO_ATE_CALLMED },
                    new SqlParameter("@NHIS_TAR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_TAR_ATE },
                    new SqlParameter("@NHIS_COASEGURO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COASEGURO },
                    new SqlParameter("@SHIS_TIPO_DOC_PAGO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_DOC_PAGO },
                    new SqlParameter("@isObservacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.observacion },
                    new SqlParameter("@SHIS_CM_DENOMINACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_DENOMINACION },
                    new SqlParameter("@SHIS_FOR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FOR_ATE },
                    new SqlParameter("@NHIS_ID_TIPO_TRASLADO_CALLMED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_ID_TIPO_TRASLADO_CALLMED },
                    new SqlParameter("@SHIS_COD_AUT_PRESTACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_AUT_PRESTACION },
                    new SqlParameter("@SHIS_CONTRATANTE_CITRIX", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CONTRATANTE_CITRIX },
                    new SqlParameter("@SHIS_COD_ASEGURADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_ASEGURADO },
                    new SqlParameter("@SHIS_CM_ASEG_PRODUCTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_ASEG_PRODUCTO },
                    new SqlParameter("@SHIS_POLIZA_ASEGURADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_POLIZA_ASEGURADO },
                    new SqlParameter("@SHIS_POLIZA_CERTIFICADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_POLIZA_CERTIFICADO },
                    new SqlParameter("@FHIS_AMB_SERVICIO_PLAYA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_AMB_SERVICIO_PLAYA },
                    new SqlParameter("@inEstado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_ESTADO },
                    new SqlParameter("@SHIS_CM_ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_ESTADO },
                    new SqlParameter("@NHIS_COD_ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_ESTADO },
                    new SqlParameter("@NHIS_CM_ORDEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CM_ORDEN },
                    new SqlParameter("@FHIS_FLG_CM_NUEVA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_FLG_CM_NUEVA },
                    new SqlParameter("@SHIS_COD_TIPO_PROG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_TIPO_PROG },
                    new SqlParameter("@SHIS_COD_DR_SOLICITADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_DR_SOLICITADO },
                    new SqlParameter("@FHIS_CM_DIRECTA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_CM_DIRECTA },
                    new SqlParameter("@SHIS_FLG_DIRECTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FLG_DIRECTO },
                    new SqlParameter("@FHIS_CM_DATOS_COMPLETOS", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_CM_DATOS_COMPLETOS },
                    new SqlParameter("@SHIS_FLAGMONE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FLAGMONE },
                    new SqlParameter("@NHIS_CAMBIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CAMBIO },
                    new SqlParameter("@SHIS_CM_MONEDA_DEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_MONEDA_DEN },
                    new SqlParameter("@NHIS_CM_DEN_CAMBIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CM_DEN_CAMBIO },
                    new SqlParameter("@SHIS_CONTACTO_PAC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CONTACTO_PAC },
                    new SqlParameter("@SHIS_CONTACTO_ASEG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CONTACTO_ASEG },
                    new SqlParameter("@NHIS_CLASIFICACION_PAC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CLASIFICACION_PAC },
                    new SqlParameter("@SHIS_DESCRP_ZONA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_DESCRP_ZONA },
                    new SqlParameter("@SHIS_USULLA_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_USULLA_ATE },
                    new SqlParameter("@NHIS_CLASIFICACION_PAC_CALLMED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CLASIFICACION_PAC_CALLMED },
                    new SqlParameter("@DHIS_FEC_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_FEC_ATE },
                    new SqlParameter("@SHIS_TIPO_SERVAMB_DRMAS", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_SERVAMB_DRMAS },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_HISTORIA_CLINICA_AMBULANCIA", parameters);

                dto.cod_historia_clinica = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddHistoriaClinicaAmbulanciaEvento(HistoriaClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    //TBLMDS_HISTORIA_CLINICA
                    new SqlParameter("@inCodigoEmpresa", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_empresa },
                    new SqlParameter("@inCodigoPersona", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = dto.id_persona },
                    new SqlParameter("@inEstado", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@SHIS_NOM_EMP", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_NOM_EMP },
                    new SqlParameter("@NHIS_EDAD_ATE", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NHIS_EDAD_ATE },
                    new SqlParameter("@SHIS_CEL_PAC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CEL_PAC },
                    new SqlParameter("@SHIS_CM_REF_DIR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_REF_DIR },
                    new SqlParameter("@NHIS_COD_TARIFA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_TARIFA },
                    new SqlParameter("@SHIS_F_PROG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_F_PROG },
                    new SqlParameter("@SHIS_COD_AMB_TIPO_SERV", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_AMB_TIPO_SERV },//10
                    new SqlParameter("@SHIS_TIPO_SERVAMB_DRMAS", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_SERVAMB_DRMAS },
                    new SqlParameter("@FHIS_FLAG_PROGRAMADA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_FLAG_PROGRAMADA },
                    new SqlParameter("@SHIS_PERSONAL_CONTACTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_PERSONAL_CONTACTO },
                    new SqlParameter("@DHIS_HOR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_HOR_ATE },
                    new SqlParameter("@SHIS_COD_EMP", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_EMP },
                    new SqlParameter("@SHIS_AMB_COD_DIS_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_COD_DIS_ORIGEN },
                    new SqlParameter("@SHIS_AMB_DES_DIS_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_DES_DIS_ORIGEN },
                    new SqlParameter("@SHIS_AMB_DIR_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_DIR_ORIGEN },
                    new SqlParameter("@SHIS_AMB_REF_DIR_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_REF_DIR_ORIGEN },
                    new SqlParameter("@DHIS_AMB_FECHA_INI", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_AMB_FECHA_INI },//20
                    new SqlParameter("@DHIS_AMB_HORA_INI", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_AMB_HORA_INI },
                    new SqlParameter("@DHIS_AMB_FECHA_FIN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_AMB_FECHA_FIN },
                    new SqlParameter("@DHIS_AMB_HORA_FIN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_AMB_HORA_FIN },
                    new SqlParameter("@SHIS_AMB_COD_DIS_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_COD_DIS_DESTINO },
                    new SqlParameter("@SHIS_AMB_DES_DIS_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_DES_DIS_DESTINO },
                    new SqlParameter("@SHIS_AMB_DIR_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_DIR_DESTINO },
                    new SqlParameter("@SHIS_AMB_REF_DIR_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AMB_REF_DIR_DESTINO },
                    new SqlParameter("@SHIS_TIPO_SERVICIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_SERVICIO },
                    new SqlParameter("@NHIS_COD_PRIORIDAD_CALLMED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_PRIORIDAD_CALLMED },
                    new SqlParameter("@NHIS_COD_MOTIVO_ATE_CALLMED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_MOTIVO_ATE_CALLMED },//30
                    new SqlParameter("@NHIS_TAR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_TAR_ATE },
                    new SqlParameter("@NHIS_COASEGURO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COASEGURO },
                    new SqlParameter("@SHIS_TIPO_DOC_PAGO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_TIPO_DOC_PAGO },
                    new SqlParameter("@isObservacion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.observacion },
                    new SqlParameter("@SHIS_CM_DENOMINACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_DENOMINACION },
                    new SqlParameter("@SHIS_FOR_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FOR_ATE },
                    new SqlParameter("@NHIS_ID_TIPO_TRASLADO_CALLMED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_ID_TIPO_TRASLADO_CALLMED },
                    new SqlParameter("@SHIS_COD_AUT_PRESTACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_AUT_PRESTACION },
                    new SqlParameter("@SHIS_CONTRATANTE_CITRIX", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CONTRATANTE_CITRIX },
                    new SqlParameter("@SHIS_COD_ASEGURADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_ASEGURADO },//40
                    new SqlParameter("@SHIS_CM_ASEG_PRODUCTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_ASEG_PRODUCTO },
                    new SqlParameter("@SHIS_POLIZA_ASEGURADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_POLIZA_ASEGURADO },
                    new SqlParameter("@SHIS_POLIZA_CERTIFICADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_POLIZA_CERTIFICADO },
                    new SqlParameter("@FHIS_AMB_SERVICIO_PLAYA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_AMB_SERVICIO_PLAYA },
                    new SqlParameter("@SHIS_CM_ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_ESTADO },
                    new SqlParameter("@NHIS_COD_ESTADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_COD_ESTADO },
                    new SqlParameter("@NHIS_CM_ORDEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CM_ORDEN },
                    new SqlParameter("@FHIS_FLG_CM_NUEVA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_FLG_CM_NUEVA },
                    new SqlParameter("@SHIS_COD_TIPO_PROG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_TIPO_PROG },
                    new SqlParameter("@SHIS_COD_DR_SOLICITADO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_COD_DR_SOLICITADO },//50
                    new SqlParameter("@FHIS_CM_DIRECTA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_CM_DIRECTA },
                    new SqlParameter("@SHIS_FLG_DIRECTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FLG_DIRECTO },
                    new SqlParameter("@FHIS_CM_DATOS_COMPLETOS", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.FHIS_CM_DATOS_COMPLETOS },
                    new SqlParameter("@SHIS_FLAGMONE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_FLAGMONE },
                    new SqlParameter("@NHIS_CAMBIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CAMBIO },
                    new SqlParameter("@SHIS_CM_MONEDA_DEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CM_MONEDA_DEN },
                    new SqlParameter("@NHIS_CM_DEN_CAMBIO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CM_DEN_CAMBIO },
                    new SqlParameter("@SHIS_CONTACTO_PAC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CONTACTO_PAC },
                    new SqlParameter("@SHIS_CONTACTO_ASEG", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_CONTACTO_ASEG },
                    new SqlParameter("@NHIS_CLASIFICACION_PAC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CLASIFICACION_PAC },//60
                    new SqlParameter("@SHIS_DESCRP_ZONA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_DESCRP_ZONA },
                    new SqlParameter("@SHIS_USULLA_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_USULLA_ATE },
                    new SqlParameter("@NHIS_CLASIFICACION_PAC_CALLMED", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.NHIS_CLASIFICACION_PAC_CALLMED },
                    new SqlParameter("@DHIS_FEC_ATE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_FEC_ATE },
                    new SqlParameter("@FPAC_FLG_CONFLICTIVO_CALLMED", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FPAC_FLG_CONFLICTIVO_CALLMED },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },

                    //TBLMDS_HISTORIA_CLINICA_CALLMEDICO
                    new SqlParameter("@FHIS_FUERA_COBERTURA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_FUERA_COBERTURA },
                    new SqlParameter("@SHIS_DIRECCION_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_DIRECCION_ORIGEN},
                    new SqlParameter("@SHIS_DIRECCION_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_DIRECCION_DESTINO},
                    new SqlParameter("@CCLI_ID_ORIGEN", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CCLI_ID_ORIGEN},//70
                    new SqlParameter("@CCLI_ID_DESTINO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CCLI_ID_DESTINO},
                    new SqlParameter("@SHIS_ALERGIA_MEDICA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_ALERGIA_MEDICA},
                    new SqlParameter("@SHIS_ATENCEDENTE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_ATENCEDENTE},
                    new SqlParameter("@CTAM_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CTAM_ID,},
                    new SqlParameter("@SHIS_RUC_EVENTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_RUC_EVENTO,},
                    new SqlParameter("@SHIS_RAZON_SOCIAL_EVENTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_RAZON_SOCIAL_EVENTO,},
                    new SqlParameter("@SHIS_DIRECCION_FISCAL_EVENTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_DIRECCION_FISCAL_EVENTO,},
                    new SqlParameter("@CPOL_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CPOL_ID,},
                    new SqlParameter("@SHIS_NRO_PLACA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_NRO_PLACA,},
                    new SqlParameter("@SHIS_NRO_POLIZA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_NRO_POLIZA,},//80
                    new SqlParameter("@SHIS_SINIESTRO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_SINIESTRO,},
                    new SqlParameter("@SHIS_AHUTORIZA_CORTESIA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_AHUTORIZA_CORTESIA,},
                    new SqlParameter("@SHIS_REGLA_ORO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_REGLA_ORO,},
                    new SqlParameter("@FHIS_AMB_RESPIRATORIA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_AMB_RESPIRATORIA,},
                    new SqlParameter("@CPAR_ID_SOLICITANTE", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CPAR_ID_SOLICITANTE,},
                    new SqlParameter("@SHIS_UBIC_DENTRO_CLINICA_ORIGEN", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_UBIC_DENTRO_CLINICA_ORIGEN,},
                    new SqlParameter("@SHIS_UBIC_DENTRO_CLINICA_DESTINO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SHIS_UBIC_DENTRO_CLINICA_DESTINO,},
                    new SqlParameter("@NPRV_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NPRV_ID,},
                    new SqlParameter("@DHIS_FECHA_EVENTO_ADVERSO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.DHIS_FECHA_EVENTO_ADVERSO,},
                    new SqlParameter("@CPAR_ID_SOLICITUD", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CPAR_ID_SOLICITUD,},//90
                    new SqlParameter("@FHIS_CITRIX", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FHIS_CITRIX,},

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_HISTORIA_CLINICA_AMBULANCIA_EVENTO", parameters);

                dto.cod_historia_clinica = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> DeleteHistoriaClinicaAmbulancia(HistoriaClinicaMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@inCodigoHistoriaClinica", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.cod_historia_clinica },
                    new SqlParameter("@inCodigoMotivo", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_motivo },
                    new SqlParameter("@inCodigoUsuario", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_eliminacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_DELETE_HISTORIA_CLINICA_AMBULANCIA", parameters);

                dto.cod_historia_clinica = Convert.ToInt64(response);
                dto.observacion = "borrado";

                return ServiceResponse.ReturnSuccess();

            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }
        //FIN SERVICIO AMBULANCIA

        //SERVICIO MAD
        //By Henrry Torres
        public async Task<ServiceResponse> GetHistoriaClinicaMadByCodigo(int historiaClinicaId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isCodigoHistoriaClinica", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = historiaClinicaId },
                };

                List<DbContext.Entities.HistoriaClinicaMad> historiasClinicas = new List<DbContext.Entities.HistoriaClinicaMad>();

                historiasClinicas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.HistoriaClinicaMad>("SPRMDS_LIST_HISTORIA_CLINICA_BY_CODIGO_MAD", parameters);

                List<HistoriaClinicaDto> listHistoriasClinicas = new List<HistoriaClinicaDto>();

                listHistoriasClinicas = historiasClinicas.Select(p => new HistoriaClinicaDto
                {
                    cod_historia_clinica = p.cod_historia_clinica,
                    id_paciente = p.id_paciente,
                    id_medico = p.id_medico,
                    id_cliente = p.id_cliente,
                    vip = p.vip,
                    hora_atencion = p.hora_atencion,
                    fecha_creacion = p.fecha_creacion,
                    sintomas = p.sintomas,
                    tipo_atencion = p.tipo_atencion,
                    programacion = p.programacion,
                    nro_descanso_medico = p.nro_descanso_medico,
                    cambio_realizar = p.cambio_realizar,
                    moneda_deducible = p.moneda_deducible,
                    monto_deducible = p.monto_deducible,
                    coaseguro = p.coaseguro,
                    tipo_documento_pago = p.tipo_documento_pago,
                    numero_documento_pago = p.numero_documento_pago,
                    forma_pago = p.forma_pago,
                    moneda_denominacion = p.moneda_denominacion,
                    monto_denominacion = p.monto_denominacion,
                    fecha_nacimiento = p.fecha_nacimiento,
                    paciente = p.paciente,
                    medico = p.medico,
                    aseguradora = p.aseguradora,
                    especialidad = p.especialidad,
                    telefono = p.telefono,
                    celular = p.celular,
                    anexo = p.anexo,
                    referencia = p.referencia,
                    direccion = p.direccion,
                    provincia = p.provincia,
                    distrito = p.distrito
                }).ToList();

                if (!historiasClinicas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listHistoriasClinicas);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Willian Vilca
        //CONSULTA POR ASEGURADORA = CAJA TEXTO
        public async Task<ServiceResponse> GetHistoriaClinica_Mad_Aseguradora(string vAseguradora)
        {
            try
            {

                SqlParameter[] parameters =
                {
            new SqlParameter("@isAseguradora", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vAseguradora },
        };

                List<DbContext.Entities.ClienteAseguradora> clientes = new List<DbContext.Entities.ClienteAseguradora>();

                clientes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.ClienteAseguradora>("SPRMDS_LIST_HISTORIACLINICA_MAD_ASEGURADORA", parameters);

                List<ClienteAseguradoraDto> listCliente = new List<ClienteAseguradoraDto>();

                listCliente = clientes.Select(c => new ClienteAseguradoraDto
                {
                    //id_cliente = c.CCLT_ID,
                    id_cliente = c.SIAF_FINANCIAMIENTO,
                    nombre = c.SCLT_NOMBRE
                }).ToList();


                if (!listCliente.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listCliente);
            }
            catch (Exception e)
            {
                return ServiceResponse.Return500(e);
            }
        }

        //By Willian Vilca
        public async Task<ServiceResponse> AddHistoriaClinicaSiteds(SitedsMtoDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {

                            new SqlParameter("@CHIS_ID"                             ,SqlDbType.Int) {Direction = ParameterDirection.Input,Value = dto.id_historia },
                            new SqlParameter("@SSIT_DOCUMENTOAUTORIZACION"          ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.documentoautorizacion },
                            new SqlParameter("@SSIT_CODIGOAFILIADO"                 ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codigoafiliado },
                            new SqlParameter("@SSIT_NUMEROPOLIZA"                   ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.numeropoliza },
                            new SqlParameter("@SSIT_NUMEROCONTRATO"                 ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.numerocontrato },
                            new SqlParameter("@SSIT_NUMEROCERTIFICADO"              ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.numerocertificado },
                            new SqlParameter("@SSIT_CODPRODUCTO"                    ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codproducto },
                            new SqlParameter("@SSIT_DESPRODUCTO"                    ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.desproducto },
                            new SqlParameter("@SSIT_APELLIDOPATERNOAFILIADO"        ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.apellidopaternoafiliado },
                            new SqlParameter("@SSIT_APELLIDOMATERNOAFILIADO"        ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.apellidomaternoafiliado },
                            new SqlParameter("@SSIT_NOMBRESAFILIADO"                ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.nombresafiliado },
                            new SqlParameter("@SSIT_CODGENERO"                      ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codgenero },
                            new SqlParameter("@SSIT_DESGENERO"                      ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.desgenero },
                            new SqlParameter("@SSIT_CODFECHANACIMIENTO"             ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codfechanacimiento },
                            new SqlParameter("@SSIT_FECHANACIMIENTO"                ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.fechanacimiento },
                            new SqlParameter("@SSIT_CODPARENTESCO"                  ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codparentesco },
                            new SqlParameter("@SSIT_DESPARENTESCO"                  ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.desparentesco },
                            new SqlParameter("@SSIT_CODTIPODOCUMENTOAFILIADO"       ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codtipodocumentoafiliado },
                            new SqlParameter("@SSIT_DESTIPODOCUMENTOAFILIADO"       ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.destipodocumentoafiliado },
                            new SqlParameter("@SSIT_NUMERODOCUMENTOAFILIADO"        ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.numerodocumentoafiliado },
                            new SqlParameter("@NSIT_EDAD"                           ,SqlDbType.Int) {Direction = ParameterDirection.Input,Value =     dto.edad },
                            new SqlParameter("@SSIT_CODFECHAINICIOVIGENCIA"         ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codfechainiciovigencia },
                            new SqlParameter("@SSIT_FECHAINICIOVIGENCIA"            ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.fechainiciovigencia },
                            new SqlParameter("@SSIT_CODFECHAFINVIGENCIA"            ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codfechafinvigencia },
                            new SqlParameter("@SSIT_FECHAFINVIGENCIA"               ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.fechafinvigencia },
                            new SqlParameter("@SSIT_CODESTADOCIVIL"                 ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codestadocivil },
                            new SqlParameter("@SSIT_DESESTADOCIVIL"                 ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.desestadocivil },
                            new SqlParameter("@NSIT_CODTIPOPLAN"                    ,SqlDbType.Int) {Direction = ParameterDirection.Input,Value = dto.codtipoplan },
                            new SqlParameter("@SSIT_DESTIPOPLAN"                    ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.destipoplan },
                            new SqlParameter("@NSIT_NUMEROPLAN"                     ,SqlDbType.Int) {Direction = ParameterDirection.Input,Value = dto.numeroplan },
                            new SqlParameter("@SSIT_CODESTADO"                      ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codestado },
                            new SqlParameter("@SSIT_DESESTADO"                      ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.desestado },
                            new SqlParameter("@SSIT_CODFECHAACTUALIZACIONFOTO"      ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codfechaactualizacionfoto },
                            new SqlParameter("@SSIT_FECHAACTUALIZACIONFOTO"         ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.fechaactualizacionfoto },
                            new SqlParameter("@SSIT_APELLIDOPATERNOTITULAR"         ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.apellidopaternotitular },
                            new SqlParameter("@SSIT_APELLIDOMATERNOTITULAR"         ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.apellidomaternotitular },
                            new SqlParameter("@SSIT_NOMBRESTITULAR"                 ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.nombrestitular },
                            new SqlParameter("@SSIT_CODIGOTITULAR"                  ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codigotitular },
                            new SqlParameter("@SSIT_CODTIPODOCUMENTOTITULAR"        ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codtipodocumentotitular },
                            new SqlParameter("@SSIT_DESTIPODOCUMENTOTITULAR"        ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.destipodocumentotitular },
                            new SqlParameter("@SSIT_NUMERODOCUMENTOTITULAR"         ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.numerodocumentotitular },
                            new SqlParameter("@NSIT_CODMONEDA"                      ,SqlDbType.Int) {Direction = ParameterDirection.Input,Value =     dto.codmoneda },
                            new SqlParameter("@SSIT_DESMONEDA"                      ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.desmoneda },
                            new SqlParameter("@SSIT_NOMBRECONTRATANTE"              ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.nombrecontratante },
                            new SqlParameter("@SSIT_CODTIPODOCUMENTOCONTRATANTE"    ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codtipodocumentocontratante },
                            new SqlParameter("@SSIT_DESTIPODOCUMENTOCONTRATANTE"    ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.destipodocumentocontratante },
                            new SqlParameter("@SSIT_CODTIPOAFILIACION"              ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codtipoafiliacion },
                            new SqlParameter("@SSIT_DESTIPOAFILIACION"              ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.destipoafiliacion },
                            new SqlParameter("@SSIT_CODFECHAAFILIACION"             ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codfechaafiliacion },
                            new SqlParameter("@SSIT_FECHAAFILIACION"                ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.fechaafiliacion },
                            new SqlParameter("@SSIT_NUMERODOCUMENTOCONTRATANTE"     ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.numerodocumentocontratante },
                            new SqlParameter("@SSIT_CODIGOTIPOCOBERTURA"            ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codigotipocobertura },
                            new SqlParameter("@SSIT_CODIGOSUBTIPOCOBERTURA"         ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codigosubtipocobertura },
                            new SqlParameter("@SSIT_CODIGOCOBERTURA"                ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codigocobertura },
                            new SqlParameter("@SSIT_BENEFICIOS"                     ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.beneficios },
                            new SqlParameter("@SSIT_CODINDICADORRESTRICCION"        ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codindicadorrestriccion },
                            new SqlParameter("@SSIT_RESTRICCIONES"                  ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.restricciones },
                            new SqlParameter("@NSIT_CODCOPAGOFIJO"                  ,SqlDbType.Decimal) {Direction = ParameterDirection.Input,Value = dto.codcopagofijo },
                            new SqlParameter("@SSIT_DESCOPAGOFIJO"                  ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.descopagofijo },
                            new SqlParameter("@NSIT_CODCOPAGOVARIABLE"              ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codcopagovariable },
                            new SqlParameter("@SSIT_DESCOPAGOVARIABLE"              ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.descopagovariable },
                            new SqlParameter("@SSIT_CODFECHAFINCARENCIA"            ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codfechafincarencia },
                            new SqlParameter("@SSIT_FECHAFINCARENCIA"               ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.fechafincarencia },
                            new SqlParameter("@SSIT_CONDICIONESESPECIALES"          ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.condicionesespeciales },
                            new SqlParameter("@SSIT_OBSERVACIONES"                  ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.observaciones },
                            new SqlParameter("@SSIT_CODCALIFICACIONSERVICIO"        ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.codcalificacionservicio },
                            new SqlParameter("@SSIT_DESCALIFICACIONSERVICIO"        ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.descalificacionservicio },
                            new SqlParameter("@SSIT_BENEFICIOMAXIMOINICIAL"         ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.beneficiomaximoinicial },
                            new SqlParameter("@SSIT_NUMEROCOBERTURA"                ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.numerocobertura },
                            new SqlParameter("@SSIT_FECHA_CREACION_DOC_AUT"         ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.fecha_creacion_doc_aut },
                            new SqlParameter("@DSIT_HORA_CREACION_DOC_AUT"          ,SqlDbType.DateTime) {Direction = ParameterDirection.Input,Value = dto.hora_creacion_doc_aut },
                            new SqlParameter("@SSIT_DESCRIPCION_PRODUCTO"           ,SqlDbType.VarChar) {Direction = ParameterDirection.Input,Value = dto.descripcion_producto },
                            new SqlParameter("@NSIT_USUARIO_CREACION"               ,SqlDbType.Int) {Direction = ParameterDirection.Input,Value = dto.usuario_creacion },
                            new SqlParameter("@DSIT_FECHA_CREACION"                 ,SqlDbType.DateTime) {Direction = ParameterDirection.Input,Value = dto.fecha_creacion },
                            new SqlParameter("@NSIT_USUARIO_MODIFICACION"           ,SqlDbType.Int) {Direction = ParameterDirection.Input,Value = dto.usuario_modificacion },
                            new SqlParameter("@DSIT_FECHA_MODIFICACION"             ,SqlDbType.DateTime) {Direction = ParameterDirection.Input,Value = dto.fecha_modificacion },

                            new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}

                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_ADD_SITEDS", parameters);

                dto.id_siteds = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }
        //FIN SERVICIO MAD
    }
}