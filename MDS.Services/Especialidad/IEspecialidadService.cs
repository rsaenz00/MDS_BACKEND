using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MDS.Services.Especialidad
{
    public interface IEspecialidadService : IService
    {
        Task<ServiceResponse> GetEspecialidades();

        Task<ServiceResponse> GetEspecialidad(string especialidadId);

        Task<ServiceResponse> AddEspecialidad(MantenimientoEspecialidadDto dto);
    }
}
