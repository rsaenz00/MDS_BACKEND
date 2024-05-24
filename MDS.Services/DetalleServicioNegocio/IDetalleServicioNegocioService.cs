using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.DetalleServicioNegocio
{
    public interface IDetalleServicioNegocio : IService
    {
        Task<ServiceResponse> GetDetalleServicioNegocios();

        Task<ServiceResponse> GetDetalleServicioNegocio(long detservicioId);

        Task<ServiceResponse> AddDetalleServicioNegocio(MantenimientoDetalleServicioNegocioDto dto);
    }
}
