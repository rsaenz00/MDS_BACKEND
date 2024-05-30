//using MDS.Dto;
//using MDS.Infrastructure.DbUtility;
//using MDS.Infrastructure.Helper;
//using MDS.Infrastructure.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;

namespace MDS.Services.Periodo
{
    public interface IPeriodoService : IService
    {

        Task<ServiceResponse> GetPeriodos();

        Task<ServiceResponse> GetPeriodo(long PeriodoId);

        Task<ServiceResponse> AddPeriodo(PeriodoDto dto);

    }
}
