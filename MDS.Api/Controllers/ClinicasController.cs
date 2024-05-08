using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.Clinica;
using MDS.Utility.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClinicasController : BaseController
    {
        private readonly IClinicaService _clinicaService;

        public ClinicasController(IClinicaService clinicaService)
        {
            _clinicaService = clinicaService;
        }

        //By Henrry Torres
        [HttpGet, Route("GetClinicas")]
        public async Task<IActionResult> GetClinicas()
        {
            var response = await _clinicaService.GetClinicas();

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetClinicasFiltro")]
        public async Task<IActionResult> GetClinicasFiltro(string? busqueda, string? condicion)
        {
            var response = await _clinicaService.GetClinicasFiltro(busqueda, condicion);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddClinica")]
        public async Task<IActionResult> AddClinica(CreateClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            ClinicaMtoDto dto = new ClinicaMtoDto
            {
                clinica = model.clinica,
                ubigeo = model.ubigeo,
                direccion = model.direccion,
                telefono = model.telefono,
                afiliado = model.afiliado,
                plan_huerfano_ilimitado = model.plan_huerfano_ilimitado,
                estado = model.estado,
                usuario_creacion = model.usuario_creacion
            };

            var response = await _clinicaService.AddClinica(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPut, Route("UpdateClinica")]
        public async Task<IActionResult> UpdateClinica(UpdateClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            ClinicaMtoDto dto = new ClinicaMtoDto
            {
                id_clinica = model.id_clinica,
                clinica = model.clinica,
                ubigeo = model.ubigeo,
                direccion = model.direccion,
                telefono = model.telefono,
                afiliado = model.afiliado,
                plan_huerfano_ilimitado = model.plan_huerfano_ilimitado,
                estado = model.estado,
                usuario_modificacion = model.usuario_modificacion
            };

            var response = await _clinicaService.UpdateClinica(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpDelete, Route("DeleteClinica")]
        public async Task<IActionResult> DeleteClinica(DeleteClinicaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            ClinicaMtoDto dto = new ClinicaMtoDto
            {
                id_clinica = model.id_clinica,
            };

            var response = await _clinicaService.DeleteClinica(dto);

            return ReturnFormattedResponse(response);
        }

    }
}
