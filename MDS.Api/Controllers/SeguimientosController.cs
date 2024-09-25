using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.Seguimiento;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SeguimientosController : BaseController
    {
        private readonly ISeguimientoService _seguimientoService;

        public SeguimientosController(ISeguimientoService seguimientoService)
        {
            _seguimientoService = seguimientoService;
        }

        //By Henrry Torres
        [HttpGet, Route("GetSeguimientoByHistoriaClinica")]
        public async Task<IActionResult> GetSeguimientoByHistoriaClinica(string codHistoriaClinica)
        {
            var response = await _seguimientoService.GetSeguimientoByHistoriaClinica(codHistoriaClinica);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddSeguimientoSctr")]
        public async Task<IActionResult> AddSeguimientoSctr(CreateSeguimientoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            SeguimientoDto dto = new SeguimientoDto
            {
                cod_historia_clinica = model.cod_historia_clinica,
                observacion = model.observacion,
                cod_servicio = 5,
                usuario = model.usuario
            };

            var response = await _seguimientoService.AddSeguimientoSctr(dto);

            return ReturnFormattedResponse(response);
        }

    }
}
