using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MDS.Services.ServicioNegocio
{
    public interface IServicioNegocio : IService
    {
        Task<ServiceResponse> GetServicioNegocios();

        Task<ServiceResponse> GetServicioNegocio(long servicioId);

        Task<ServiceResponse> AddServicioNegocio(MantenimientoServicioNegocioDto dto);

    }
}
