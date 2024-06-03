using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.Cliente
{
    public interface IClienteService : IService
    {
        //By William Vilca
        Task<ServiceResponse> GetClientes();

        //By William Vilca
        Task<ServiceResponse> GetConsultaCliente(string vCondicion,string vBusqueda);

        //By William Vilca
        Task<ServiceResponse> AddCliente(MantenimientoClienteDto dto);

        //By Henrry Torres
        Task<ServiceResponse> GetClienteByRuc(string ruc);

        //By Henrry Torres
        Task<ServiceResponse> AddClienteSctr(MantenimientoCliente_SctrDto dto);
    }
}

