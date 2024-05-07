using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.Direccion;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers.Test
{

    [ApiController]
    [Route("[controller]")]

    public class DireccionesController : BaseController
    {
        private readonly IDireccionService _direccionService;

        public DireccionesController(IDireccionService direccionService)
        {
            _direccionService = direccionService;
        }

        //By Henrry Torres
        [HttpGet, Route("GetDirecciones")]
        public async Task<IActionResult> GetDireccion(long CPER_ID)
        {
            var response = await _direccionService.GetDirecciones(CPER_ID);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetDireccion")]
        public async Task<IActionResult> GetDireccion(long CPER_ID, long CDIR_ID)
        {
            var response = await _direccionService.GetDireccion(CPER_ID, CDIR_ID);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddDireccion")]
        public async Task<IActionResult> AddDireccion(CreateDireccionViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            DireccionDto dto = new DireccionDto
            {
                id_persona = model.CPER_ID,
                tipo_direccion = model.NDIR_TIPO_DIRECCION,
                descripcion = model.SDIR_DESCRIPCION,
                cod_departamento = model.SDIR_COD_DPTO,
                cod_provincia = model.SDIR_COD_PROV,
                cod_distrito = model.SDIR_COD_DIST,
                anexo = model.SDIR_ANEXO,
                celular = model.SDIR_TLF_CELULAR,
                telefono_fijo = model.SDIR_TLF_FIJO,
                nro_mz_lote = model.SDIR_NRO_LOTE,
                urbanizacion = model.SDIR_URBANIZACION,
                referencia = model.SDIR_REFERENCIA,
                dpto_interior = model.SDIR_INTERIOR,
                usuario_creacion = model.NDIR_USUARIO_CREACION
            };

            var response = await _direccionService.AddDireccion(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPut, Route("UpdateDireccion")]
        public async Task<IActionResult> UpdateDireccion(UpdateDireccionViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            DireccionDto dto = new DireccionDto
            {
                id_persona = model.CPER_ID,
                id_direccion = model.CDIR_ID,
                tipo_direccion = model.NDIR_TIPO_DIRECCION,
                descripcion = model.SDIR_DESCRIPCION,
                cod_departamento = model.SDIR_COD_DPTO,
                cod_provincia = model.SDIR_COD_PROV,
                cod_distrito = model.SDIR_COD_DIST,
                anexo = model.SDIR_ANEXO,
                celular = model.SDIR_TLF_CELULAR,
                telefono_fijo = model.SDIR_TLF_FIJO,
                nro_mz_lote = model.SDIR_NRO_LOTE,
                urbanizacion = model.SDIR_URBANIZACION,
                referencia = model.SDIR_REFERENCIA,
                dpto_interior = model.SDIR_INTERIOR,
                usuario_modificacion = model.NDIR_USUARIO_MODIFICACION
            };

            var response = await _direccionService.UpdateDireccion(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpDelete, Route("DeleteDireccion")]
        public async Task<IActionResult> DeleteDireccion(DeleteDireccionViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            DireccionDto dto = new DireccionDto
            {
                id_persona = model.CPER_ID,
                id_direccion = model.CDIR_ID
            };

            var response = await _direccionService.DeleteDireccion(dto);

            return ReturnFormattedResponse(response);
        }
    }
}
