using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Dto.List;
using MDS.Dto.Resources;
using MDS.Services.HistoriaClinica;
using MDS.Utility.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class HistoriaClinicaController : BaseController
    {
        private readonly IHistoriaClinicaService _historiaClinicaService;

        public HistoriaClinicaController(IHistoriaClinicaService historiaClinicaService)
        {
            _historiaClinicaService = historiaClinicaService;
        }

        //////////////////          SERVICIO MAD          //////////////////

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Mad_Cliente")]
        public async Task<IActionResult> GetHistoriaClinica_Mad_Cliente(string vNumero)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Cliente_Codigo(vNumero);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetSiteds_Codigo")]
        public async Task<IActionResult> GetSiteds_Codigo(string vCodigo)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Siteds_Codigo(vCodigo);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetSiteds_Numero")]
        public async Task<IActionResult> GetSiteds_Numero(string vNumero)
        {
            var response = await _historiaClinicaService.GetSiteds_Numero(vNumero);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Mad_Filtro")]
        public async Task<IActionResult> GetHistoriaClinica_Mad_Filtro(string? vCampoBusqueda = null, string? vValorBusqueda = null, string? vFechaInicio = null, string? vFechaFinal = null)
        {
            var response = await _historiaClinicaService.GetHistoriasClinicasMadFiltro(vCampoBusqueda, vValorBusqueda, vFechaInicio, vFechaFinal);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Mad_Filtro_Rango_By_Fechas")]
        public async Task<IActionResult> GetHistoriaClinica_Mad_Filtro_Rango_By_Fechas(string? vFechaInicio = null, string? vFechaFinal = null)
        {
            var response = await _historiaClinicaService.GetHistoriasClinicasMadFiltro_Rango_By_Fechas(vFechaInicio, vFechaFinal);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Mad_Filtro_Campos")]
        public async Task<IActionResult> GetHistoriaClinica_Mad_Filtro_Campos(string? vCampoBusqueda = null, string? vValorBusqueda = null)
        {
            var response = await _historiaClinicaService.GetHistoriasClinicasMadFiltro_Campos(vCampoBusqueda, vValorBusqueda);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Paciente_x_Numero")]
        public async Task<IActionResult> GetHistoriaClinica_Paciente_x_Numero(string vNumero)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Paciente_Dni(vNumero);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Clientes_Siteds")]
        public async Task<IActionResult> GetHistoriaClinica_Clientes_Siteds()
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Clientes_Siteds();
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Clientes_Siteds_By_Nombre")]
        public async Task<IActionResult> GetHistoriaClinica_Clientes_Siteds_By_Nombre(string vCliente)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Clientes_Siteds_By_Nombre(vCliente);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Paciente_Distrito")]
        public async Task<IActionResult> GetHistoriaClinica_Paciente_Distrito(string vDistrito)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Paciente_Distrito(vDistrito);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Aseguradora")]
        public async Task<IActionResult> GetHistoriaClinica_Aseguradora(string vAseguradora)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Aseguradora(vAseguradora);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Aseguradora_Categoria")]
        public async Task<IActionResult> GetHistoriaClinica_Aseguradora_Categoria(string vAseguradora)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Aseguradora_Categoria(vAseguradora);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Genero")]
        public async Task<IActionResult> GetHistoriaClinica_Genero()
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Genero();
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_TipoDocumento")]
        public async Task<IActionResult> GetHistoriaClinica_TipoDocumento()
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_TipoDocumento();
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Vip")]
        public async Task<IActionResult> GetHistoriaClinica_Vip()
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Vip();
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Seguro")]
        public async Task<IActionResult> GetHistoriaClinica_Seguro()
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Seguro();
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Clasificacion")]
        public async Task<IActionResult> GetHistoriaClinica_Clasificacion()
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Clasificacion();
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Ubigeo_Codigo")]
        public async Task<IActionResult> GetHistoriaClinica_Ubigeo_Codigo(string vDepartamento, string vProvincia, string vDistrito)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Ubigeo_Codigo(vDepartamento, vProvincia, vDistrito);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Ubigeo")]
        public async Task<IActionResult> GetHistoriaClinica_Ubigeo(string vDistrito)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Ubigeo(vDistrito);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Dni")]
        public async Task<IActionResult> GetHistoriaClinica_Dni()
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Mad_Dni();
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica_Paciente_x_Dni")]
        public async Task<IActionResult> GetHistoriaClinica_Paciente_x_Dni(string vDni, string vNumero)
        {
            var response = await _historiaClinicaService.GetHistoriaClinica_Paciente_x_Dni(vDni, vNumero);
            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriaClinica")]
        public async Task<IActionResult> GetHistoriaClinicas()
        {
            var response = await _historiaClinicaService.GetHistoriaClinicas();

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpGet, Route("GetHistoriasClinicas")]
        public async Task<IActionResult> GetHistoriasClinicas(string vFechaIni, string vFechaFin, string vCondicion)
        {
            var response = await _historiaClinicaService.GetHistoriasClinicas(vFechaFin, vFechaFin, vCondicion);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetHistoriaClinicaMadByCodigo")]
        public async Task<IActionResult> GetHistoriaClinicaMadByCodigo(int historiaClinicaId)
        {
            var response = await _historiaClinicaService.GetHistoriaClinicaMadByCodigo(historiaClinicaId);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("AddHistoriaClinicaSiteds")]
        public async Task<IActionResult> AddHistoriaClinicaSiteds(CreateSitedsViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            SitedsMtoDto dto = new SitedsMtoDto
            {
                //csit_id = model.csit_id,
                id_historia = model.id_historia,
                documentoautorizacion = model.documentoautorizacion,
                codigoafiliado = model.codigoafiliado,
                numeropoliza = model.numeropoliza,
                numerocontrato = model.numerocontrato,
                numerocertificado = model.numerocertificado,
                codproducto = model.codproducto,
                desproducto = model.desproducto,
                apellidopaternoafiliado = model.apellidopaternoafiliado,
                apellidomaternoafiliado = model.apellidomaternoafiliado,
                nombresafiliado = model.nombresafiliado,
                codgenero = model.codgenero,
                desgenero = model.desgenero,
                codfechanacimiento = model.codfechanacimiento,
                fechanacimiento = model.fechanacimiento,
                codparentesco = model.codparentesco,
                desparentesco = model.codparentesco,
                codtipodocumentoafiliado = model.codtipodocumentoafiliado,
                destipodocumentoafiliado = model.destipodocumentoafiliado,
                numerodocumentoafiliado = model.numerodocumentoafiliado,
                edad = model.edad,
                codfechainiciovigencia = model.codfechafinvigencia,
                fechainiciovigencia = model.fechainiciovigencia,
                codfechafinvigencia = model.codfechafinvigencia,
                fechafinvigencia = model.fechafinvigencia,
                codestadocivil = model.codestadocivil,
                desestadocivil = model.desestadocivil,
                codtipoplan = model.codtipoplan,
                destipoplan = model.destipoplan,
                numeroplan = model.numeroplan,
                codestado = model.codestado,
                desestado = model.desestado,
                codfechaactualizacionfoto = model.codfechaactualizacionfoto,
                fechaactualizacionfoto = model.fechaactualizacionfoto,
                apellidopaternotitular = model.apellidopaternotitular,
                apellidomaternotitular = model.apellidomaternotitular,
                nombrestitular = model.nombrestitular,
                codigotitular = model.codigotitular,
                codtipodocumentotitular = model.codtipodocumentotitular,
                destipodocumentotitular = model.destipodocumentotitular,
                numerodocumentotitular = model.numerodocumentotitular,
                codmoneda = model.codmoneda,
                desmoneda = model.desmoneda,
                nombrecontratante = model.nombrecontratante,
                codtipodocumentocontratante = model.codtipodocumentocontratante,
                destipodocumentocontratante = model.destipodocumentocontratante,
                codtipoafiliacion = model.codtipoafiliacion,
                destipoafiliacion = model.destipoafiliacion,
                codfechaafiliacion = model.codfechaafiliacion,
                fechaafiliacion = model.fechaafiliacion,
                numerodocumentocontratante = model.numerodocumentocontratante,
                codigotipocobertura = model.codigosubtipocobertura,
                codigosubtipocobertura = model.codigosubtipocobertura,
                codigocobertura = model.codigocobertura,
                beneficios = model.beneficios,
                codindicadorrestriccion = model.codindicadorrestriccion,
                restricciones = model.restricciones,
                codcopagofijo = model.codcopagofijo,
                descopagofijo = model.descopagofijo,
                codcopagovariable = model.codcopagovariable,
                descopagovariable = model.descopagovariable,
                codfechafincarencia = model.codfechafincarencia,
                fechafincarencia = model.fechafincarencia,
                condicionesespeciales = model.condicionesespeciales,
                observaciones = model.observaciones,
                codcalificacionservicio = model.codcalificacionservicio,
                descalificacionservicio = model.descalificacionservicio,
                beneficiomaximoinicial = model.beneficiomaximoinicial,
                numerocobertura = model.numerocobertura,
                fecha_creacion_doc_aut = model.fecha_creacion_doc_aut,
                hora_creacion_doc_aut = model.hora_creacion_doc_aut,
                descripcion_producto = model.descripcion_producto,
                usuario_creacion = model.usuario_creacion,
                fecha_creacion = model.fecha_creacion,
                usuario_modificacion = model.usuario_modificacion,
                fecha_modificacion = model.fecha_modificacion
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaSiteds(dto);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("AddHistoriaClinicaMedioComunicacionMad")]
        public async Task<IActionResult> AddHistoriaClinicaMedioComunicacionMad(CreateHistoriaClinicaMedioComunicacionMadViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMedioComunicacionMtoMadDto dto = new HistoriaClinicaMedioComunicacionMtoMadDto
            {
                id_comunicacion = model.id_comunicacion,
                numero = model.numero,
                usuario_creacion = model.usuario_creacion,
                fecha_creacion = model.fecha_creacion,
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaMedioComunicacionMad(dto);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("RegistrarHistoriaClinica")]
        public async Task<IActionResult> RegistrarHistoriaClinica(RegistrarHistoriaClinicaModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            RegistrarHistoriaClinicaDto dto = new RegistrarHistoriaClinicaDto
            {
                e = model.e,
                prog = model.prog,
                codate = model.codate,
                clasif = model.clasif,
                e_tablet = model.e_tablet,
                codautorizacion = model.codautorizacion,
                feclla = model.feclla,
                hrlla = model.hrlla,
                tiempo = model.tiempo,
                fecate = model.fecate,
                hrxdefecto = model.hrxdefecto,
                hrestimada = model.hrestimada,
                hrllegada = model.hrllegada,
                provincia = model.provincia,
                distrito = model.distrito,
                paciente = model.paciente,
                fpago = model.fpago,
                vip = model.vip,
                grupo = model.grupo,
                periodo = model.periodo,
                cont = model.cont,
                perfil = model.perfil,
                espec = model.espec,
                doctor = model.doctor,
                grupos = model.grupos,
                empresa = model.empresa,
                usuario = model.usuario,
                cod_doc = model.cod_doc,
            };

            var response = await _historiaClinicaService.RegistrarHistoriaClinica(dto);

            return ReturnFormattedResponse(response);
        }

        //By William Vilca
        [HttpPost, Route("AddHistoriaClinicaMad")]
        public async Task<IActionResult> AddHistoriaClinicaMad(CreateHistoriaClinicaMadViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMtoMadDto dto = new HistoriaClinicaMtoMadDto
            {
                cmed_id = model.cmed_id,

                cpac_id = model.cpac_id,

                cesp_id = model.cesp_id,

                cest_id = model.cest_id,

                cper_id = model.cper_id,

                cser_id = model.cser_id,

                cpai_id = model.cpai_id,

                cubi_id = model.cubi_id,

                cmep_id = model.cmep_id,

                ctdo_id = model.ctdo_id,

                cclt_id = model.cclt_id,

                cdsn_id = model.cdsn_id,

                estado = model.estado,

                prog = model.prog,

                codautorizacion = model.codautorizacion,

                feclla = model.feclla,

                horlla = model.horlla,

                tiempo = model.tiempo,

                fecate = model.fecate,

                horate = model.horate,

                hrlledr = model.hrlledr,

                horoplla = model.horoplla,

                fpago = model.fpago,

                vip = model.vip,

                grupo = model.grupo,

                cont = model.cont,

                perfil = model.perfil,

                empresa = model.empresa,


                usuariocreacion = model.usuariocreacion,

                //fechacreacion = model.fechacreacion,

            };

            var response = await _historiaClinicaService.AddHistoriaClinicaMad(dto);

            return ReturnFormattedResponse(response);
        }
        //////////////////          FIN SERVICIO MAD          //////////////////

        //////////////////          SERVICIO SCTR          //////////////////

        //By Henrry Torres
        [HttpGet, Route("GetHistoriaClinicaSctrByCodigo")]
        public async Task<IActionResult> GetHistoriaClinicaSctrByCodigo(string cod_historia_clinica)
        {
            var response = await _historiaClinicaService.GetHistoriaClinicaSctrByCodigo(cod_historia_clinica);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetHistoriasClinicasSctrBandeja")]
        public async Task<IActionResult> GetHistoriasClinicasSctrBandeja(string fechaInicio, string fechaFin, string condicion)
        {
            var response = await _historiaClinicaService.GetHistoriasClinicasSctrBandeja(fechaInicio, fechaFin, condicion);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetHistoriasClinicasSctrFiltro")]
        public async Task<IActionResult> GetHistoriasClinicasSctrFiltro(string fechaInicio, string fechaFin, string? busqueda, string? condicion, int reporte)
        {
            var response = await _historiaClinicaService.GetHistoriasClinicasSctrFiltro(fechaInicio, fechaFin, busqueda, condicion, reporte);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddHistoriaClinicaSctr")]
        public async Task<IActionResult> AddHistoriaClinicaSctr(CreateHistoriaClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMtoDto dto = new HistoriaClinicaMtoDto
            {
                id_persona = model.id_persona,
                id_clinica = model.id_clinica,
                id_empresa = model.id_empresa,
                id_motivo = model.id_motivo,
                id_plan = model.id_plan,
                horario_trabajo = model.horario_trabajo,
                cargo = model.cargo,
                relato = model.relato,
                fecha_accidente = model.fecha_accidente,
                hora_accidente = model.hora_accidente,
                observacion = model.observacion,
                primera_atencion = model.primera_atencion,
                metodo_validacion = model.metodo_validacion,
                hoja_atencion = model.hoja_atencion,
                ubigeo = model.ubigeo,
                skill = model.skill,
                motivo_skill = model.motivo_skill,
                centro_clinico = model.centro_clinico,
                empresa = model.empresa,
                corredor_seguro = model.corredor_seguro,
                paciente_asegurado = model.paciente_asegurado,
                persona_reporta_clinica = model.persona_reporta_clinica,
                persona_reporta_asegurado = model.persona_reporta_asegurado,
                persona_reporta_empresa = model.persona_reporta_empresa,
                persona_reporta_seguro = model.persona_reporta_seguro,
                usuario_creacion = model.usuario_creacion,
                id_clinica_primera_atencion = model.id_clinica_primera_atencion,
                pase_atencion = model.pase_atencion,
                estado = model.estado
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaSctr(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPut, Route("UpdateHistoriaClinicaSctr")]
        public async Task<IActionResult> UpdateHistoriaClinicaSctr(UpdateHistoriaClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMtoDto dto = new HistoriaClinicaMtoDto
            {
                cod_historia_clinica = model.cod_historia_clinica,
                id_persona = model.id_persona,
                id_clinica = model.id_clinica,
                id_empresa = model.id_empresa,
                id_motivo = model.id_motivo,
                id_plan = model.id_plan,
                horario_trabajo = model.horario_trabajo,
                cargo = model.cargo,
                relato = model.relato,
                fecha_accidente = model.fecha_accidente,
                hora_accidente = model.hora_accidente,
                observacion = model.observacion,
                primera_atencion = model.primera_atencion,
                metodo_validacion = model.metodo_validacion,
                hoja_atencion = model.hoja_atencion,
                ubigeo = model.ubigeo,
                skill = model.skill,
                motivo_skill = model.motivo_skill,
                centro_clinico = model.centro_clinico,
                empresa = model.empresa,
                corredor_seguro = model.corredor_seguro,
                paciente_asegurado = model.paciente_asegurado,
                persona_reporta_clinica = model.persona_reporta_clinica,
                persona_reporta_asegurado = model.persona_reporta_asegurado,
                persona_reporta_empresa = model.persona_reporta_empresa,
                persona_reporta_seguro = model.persona_reporta_seguro,
                usuario_creacion = model.usuario_modificacion,
                id_clinica_primera_atencion = model.id_clinica_primera_atencion,
                pase_atencion = model.pase_atencion,
                estado = model.estado
            };

            var response = await _historiaClinicaService.UpdateHistoriaClinicaSctr(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpDelete, Route("DeleteHistoriaClinicaSctr")]
        public async Task<IActionResult> DeleteHistoriaClinicaSctr(DeleteHistoriaClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMtoDto dto = new HistoriaClinicaMtoDto
            {
                cod_historia_clinica = model.cod_historia_clinica,
                usuario_eliminacion = model.usuario_eliminacion
            };

            var response = await _historiaClinicaService.DeleteHistoriaClinicaSctr(dto);

            return ReturnFormattedResponse(response);
        }

        //////////////////          FIN SERVICIO SCTR          //////////////////

        //////////////////          SERVICIO AMBULANCIA          //////////////////

        //By Henrry Torres
        [HttpGet, Route("GetHistoriasClinicasAmbulanciaBandeja")]
        public async Task<IActionResult> GetHistoriasClinicasAmbulanciaBandeja([FromQuery] AmbulanciaResource ambulanciaResource)
        {
            var resultado = await _historiaClinicaService.GetHistoriasClinicasAmbulanciaBandeja(ambulanciaResource);

            var paginacion = JsonConvert.DeserializeObject<TablaPaginacionList>(resultado.ResultData.ToJsonNoFormat());

            var paginationMetadata = new
            {
                totalCount = paginacion.TotalCount,
                pageSize = paginacion.PageSize,
                skip = paginacion.Skip,
                totalPages = paginacion.TotalPages
            };

            Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

            return ReturnFormattedResponse(resultado);
        }

        //By Henrry Torres
        [HttpPost, Route("AddHistoriaClinicaAmbulanciaOrientacionMedica")]
        public async Task<IActionResult> AddHistoriaClinicaAmbulanciaOrientacionMedica(CreateHistoriaClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMtoDto dto = new HistoriaClinicaMtoDto
            {
                id_empresa = model.id_empresa,
                id_persona = model.id_persona,
                CPAR_ID_MOTIVO_CALLMEDICO = model.CPAR_ID_MOTIVO_CALLMEDICO,
                CPAR_ID_REFERENCIA_AMBULANCIA = model.CPAR_ID_REFERENCIA_AMBULANCIA,
                CCEN_ID = model.CCEN_ID,
                CECM_ID = model.CECM_ID,
                CPAR_ID_SOLICITUD = model.CPAR_ID_SOLICITUD,
                estado = model.estado,
                SHIS_CM_ESTADO = model.SHIS_CM_ESTADO,
                NHIS_COD_ESTADO = model.NHIS_COD_ESTADO,
                FHIS_FLG_CM_NUEVA = model.FHIS_FLG_CM_NUEVA,
                NHIS_CM_ORDEN = model.NHIS_CM_ORDEN,
                SHIS_REF_DIR = model.SHIS_REF_DIR,
                SHIS_CM_REF_DIR = model.SHIS_CM_REF_DIR,
                FHIS_FLAG_PROGRAMADA = model.FHIS_FLAG_PROGRAMADA,
                SHIS_F_PROG = model.SHIS_F_PROG,
                SHIS_COD_TIPO_PROG = model.SHIS_COD_TIPO_PROG,
                SHIS_COD_DR_SOLICITADO = model.SHIS_COD_DR_SOLICITADO,
                SHIS_COD_DEP = model.SHIS_COD_DEP,
                FHIS_CM_DIRECTA = model.FHIS_CM_DIRECTA,
                SHIS_FLG_DIRECTO = model.SHIS_FLG_DIRECTO,
                FHIS_CM_DATOS_COMPLETOS = model.FHIS_CM_DATOS_COMPLETOS,
                NHIS_TAR_ATE = model.NHIS_TAR_ATE,
                SHIS_TIPO_SERVAMB_DRMAS = model.SHIS_TIPO_SERVAMB_DRMAS,
                SHIS_COD_AMB_TIPO_SERV = model.SHIS_COD_AMB_TIPO_SERV,
                NHIS_COASEGURO = model.NHIS_COASEGURO,
                SHIS_FLAGMONE = model.SHIS_FLAGMONE,
                NHIS_CAMBIO = model.NHIS_CAMBIO,
                SHIS_FOR_ATE = model.SHIS_FOR_ATE,
                SHIS_CM_MONEDA_DEN = model.SHIS_CM_MONEDA_DEN,
                NHIS_CM_DEN_CAMBIO = model.NHIS_CM_DEN_CAMBIO,
                SHIS_CM_DENOMINACION = model.SHIS_CM_DENOMINACION,
                SHIS_CONTACTO_PAC = model.SHIS_CONTACTO_PAC,
                SHIS_CONTACTO_ASEG = model.SHIS_CONTACTO_ASEG,
                SHIS_TIPO_SERVICIO = model.SHIS_TIPO_SERVICIO,
                NHIS_CLASIFICACION_PAC = model.NHIS_CLASIFICACION_PAC,
                SHIS_TIPO_DOC_PAGO = model.SHIS_TIPO_DOC_PAGO,
                SHIS_DESCRP_ZONA = model.SHIS_DESCRP_ZONA,
                SHIS_COD_EMP = model.SHIS_COD_EMP,
                SHIS_USULLA_ATE = model.SHIS_USULLA_ATE,
                CPAC_ID = model.CPAC_ID,
                CPER_ID = model.CPER_ID,
                CCLI_ID = model.CCLI_ID,
                observacion = model.observacion,
                NHIS_CLASIFICACION_PAC_CALLMED = model.NHIS_CLASIFICACION_PAC_CALLMED,
                SHIS_COD_AUT_PRESTACION = model.SHIS_COD_AUT_PRESTACION,
                SHIS_COD_ASEGURADO = model.SHIS_COD_ASEGURADO,
                SHIS_CM_ASEG_PRODUCTO = model.SHIS_CM_ASEG_PRODUCTO,
                SHIS_POLIZA_ASEGURADO = model.SHIS_POLIZA_ASEGURADO,
                SHIS_POLIZA_CERTIFICADO = model.SHIS_POLIZA_CERTIFICADO,
                usuario_creacion = model.usuario_creacion
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaAmbulanciaOrientacionMedica(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddHistoriaClinicaAmbulancia")]
        public async Task<IActionResult> AddHistoriaClinicaAmbulancia(CreateHistoriaClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMtoDto dto = new HistoriaClinicaMtoDto
            {
                id_empresa = model.id_empresa,
                SHIS_NOM_EMP = model.SHIS_NOM_EMP,
                id_persona = model.id_persona,
                NHIS_EDAD_ATE = model.NHIS_EDAD_ATE,
                SHIS_CEL_PAC = model.SHIS_CEL_PAC,
                SHIS_CM_REF_DIR = model.SHIS_CM_REF_DIR,
                NHIS_COD_TARIFA = model.NHIS_COD_TARIFA,
                SHIS_F_PROG = model.SHIS_F_PROG,
                SHIS_COD_AMB_TIPO_SERV = model.SHIS_COD_AMB_TIPO_SERV,
                FHIS_FLAG_PROGRAMADA = model.FHIS_FLAG_PROGRAMADA,
                DHIS_HOR_ATE = model.DHIS_HOR_ATE,
                SHIS_COD_EMP = model.SHIS_COD_EMP,
                SHIS_AMB_COD_DIS_ORIGEN = model.SHIS_AMB_COD_DIS_ORIGEN,
                SHIS_AMB_DES_DIS_ORIGEN = model.SHIS_AMB_DES_DIS_ORIGEN,
                SHIS_AMB_DIR_ORIGEN = model.SHIS_AMB_DIR_ORIGEN,
                SHIS_AMB_REF_DIR_ORIGEN = model.SHIS_AMB_REF_DIR_ORIGEN,
                DHIS_AMB_FECHA_INI = model.DHIS_AMB_FECHA_INI,
                DHIS_AMB_HORA_INI = model.DHIS_AMB_HORA_INI,
                DHIS_AMB_FECHA_FIN = model.DHIS_AMB_FECHA_FIN,
                DHIS_AMB_HORA_FIN = model.DHIS_AMB_HORA_FIN,
                SHIS_AMB_COD_DIS_DESTINO = model.SHIS_AMB_COD_DIS_DESTINO,
                SHIS_AMB_DES_DIS_DESTINO = model.SHIS_AMB_DES_DIS_DESTINO,
                SHIS_AMB_DIR_DESTINO = model.SHIS_AMB_DIR_DESTINO,
                SHIS_AMB_REF_DIR_DESTINO = model.SHIS_AMB_REF_DIR_DESTINO,
                SHIS_TIPO_SERVICIO = model.SHIS_TIPO_SERVICIO,
                NHIS_COD_PRIORIDAD_CALLMED = model.NHIS_COD_PRIORIDAD_CALLMED,
                NHIS_COD_MOTIVO_ATE_CALLMED = model.NHIS_COD_MOTIVO_ATE_CALLMED,
                NHIS_TAR_ATE = model.NHIS_TAR_ATE,
                NHIS_COASEGURO = model.NHIS_COASEGURO,
                SHIS_TIPO_DOC_PAGO = model.SHIS_TIPO_DOC_PAGO,
                observacion = model.observacion,
                SHIS_CM_DENOMINACION = model.SHIS_CM_DENOMINACION,
                SHIS_FOR_ATE = model.SHIS_FOR_ATE,
                NHIS_ID_TIPO_TRASLADO_CALLMED = model.NHIS_ID_TIPO_TRASLADO_CALLMED,
                SHIS_COD_AUT_PRESTACION = model.SHIS_COD_AUT_PRESTACION,
                SHIS_CONTRATANTE_CITRIX = model.SHIS_CONTRATANTE_CITRIX,
                SHIS_COD_ASEGURADO = model.SHIS_COD_ASEGURADO,
                SHIS_CM_ASEG_PRODUCTO = model.SHIS_CM_ASEG_PRODUCTO,
                SHIS_POLIZA_ASEGURADO = model.SHIS_POLIZA_ASEGURADO,
                SHIS_POLIZA_CERTIFICADO = model.SHIS_POLIZA_CERTIFICADO,
                FHIS_AMB_SERVICIO_PLAYA = model.FHIS_AMB_SERVICIO_PLAYA,
                estado = model.estado,
                SHIS_CM_ESTADO = model.SHIS_CM_ESTADO,
                NHIS_COD_ESTADO = model.NHIS_COD_ESTADO,
                NHIS_CM_ORDEN = model.NHIS_CM_ORDEN,
                FHIS_FLG_CM_NUEVA = model.FHIS_FLG_CM_NUEVA,
                SHIS_COD_TIPO_PROG = model.SHIS_COD_TIPO_PROG,
                SHIS_COD_DR_SOLICITADO = model.SHIS_COD_DR_SOLICITADO,
                FHIS_CM_DIRECTA = model.FHIS_CM_DIRECTA,
                SHIS_FLG_DIRECTO = model.SHIS_FLG_DIRECTO,
                FHIS_CM_DATOS_COMPLETOS = model.FHIS_CM_DATOS_COMPLETOS,
                SHIS_FLAGMONE = model.SHIS_FLAGMONE,
                NHIS_CAMBIO = model.NHIS_CAMBIO,
                SHIS_CM_MONEDA_DEN = model.SHIS_CM_MONEDA_DEN,
                NHIS_CM_DEN_CAMBIO = model.NHIS_CM_DEN_CAMBIO,
                SHIS_CONTACTO_PAC = model.SHIS_CONTACTO_PAC,
                SHIS_CONTACTO_ASEG = model.SHIS_CONTACTO_ASEG,
                NHIS_CLASIFICACION_PAC = model.NHIS_CLASIFICACION_PAC,
                SHIS_DESCRP_ZONA = model.SHIS_DESCRP_ZONA,
                SHIS_USULLA_ATE = model.SHIS_USULLA_ATE,
                NHIS_CLASIFICACION_PAC_CALLMED = model.NHIS_CLASIFICACION_PAC_CALLMED,
                DHIS_FEC_ATE = model.DHIS_FEC_ATE,
                SHIS_TIPO_SERVAMB_DRMAS = model.SHIS_TIPO_SERVAMB_DRMAS,
                usuario_creacion = model.usuario_creacion
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaAmbulanciaOrientacionMedica(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddHistoriaClinicaAmbulanciaEvento")]
        public async Task<IActionResult> AddHistoriaClinicaAmbulanciaEvento(CreateHistoriaClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMtoDto dto = new HistoriaClinicaMtoDto
            {
                id_empresa = model.id_empresa,
                SHIS_NOM_EMP = model.SHIS_NOM_EMP,
                id_persona = model.id_persona,
                NHIS_EDAD_ATE = model.NHIS_EDAD_ATE,
                SHIS_CEL_PAC = model.SHIS_CEL_PAC,
                SHIS_CM_REF_DIR = model.SHIS_CM_REF_DIR,
                NHIS_COD_TARIFA = model.NHIS_COD_TARIFA,
                SHIS_F_PROG = model.SHIS_F_PROG,
                SHIS_COD_AMB_TIPO_SERV = model.SHIS_COD_AMB_TIPO_SERV,
                FHIS_FLAG_PROGRAMADA = model.FHIS_FLAG_PROGRAMADA,//10
                DHIS_HOR_ATE = model.DHIS_HOR_ATE,
                SHIS_COD_EMP = model.SHIS_COD_EMP,
                SHIS_AMB_COD_DIS_ORIGEN = model.SHIS_AMB_COD_DIS_ORIGEN,
                SHIS_AMB_DES_DIS_ORIGEN = model.SHIS_AMB_DES_DIS_ORIGEN,
                SHIS_AMB_DIR_ORIGEN = model.SHIS_AMB_DIR_ORIGEN,
                SHIS_AMB_REF_DIR_ORIGEN = model.SHIS_AMB_REF_DIR_ORIGEN,
                DHIS_AMB_FECHA_INI = model.DHIS_AMB_FECHA_INI,
                DHIS_AMB_HORA_INI = model.DHIS_AMB_HORA_INI,
                DHIS_AMB_FECHA_FIN = model.DHIS_AMB_FECHA_FIN,
                DHIS_AMB_HORA_FIN = model.DHIS_AMB_HORA_FIN,//20
                SHIS_AMB_COD_DIS_DESTINO = model.SHIS_AMB_COD_DIS_DESTINO,
                SHIS_AMB_DES_DIS_DESTINO = model.SHIS_AMB_DES_DIS_DESTINO,
                SHIS_AMB_DIR_DESTINO = model.SHIS_AMB_DIR_DESTINO,
                SHIS_AMB_REF_DIR_DESTINO = model.SHIS_AMB_REF_DIR_DESTINO,
                SHIS_TIPO_SERVICIO = model.SHIS_TIPO_SERVICIO,
                NHIS_COD_PRIORIDAD_CALLMED = model.NHIS_COD_PRIORIDAD_CALLMED,
                NHIS_COD_MOTIVO_ATE_CALLMED = model.NHIS_COD_MOTIVO_ATE_CALLMED,
                NHIS_TAR_ATE = model.NHIS_TAR_ATE,
                NHIS_COASEGURO = model.NHIS_COASEGURO,
                SHIS_TIPO_DOC_PAGO = model.SHIS_TIPO_DOC_PAGO,//30
                observacion = model.observacion,
                SHIS_CM_DENOMINACION = model.SHIS_CM_DENOMINACION,
                SHIS_FOR_ATE = model.SHIS_FOR_ATE,
                NHIS_ID_TIPO_TRASLADO_CALLMED = model.NHIS_ID_TIPO_TRASLADO_CALLMED,
                SHIS_COD_AUT_PRESTACION = model.SHIS_COD_AUT_PRESTACION,
                SHIS_CONTRATANTE_CITRIX = model.SHIS_CONTRATANTE_CITRIX,
                SHIS_COD_ASEGURADO = model.SHIS_COD_ASEGURADO,
                SHIS_CM_ASEG_PRODUCTO = model.SHIS_CM_ASEG_PRODUCTO,
                SHIS_POLIZA_ASEGURADO = model.SHIS_POLIZA_ASEGURADO,
                SHIS_POLIZA_CERTIFICADO = model.SHIS_POLIZA_CERTIFICADO,//40
                FHIS_AMB_SERVICIO_PLAYA = model.FHIS_AMB_SERVICIO_PLAYA,
                estado = model.estado,
                SHIS_CM_ESTADO = model.SHIS_CM_ESTADO,
                NHIS_COD_ESTADO = model.NHIS_COD_ESTADO,
                NHIS_CM_ORDEN = model.NHIS_CM_ORDEN,
                FHIS_FLG_CM_NUEVA = model.FHIS_FLG_CM_NUEVA,
                SHIS_COD_TIPO_PROG = model.SHIS_COD_TIPO_PROG,
                SHIS_COD_DR_SOLICITADO = model.SHIS_COD_DR_SOLICITADO,
                FHIS_CM_DIRECTA = model.FHIS_CM_DIRECTA,
                SHIS_FLG_DIRECTO = model.SHIS_FLG_DIRECTO,//50
                FHIS_CM_DATOS_COMPLETOS = model.FHIS_CM_DATOS_COMPLETOS,
                SHIS_FLAGMONE = model.SHIS_FLAGMONE,
                NHIS_CAMBIO = model.NHIS_CAMBIO,
                SHIS_CM_MONEDA_DEN = model.SHIS_CM_MONEDA_DEN,
                NHIS_CM_DEN_CAMBIO = model.NHIS_CM_DEN_CAMBIO,
                SHIS_CONTACTO_PAC = model.SHIS_CONTACTO_PAC,
                SHIS_CONTACTO_ASEG = model.SHIS_CONTACTO_ASEG,
                NHIS_CLASIFICACION_PAC = model.NHIS_CLASIFICACION_PAC,
                SHIS_DESCRP_ZONA = model.SHIS_DESCRP_ZONA,
                SHIS_USULLA_ATE = model.SHIS_USULLA_ATE,//60
                NHIS_CLASIFICACION_PAC_CALLMED = model.NHIS_CLASIFICACION_PAC_CALLMED,
                DHIS_FEC_ATE = model.DHIS_FEC_ATE,
                SHIS_TIPO_SERVAMB_DRMAS = model.SHIS_TIPO_SERVAMB_DRMAS,
                FHIS_FUERA_COBERTURA = model.FHIS_FUERA_COBERTURA,
                SHIS_DIRECCION_ORIGEN = model.SHIS_DIRECCION_ORIGEN,
                SHIS_DIRECCION_DESTINO = model.SHIS_DIRECCION_DESTINO,
                CCLI_ID_ORIGEN = model.CCLI_ID_ORIGEN,
                CCLI_ID_DESTINO = model.CCLI_ID_DESTINO,
                SHIS_ALERGIA_MEDICA = model.SHIS_ALERGIA_MEDICA,
                SHIS_ATENCEDENTE = model.SHIS_ATENCEDENTE,//70
                CTAM_ID = model.CTAM_ID,
                SHIS_RUC_EVENTO = model.SHIS_RUC_EVENTO,
                SHIS_RAZON_SOCIAL_EVENTO = model.SHIS_RAZON_SOCIAL_EVENTO,
                SHIS_DIRECCION_FISCAL_EVENTO = model.SHIS_DIRECCION_FISCAL_EVENTO,
                CPOL_ID = model.CPOL_ID,
                SHIS_NRO_PLACA = model.SHIS_NRO_PLACA,
                SHIS_NRO_POLIZA = model.SHIS_NRO_POLIZA,
                SHIS_SINIESTRO = model.SHIS_SINIESTRO,
                SHIS_AHUTORIZA_CORTESIA = model.SHIS_AHUTORIZA_CORTESIA,
                SHIS_REGLA_ORO = model.SHIS_REGLA_ORO,//80
                FHIS_AMB_RESPIRATORIA = model.FHIS_AMB_RESPIRATORIA,
                CPAR_ID_SOLICITANTE = model.CPAR_ID_SOLICITANTE,
                SHIS_UBIC_DENTRO_CLINICA_ORIGEN = model.SHIS_UBIC_DENTRO_CLINICA_ORIGEN,
                SHIS_UBIC_DENTRO_CLINICA_DESTINO = model.SHIS_UBIC_DENTRO_CLINICA_DESTINO,
                NPRV_ID = model.NPRV_ID,
                DHIS_FECHA_EVENTO_ADVERSO = model.DHIS_FECHA_EVENTO_ADVERSO,
                CPAR_ID_SOLICITUD = model.CPAR_ID_SOLICITUD,
                FHIS_CITRIX = model.FHIS_CITRIX,
                usuario_creacion = model.usuario_creacion
            };

            var response = await _historiaClinicaService.AddHistoriaClinicaAmbulanciaEvento(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpDelete, Route("DeleteHistoriaClinicaAmbulancia")]
        public async Task<IActionResult> DeleteHistoriaClinicaAmbulancia(DeleteHistoriaClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            HistoriaClinicaMtoDto dto = new HistoriaClinicaMtoDto
            {
                cod_historia_clinica = model.cod_historia_clinica,
                id_motivo = model.id_motivo,
                usuario_eliminacion = model.usuario_eliminacion
            };

            var response = await _historiaClinicaService.DeleteHistoriaClinicaAmbulancia(dto);

            return ReturnFormattedResponse(response);
        }

        //////////////////          FIN SERVICIO AMBULANCIA          //////////////////

    }
}
