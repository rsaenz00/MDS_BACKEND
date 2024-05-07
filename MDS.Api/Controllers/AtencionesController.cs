using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.Atencion;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtencionesController : BaseController
    {
        private readonly IAtencionService _atencionService;

        public AtencionesController(IAtencionService atencionService)
        {
            _atencionService = atencionService;
        }

        //By Henrry Torres
        [HttpGet, Route("GetAtenciones")]
        public async Task<IActionResult> GetAtenciones()
        {
            var response = await _atencionService.GetAtenciones();

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetAtencionesBandeja")]
        public async Task<IActionResult> GetAtencionesBandeja()
        {
            var response = await _atencionService.GetAtencionesBandeja();

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddAtencion")]
        public async Task<IActionResult> AddAtencion(CreateAtencionViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            AtencionDto dto = new AtencionDto
            {
                id_persona = model.id_persona,
                id_clinica = model.id_clinica,
                id_empresa = model.id_empresa,
                id_motivo = model.id_motivo,
                id_plan = model.id_plan,
                telefono = model.telefono,
                anexo = model.anexo,
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
                persona_reporta_seguro = model.persona_reporta_seguro
            };

            var response = await _atencionService.AddAtencion(dto);

            return ReturnFormattedResponse(response);
        }

    }
}
