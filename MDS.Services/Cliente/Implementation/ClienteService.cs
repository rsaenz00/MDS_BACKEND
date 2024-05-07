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

                listClientes = clientes.Select(s => new ClienteDto { id_cliente = s.SCLI_IDCLIENTE, nombre = s.SCLI_NOMBRE, descripcion = s.SCLI_DESCRIPCION, direccion = s.SCLI_DIRECCION, distrito = s.SCLI_DISTRITO, ruc = s.SCLI_RUC, estado = s.FCLI_ESTADO }).ToList();

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

    }
}
