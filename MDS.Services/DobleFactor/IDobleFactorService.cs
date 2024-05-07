using MDS.Dto;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.DobleFactor
{
    public interface IDobleFactorService : IService
    {
        Task<ServiceResponse> ValidateDobleFactor(DobleFactorDto dto);
    }
}
