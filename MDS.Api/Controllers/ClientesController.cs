using Azure;
using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.DbContext.Entities;
using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Services;
using MDS.Services.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MDS.Api.Controllers
{

    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : BaseController
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;

        }

        //By William Vilca
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
                estado = model.FCLI_ESTADO,
                descripcion = model.SCLI_DESCRIPCION,
                direccion = model.SCLI_DIRECCION,
                distrito = model.SCLI_DISTRITO,
                dscto_ped = model.NCLI_DSCTO_PED,
                factor_lab = model.NCLI_FACTOR_LAB,
                dscto_lab = model.NCLI_DSCTO_LAB,
                costo = model.NCLI_COSTO,
                conv_emp = model.CCLI_CONV_EMP,
                costo_alt = model.NCLI_COSTO_ALT,
                flag_tipo = model.SCLI_FLAG_TIPO,
                activi_operaciones = model.FCLI_ACTIVI_OPERACIONES,
                factor_lab_prov = model.NCLI_FACTOR_LAB_PROV,
                cod_gru_fact = model.SCLI_COD_GRU_FACT,
                activo_fact = model.FCLI_ACTIVO_FACT,
                relacionado = model.NCLI_RELACIONADO,
                activo_lab = model.FCLI_ACTIVO_LAB,
                activo_amb = model.FCLI_ACTIVO_AMB,
                cliente_playa = model.FCLI_CLIENTE_PLAYA,
                email = model.SCLI_EMAIL,
                urbanizacion = model.SCLI_URBANIZACION,
                dias_plazo = model.NCLI_DIAS_PLAZO,
                cod_tipo_doc_id = model.SCLI_COD_TIPO_DOC_ID,
                email_con_copia = model.SCLI_EMAIL_CON_COPIA,
                personal_contacto = model.SCLI_PERSONAL_CONTACTO,
                tlf_contacto = model.SCLI_TLF_CONTACTO,
                id_doc_id = model.NCLI_ID_DOC_ID,
                sap_flg_registrado = model.FCLI_SAP_FLG_REGISTRADO,
                activo_dronline = model.FCLI_ACTIVO_DRONLINE,
                flg_cargar_bd = model.FCLI_FLG_CARGAR_BD,
                nom_aseg_onbase = model.SCLI_NOM_ASEG_ONBASE,
                visible_melchorita = model.SCLI_VISIBLE_MELCHORITA,
                visible_callmedico = model.SCLI_VISIBLE_CALLMEDICO,
                dias_credito = model.NCLI_DIAS_CREDITO,
                flg_capitado = model.FCLI_FLG_CAPITADO,
                visible_home_care = model.FCLI_VISIBLE_HOME_CARE,
                fecha_creacion = model.DCLI_FECHA_CREACION,
                usuario_modificacion = model.NCLI_USUARIO_MODIFICACION,
                fecha_modificacion = model.DCLI_FECHA_MODIFICACION
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

        //By Henrry Torres
        [HttpPost, Route("AddClienteSctr")]
        public async Task<IActionResult> AddClienteSctr(CreateClienteSctrViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            MantenimientoCliente_SctrDto dto = new MantenimientoCliente_SctrDto
            {
                nombre = model.SCLI_NOMBRE,
                ruc = model.SCLI_RUC,
                estado = model.FCLI_ESTADO,
                usuario_creacion = model.NCLI_USUARIO_CREACION
            };

            var response = await _clienteService.AddClienteSctr(dto);

            return ReturnFormattedResponse(response);
        }

    }
}
