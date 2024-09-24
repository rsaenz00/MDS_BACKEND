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
        //By William Vilca
        Task<ServiceResponse> GetPersonas();

        //By William Vilca
        Task<ServiceResponse> GetPersona(long personaId);

        //By William Vilca
        Task<ServiceResponse> AddPersona(MantenimientoPersonaDto dto);

        //By Henrry Torres
        Task<ServiceResponse> AddPersonaSctr(MantenimientoPersonaDto dto);
    }
}
