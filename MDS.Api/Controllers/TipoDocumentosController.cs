using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.Blog;
using MDS.Services.TipoDocumento;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers.Test
{
    
    [ApiController]
    [Route("[controller]")]

    public class TipoDocumentosController : BaseController
    {
        private readonly ITipoDocumentoService _tipoDocumentoService;

        public TipoDocumentosController(ITipoDocumentoService tipoDocumentoService)
        {
            _tipoDocumentoService = tipoDocumentoService;
        }

        //By Henrry Torres
        [HttpGet, Route("GetTipoDocumentos")]
        public async Task<IActionResult> GetTipoDocumentos()
        {
            var response = await _tipoDocumentoService.GetTipoDocumentos();

            return ReturnFormattedResponse(response);
        }

    }
}
