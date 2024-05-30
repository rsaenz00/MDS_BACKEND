﻿using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Helper;
using MDS.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.Medico
{
    public interface IMedicoService : IService
    {
        Task<ServiceResponse> GetMedicos();

        Task<ServiceResponse> GetMedico(long medicoId);

        Task<ServiceResponse> AddMedico(MantenimientoMedicoDto dto);
    }
}