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
        [HttpGet, Route("GetSeguimientoByAtencion")]
        public async Task<IActionResult> GetSeguimientoByAtencion(string cod_atencion)
        {
            var response = await _seguimientoService.GetSeguimientoByAtencion(cod_atencion);

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
                cod_atencion = model.cod_atencion,
                observacion = model.observacion,
                usuario = model.usuario
            };

            var response = await _seguimientoService.AddSeguimientoSctr(dto);

            return ReturnFormattedResponse(response);
        }

    }
}
