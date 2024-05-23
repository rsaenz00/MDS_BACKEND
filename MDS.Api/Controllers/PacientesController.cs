using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.Paciente;
using MDS.Utility.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MDS.Api.Controllers.Test
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : BaseController
    {
        private readonly IPacienteService _pacienteService;
        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet, Route("GetPacientes")]
        public async Task<IActionResult> GetPacientes()
        {
            var response = await _pacienteService.GetPacientes();

            return ReturnFormattedResponse(response);
        }

        //----------------------------------------------------------------------------------

        [HttpGet, Route("GetPaciente")]
        public async Task<IActionResult> GetPaciente(string pacienteId)
        {
            var response = await _pacienteService.GetPaciente(pacienteId);

            return ReturnFormattedResponse(response);
        }

        //----------------------------------------------------------------------------------

        [HttpPost, Route("AddPaciente")]
        public async Task<IActionResult> AddPaciente(CreatePacienteViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            MantenimientoPacienteDto dto = new MantenimientoPacienteDto
            {
                CPER_IDPERSONA = model.CPER_IDPERSONA,
                CSER_IDSERVICIO = model.CSER_IDSERVICIO,
                DPAC_FINC = model.DPAC_FINC,
                SPAC_COD_PAR = model.SPAC_COD_PAR,
                DPAC_FCRE = model.DPAC_FCRE,
                FPAC_BOL_ACT = model.FPAC_BOL_ACT,
                SPAC_OBS = model.SPAC_OBS,
                FPAC_FLG_CORREO = model.FPAC_FLG_CORREO,
                SPAC_USUCRE_EMAIL = model.SPAC_USUCRE_EMAIL,
                SPAC_USUMODIF_EMAIL = model.SPAC_USUMODIF_EMAIL,
                SPAC_FLAG_FICHA = model.SPAC_FLAG_FICHA,
                FPAC_FLAG_BLOQ = model.FPAC_FLAG_BLOQ,
                FPAC_FLAG_VIP = model.FPAC_FLAG_VIP,
                NPAC_CLASIFICACION = model.NPAC_CLASIFICACION,
                SPAC_VIP = model.SPAC_VIP,
                NPAC_COD_SUBCLASIF = model.NPAC_COD_SUBCLASIF,
                DPAC_FECHA_VIGENCIA = model.DPAC_FECHA_VIGENCIA,
                FPAC_FLG_REGISTRAR_PAC_TABLET = model.FPAC_FLG_REGISTRAR_PAC_TABLET,
                FPAC_CLAVE = model.FPAC_CLAVE,
                SPAC_TIPO_CLAVE = model.SPAC_TIPO_CLAVE,
                SPAC_OBS_CLAVE = model.SPAC_OBS_CLAVE,
                FPAC_CONSENT_INFORMADO = model.FPAC_CONSENT_INFORMADO,
                FPAC_CONSENT_RECIBIR_INFO = model.FPAC_CONSENT_RECIBIR_INFO,
                FPAC_CONSENT_FIRMA_CONST = model.FPAC_CONSENT_FIRMA_CONST,
                FPAC_CONSMT_RI = model.FPAC_CONSMT_RI,
                FPAC_FLG_CONFLICTIVO_CALLMED = model.FPAC_FLG_CONFLICTIVO_CALLMED,
                FPAC_FLG_ACTIVO_FARMACIA = model.FPAC_FLG_ACTIVO_FARMACIA,
                NPAC_NORDEN_OBS = model.NPAC_NORDEN_OBS,
                SPAC_GRUPO_CRONICOS = model.SPAC_GRUPO_CRONICOS,
                FPAC_FLG_PAQUETE_SALUD = model.FPAC_FLG_PAQUETE_SALUD,
                FPAC_ESTADO = model.FPAC_ESTADO,
                NPAC_USUARIO_CREACION = model.NPAC_USUARIO_CREACION,
                DPAC_FECHA_CREACION = model.DPAC_FECHA_CREACION,
                NPAC_USUARIO_MODIFICACION = model.NPAC_USUARIO_MODIFICACION,
                DPAC_FECHA_MODIFICACION = model.DPAC_FECHA_MODIFICACION
            };

            var response = await _pacienteService.AddPaciente(dto);

            return ReturnFormattedResponse(response);
        }


    }
}
