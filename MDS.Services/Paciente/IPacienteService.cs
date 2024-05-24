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
        //By William Vilca
        Task<ServiceResponse> GetPacientes();

        //By William Vilca
        Task<ServiceResponse> GetPaciente(string pacienteId);

        //By William Vilca
        Task<ServiceResponse> AddPaciente(MantenimientoPacienteDto dto);
    }
}
