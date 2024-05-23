using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MDS.Services.Paciente
{
    public interface IPacienteService : IService
    {
        Task<ServiceResponse> GetPacientes();
        Task<ServiceResponse> GetPaciente(string pacienteId);
        Task<ServiceResponse> AddPaciente(MantenimientoPacienteDto dto);
    }
}
