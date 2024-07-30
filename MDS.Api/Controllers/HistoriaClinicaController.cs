using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.HistoriaClinica;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        //SERVICIO SCTR
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
        //FIN SERVICIO SCTR

        //SERVICIO MAD
        //By Henrry Torres
        [HttpGet, Route("GetHistoriaClinicaMadByCodigo")]
        public async Task<IActionResult> GetHistoriaClinicaMadByCodigo(int historiaClinicaId)
        {
            var response = await _historiaClinicaService.GetHistoriaClinicaMadByCodigo(historiaClinicaId);

            return ReturnFormattedResponse(response);
        }
        //FIN SERVICIO MAD
    }
}
