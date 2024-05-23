using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MDS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClientesController : BaseController
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;

        }

        [HttpGet, Route("GetClientes")]
        public async Task<IActionResult> GetClientes()
        {
            var response = await _clienteService.GetClientes();

            return ReturnFormattedResponse(response);
        }



        [HttpGet, Route("GetConsultaCliente")]
        public async Task<IActionResult> GetConsultaCliente(string vCondicion,string vBusqueda)
        {
            var response = await _clienteService.GetConsultaCliente(vCondicion,vBusqueda);

            return ReturnFormattedResponse(response);
        }


        [HttpPost, Route("AddCliente")]
        public async Task<IActionResult> AddCliente(CreateClienteViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            MantenimientoClienteDto dto = new MantenimientoClienteDto

            {
                FCLI_ESTADO = model.FCLI_ESTADO,
                SCLI_NOMBRE = model.SCLI_NOMBRE,
                SCLI_DESCRIPCION = model.SCLI_DESCRIPCION,
                SCLI_DIRECCION = model.SCLI_DIRECCION,
                SCLI_DISTRITO = model.SCLI_DISTRITO,
                SCLI_RUC = model.SCLI_RUC,
                NCLI_DSCTO_PED = model.NCLI_DSCTO_PED,
                NCLI_FACTOR_LAB = model.NCLI_FACTOR_LAB,
                NCLI_DSCTO_LAB = model.NCLI_DSCTO_LAB,
                NCLI_COSTO = model.NCLI_COSTO,
                CCLI_CONV_EMP = model.CCLI_CONV_EMP,
                NCLI_COSTO_ALT = model.NCLI_COSTO_ALT,
                SCLI_FLAG_TIPO = model.SCLI_FLAG_TIPO,
                FCLI_ACTIVI_OPERACIONES = model.FCLI_ACTIVI_OPERACIONES,
                NCLI_FACTOR_LAB_PROV = model.NCLI_FACTOR_LAB_PROV,
                SCLI_COD_GRU_FACT = model.SCLI_COD_GRU_FACT,
                FCLI_ACTIVO_FACT = model.FCLI_ACTIVO_FACT,
                NCLI_RELACIONADO = model.NCLI_RELACIONADO,
                FCLI_ACTIVO_LAB = model.FCLI_ACTIVO_LAB,
                FCLI_ACTIVO_AMB = model.FCLI_ACTIVO_AMB,
                FCLI_CLIENTE_PLAYA = model.FCLI_CLIENTE_PLAYA,
                SCLI_EMAIL = model.SCLI_EMAIL,
                SCLI_URBANIZACION = model.SCLI_URBANIZACION,
                NCLI_DIAS_PLAZO = model.NCLI_DIAS_PLAZO,
                SCLI_COD_TIPO_DOC_ID = model.SCLI_COD_TIPO_DOC_ID,
                SCLI_EMAIL_CON_COPIA = model.SCLI_EMAIL_CON_COPIA,
                SCLI_PERSONAL_CONTACTO = model.SCLI_PERSONAL_CONTACTO,
                SCLI_TLF_CONTACTO = model.SCLI_TLF_CONTACTO,
                NCLI_ID_DOC_ID = model.NCLI_ID_DOC_ID,
                FCLI_SAP_FLG_REGISTRADO = model.FCLI_SAP_FLG_REGISTRADO,
                FCLI_ACTIVO_DRONLINE = model.FCLI_ACTIVO_DRONLINE,
                FCLI_FLG_CARGAR_BD = model.FCLI_FLG_CARGAR_BD,
                SCLI_NOM_ASEG_ONBASE = model.SCLI_NOM_ASEG_ONBASE,
                SCLI_VISIBLE_MELCHORITA = model.SCLI_VISIBLE_MELCHORITA,
                SCLI_VISIBLE_CALLMEDICO = model.SCLI_VISIBLE_CALLMEDICO,
                NCLI_DIAS_CREDITO = model.NCLI_DIAS_CREDITO,
                FCLI_FLG_CAPITADO = model.FCLI_FLG_CAPITADO,
                FCLI_VISIBLE_HOME_CARE = model.FCLI_VISIBLE_HOME_CARE,
                NCLI_USUARIO_CREACION = model.NCLI_USUARIO_CREACION,
                DCLI_FECHA_CREACION = model.DCLI_FECHA_CREACION,
                NCLI_USUARIO_MODIFICACION = model.NCLI_USUARIO_MODIFICACION,
                DCLI_FECHA_MODIFICACION = model.DCLI_FECHA_MODIFICACION
            };

            var response = await _clienteService.AddCliente(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpGet, Route("GetClienteByRuc")]
        public async Task<IActionResult> GetClienteByRuc(string ruc)
        {
            var response = await _clienteService.GetClienteByRuc(ruc);

            return ReturnFormattedResponse(response);
        }

    }
}
