using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;

namespace MDS.Services.Cliente.Implementation
{
    public class ClienteService : IClienteService
    {

        private readonly IUnitOfWork _uow;

        public ClienteService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse> GetClientes()
        {
            try
            {
                List<DbContext.Entities.Cliente> clientes = new List<DbContext.Entities.Cliente>();

                clientes = await _uow.ExecuteStoredProcAll<DbContext.Entities.Cliente>("SPRMDS_LIST_CLIENTE");

                List<ClienteDto> listCliente = new List<ClienteDto>();

                listCliente = clientes.Select(c => new ClienteDto { NCLI_IDCLIENTE = c.NCLI_IDCLIENTE, SCLI_NOMBRE = c.SCLI_NOMBRE, SCLI_DESCRIPCION = c.SCLI_DESCRIPCION, SCLI_DIRECCION = c.SCLI_DIRECCION, FCLI_ESTADO = c.FCLI_ESTADO }).ToList();

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


        public async Task<ServiceResponse> GetCliente(long clienteId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ID", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = clienteId },
                };


                List<DbContext.Entities.Cliente> clientes = new List<DbContext.Entities.Cliente>();

                clientes = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Cliente>("SPRMDS_LIST_CLIENTE_BY_PARAM", parameters);

                List<ClienteDto> listCliente = new List<ClienteDto>();

                listCliente = clientes.Select(c => new ClienteDto { NCLI_IDCLIENTE = c.NCLI_IDCLIENTE, SCLI_NOMBRE = c.SCLI_NOMBRE, SCLI_DESCRIPCION = c.SCLI_DESCRIPCION, SCLI_DIRECCION = c.SCLI_DIRECCION, FCLI_ESTADO = c.FCLI_ESTADO }).ToList();

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

        public async Task<ServiceResponse> AddCliente(MantenimientoClienteDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@FCLI_ESTADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FCLI_ESTADO },
                    new SqlParameter("@SCLI_NOMBRE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SCLI_NOMBRE },
                    new SqlParameter("@SCLI_DESCRIPCION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SCLI_DESCRIPCION },
                    new SqlParameter("@SCLI_DIRECCION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SCLI_DIRECCION },
                    new SqlParameter("@SCLI_DISTRITO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SCLI_DISTRITO },
                    new SqlParameter("@SCLI_RUC", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SCLI_RUC},
                    new SqlParameter("@NCLI_DSCTO_PED", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NCLI_DSCTO_PED},
                    new SqlParameter("@NCLI_FACTOR_LAB", SqlDbType.Decimal) {Direction = ParameterDirection.Input, Value = dto.NCLI_FACTOR_LAB},
                    new SqlParameter("@NCLI_DSCTO_LAB", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NCLI_DSCTO_LAB},
                    new SqlParameter("@NCLI_COSTO", SqlDbType.Decimal) {Direction = ParameterDirection.Input, Value = dto.NCLI_COSTO},
                    new SqlParameter("@CCLI_CONV_EMP", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.CCLI_CONV_EMP},
                    new SqlParameter("@NCLI_COSTO_ALT", SqlDbType.Decimal) {Direction = ParameterDirection.Input, Value = dto.NCLI_COSTO_ALT},
                    new SqlParameter("@SCLI_FLAG_TIPO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SCLI_FLAG_TIPO },
                    new SqlParameter("@FCLI_ACTIVI_OPERACIONES", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FCLI_ACTIVI_OPERACIONES },
                    new SqlParameter("@NCLI_FACTOR_LAB_PROV", SqlDbType.Decimal) {Direction = ParameterDirection.Input, Value = dto.NCLI_FACTOR_LAB_PROV },
                    new SqlParameter("@SCLI_COD_GRU_FACT", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SCLI_COD_GRU_FACT },
                    new SqlParameter("@FCLI_ACTIVO_FACT", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FCLI_ACTIVO_FACT },
                    new SqlParameter("@NCLI_RELACIONADO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NCLI_RELACIONADO },
                    new SqlParameter("@FCLI_ACTIVO_LAB", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FCLI_ACTIVO_LAB },
                    new SqlParameter("@FCLI_ACTIVO_AMB", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FCLI_ACTIVO_AMB },
                    new SqlParameter("@FCLI_CLIENTE_PLAYA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FCLI_CLIENTE_PLAYA },
                    new SqlParameter("@SCLI_EMAIL", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SCLI_EMAIL },
                    new SqlParameter("@SCLI_URBANIZACION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SCLI_URBANIZACION },
                    new SqlParameter("@NCLI_DIAS_PLAZO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NCLI_DIAS_PLAZO },
                    new SqlParameter("@SCLI_COD_TIPO_DOC_ID", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SCLI_COD_TIPO_DOC_ID },
                    new SqlParameter("@SCLI_EMAIL_CON_COPIA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SCLI_EMAIL_CON_COPIA },
                    new SqlParameter("@SCLI_PERSONAL_CONTACTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SCLI_PERSONAL_CONTACTO },
                    new SqlParameter("@SCLI_TLF_CONTACTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SCLI_TLF_CONTACTO },
                    new SqlParameter("@NCLI_ID_DOC_ID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NCLI_ID_DOC_ID },
                    new SqlParameter("@FCLI_SAP_FLG_REGISTRADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FCLI_SAP_FLG_REGISTRADO },
                    new SqlParameter("@FCLI_ACTIVO_DRONLINE", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FCLI_ACTIVO_DRONLINE },
                    new SqlParameter("@FCLI_FLG_CARGAR_BD", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FCLI_FLG_CARGAR_BD },
                    new SqlParameter("@SCLI_NOM_ASEG_ONBASE", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SCLI_NOM_ASEG_ONBASE },
                    new SqlParameter("@FCLI_VISIBLE_MELCHORITA", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.SCLI_VISIBLE_MELCHORITA },
                    new SqlParameter("@FCLI_VISIBLE_CALLMEDICO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.SCLI_VISIBLE_CALLMEDICO },
                    new SqlParameter("@NCLI_DIAS_CREDITO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NCLI_DIAS_CREDITO },
                    new SqlParameter("@FCLI_FLG_CAPITADO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FCLI_FLG_CAPITADO },
                    new SqlParameter("@FCLI_VISIBLE_HOME_CARE", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.FCLI_VISIBLE_HOME_CARE },
                    new SqlParameter("@NCLI_USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NCLI_USUARIO_CREACION },
                    new SqlParameter("@DCLI_FECHA_CREACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.DCLI_FECHA_CREACION },
                    new SqlParameter("@NCLI_USUARIO_MODIFICACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NCLI_USUARIO_MODIFICACION },
                    new SqlParameter("@DCLI_FECHA_MODIFICACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.DCLI_FECHA_MODIFICACION },

                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_CLIENTE", parameters);

                dto.NCLI_IDCLIENTE = Convert.ToInt64(response);

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
