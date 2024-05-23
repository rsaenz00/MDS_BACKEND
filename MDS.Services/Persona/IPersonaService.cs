using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.Persona
{
    public interface IPersonaService : IService
    {
        Task<ServiceResponse> GetPersonas();

        Task<ServiceResponse> GetPersona(long personaId);

        Task<ServiceResponse> AddPersona(MantenimientoPersonaDto dto);
    }
}
