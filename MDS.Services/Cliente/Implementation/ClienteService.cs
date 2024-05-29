using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using Microsoft.Data.SqlClient;
using System.Data;
using MDS.Infrastructure.Helper;

namespace MDS.Services.Cliente.Implementation
{
    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _uow;

        public ClienteService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //By William Vilca
        public async Task<ServiceResponse> GetClientes()
        {
            try
            {
                List<DbContext.Entities.Cliente> clientes = new List<DbContext.Entities.Cliente>();

                clientes = await _uow.ExecuteStoredProcAll<DbContext.Entities.Cliente>("SPRMDS_LIST_CLIENTE");

                List<ClienteDto> listCliente = new List<ClienteDto>();

                listCliente = clientes.Select(c => new ClienteDto { id_cliente = c.NCLI_IDCLIENTE, nombre = c.SCLI_NOMBRE, descripcion = c.SCLI_DESCRIPCION, direccion = c.SCLI_DIRECCION, distrito = c.SCLI_DISTRITO, ruc = c.SCLI_RUC, estado = c.FCLI_ESTADO }).ToList();

                if (!clientes.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listCliente);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> GetConsultaCliente(string vCondicion,string vBusqueda)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isCondicion", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vCondicion },

                    new SqlParameter("@isTextoBusqueda", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = vBusqueda },
                };


                List<DbContext.Entities.Cliente> clientes = new List<DbContext.Entities.Cliente>();

                clientes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Cliente>("SPRMDS_LIST_CLIENTE_BY_PARAM", parameters);

                List<ClienteDto> listCliente = new List<ClienteDto>();

                listCliente = clientes.Select(c => new ClienteDto { id_cliente = c.NCLI_IDCLIENTE, nombre = c.SCLI_NOMBRE, descripcion = c.SCLI_DESCRIPCION, direccion = c.SCLI_DIRECCION,distrito = c.SCLI_DISTRITO,ruc = c.SCLI_RUC, estado = c.FCLI_ESTADO }).ToList();

                if (!listCliente.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listCliente);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By William Vilca
        public async Task<ServiceResponse> AddCliente(MantenimientoClienteDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@FCLI_ESTADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.estado },
                    new SqlParameter("@SCLI_NOMBRE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.nombre },
                    new SqlParameter("@SCLI_DESCRIPCION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.descripcion },
                    new SqlParameter("@SCLI_DIRECCION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.direccion },
                    new SqlParameter("@SCLI_DISTRITO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.distrito },
                    new SqlParameter("@SCLI_RUC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.ruc},
                    new SqlParameter("@NCLI_DSCTO_PED", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.dscto_ped},
                    new SqlParameter("@NCLI_FACTOR_LAB", SqlDbType.Decimal) {Direction = ParameterDirection.Input, Value = dto.factor_lab},
                    new SqlParameter("@NCLI_DSCTO_LAB", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.dscto_lab},
                    new SqlParameter("@NCLI_COSTO", SqlDbType.Decimal) {Direction = ParameterDirection.Input, Value = dto.costo},
                    new SqlParameter("@CCLI_CONV_EMP", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.conv_emp},
                    new SqlParameter("@NCLI_COSTO_ALT", SqlDbType.Decimal) {Direction = ParameterDirection.Input, Value = dto.costo_alt},
                    new SqlParameter("@SCLI_FLAG_TIPO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.flag_tipo },
                    new SqlParameter("@FCLI_ACTIVI_OPERACIONES", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.activi_operaciones },
                    new SqlParameter("@NCLI_FACTOR_LAB_PROV", SqlDbType.Decimal) {Direction = ParameterDirection.Input, Value = dto.factor_lab_prov },
                    new SqlParameter("@SCLI_COD_GRU_FACT", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cod_gru_fact },
                    new SqlParameter("@FCLI_ACTIVO_FACT", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.activo_fact },
                    new SqlParameter("@NCLI_RELACIONADO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.relacionado },
                    new SqlParameter("@FCLI_ACTIVO_LAB", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.activo_lab },
                    new SqlParameter("@FCLI_ACTIVO_AMB", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.activo_amb },
                    new SqlParameter("@FCLI_CLIENTE_PLAYA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.cliente_playa },
                    new SqlParameter("@SCLI_EMAIL", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.email },
                    new SqlParameter("@SCLI_URBANIZACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.urbanizacion },
                    new SqlParameter("@NCLI_DIAS_PLAZO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.dias_plazo },
                    new SqlParameter("@SCLI_COD_TIPO_DOC_ID", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.cod_tipo_doc_id },
                    new SqlParameter("@SCLI_EMAIL_CON_COPIA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.email_con_copia },
                    new SqlParameter("@SCLI_PERSONAL_CONTACTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.personal_contacto },
                    new SqlParameter("@SCLI_TLF_CONTACTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.tlf_contacto },
                    new SqlParameter("@NCLI_ID_DOC_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.id_doc_id },
                    new SqlParameter("@FCLI_SAP_FLG_REGISTRADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.sap_flg_registrado },
                    new SqlParameter("@FCLI_ACTIVO_DRONLINE", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.activo_dronline },
                    new SqlParameter("@FCLI_FLG_CARGAR_BD", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flg_cargar_bd },
                    new SqlParameter("@SCLI_NOM_ASEG_ONBASE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.nom_aseg_onbase },
                    new SqlParameter("@FCLI_VISIBLE_MELCHORITA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.visible_melchorita },
                    new SqlParameter("@FCLI_VISIBLE_CALLMEDICO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.visible_callmedico },
                    new SqlParameter("@NCLI_DIAS_CREDITO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.dias_credito },
                    new SqlParameter("@FCLI_FLG_CAPITADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.flg_capitado },
                    new SqlParameter("@FCLI_VISIBLE_HOME_CARE", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.visible_home_care },
                    new SqlParameter("@NCLI_USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@DCLI_FECHA_CREACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_creacion },
                    new SqlParameter("@NCLI_USUARIO_MODIFICACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_modificacion },
                    new SqlParameter("@DCLI_FECHA_MODIFICACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.fecha_modificacion },

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_CLIENTE", parameters);

                dto.id_cliente = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> GetClienteByRuc(string ruc)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@isRuc", SqlDbType.Char) {Direction = ParameterDirection.Input, Value = ruc },
                };

                List<DbContext.Entities.Cliente> clientes = new List<DbContext.Entities.Cliente>();

                clientes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Cliente>("SPRMDS_LIST_CLIENTE_BY_RUC", parameters);

                List<ClienteDto> listClientes = new List<ClienteDto>();

                listClientes = clientes.Select(s => new ClienteDto { id_cliente = s.NCLI_IDCLIENTE, nombre = s.SCLI_NOMBRE, descripcion = s.SCLI_DESCRIPCION, direccion = s.SCLI_DIRECCION, distrito = s.SCLI_DISTRITO, ruc = s.SCLI_RUC, estado = s.FCLI_ESTADO }).ToList();

                /*if (!listClientes.Any())
                    return ServiceResponse.Return404();*/

                return ServiceResponse.ReturnResultWith200(listClientes);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

        //By Henrry Torres
        public async Task<ServiceResponse> AddClienteSctr(MantenimientoClienteDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SCLI_NOMBRE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.nombre },
                    new SqlParameter("@SCLI_RUC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.ruc},
                    new SqlParameter("@NCLI_USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.usuario_creacion },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_CLIENTE", parameters);

                dto.id_cliente = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }

    }
}
