﻿using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.Atencion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AtencionesController : BaseController
    {
        private readonly IAtencionService _atencionService;

        public AtencionesController(IAtencionService atencionService)
        {
            _atencionService = atencionService;
        }

        //By Henrry Torres
        [HttpGet, Route("GetAtencionByCodigo")]
        public async Task<IActionResult> GetAtencionByCodigo(string cod_atencion)
        {
            var response = await _atencionService.GetAtencionByCodigo(cod_atencion);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetAtencionesBandeja")]
        public async Task<IActionResult> GetAtencionesBandeja(string fechaInicio, string fechaFin, string condicion)
        {
            var response = await _atencionService.GetAtencionesBandeja(fechaInicio, fechaFin, condicion);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetAtencionesFiltro")]
        public async Task<IActionResult> GetAtencionesFiltro(string fechaInicio, string fechaFin, string? busqueda, string? condicion)
        {
            var response = await _atencionService.GetAtencionesFiltro(fechaInicio, fechaFin, busqueda, condicion);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddAtencion")]
        public async Task<IActionResult> AddAtencion(CreateAtencionViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            AtencionMtoDto dto = new AtencionMtoDto
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
                estado = model.estado
            };

            var response = await _atencionService.AddAtencion(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPut, Route("UpdateAtencion")]
        public async Task<IActionResult> UpdateAtencion(UpdateAtencionViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            AtencionMtoDto dto = new AtencionMtoDto
            {
                id_atencion = model.id_atencion,
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
                estado = model.estado
            };

            var response = await _atencionService.UpdateAtencion(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpDelete, Route("DeleteAtencion")]
        public async Task<IActionResult> DeleteAtencion(DeleteAtencionViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            AtencionMtoDto dto = new AtencionMtoDto
            {
                id_atencion = model.id_atencion,
                usuario_eliminacion = model.usuario_eliminacion
            };

            var response = await _atencionService.DeleteAtencion(dto);

            return ReturnFormattedResponse(response);
        }

    }
}
