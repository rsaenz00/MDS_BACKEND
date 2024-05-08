﻿using MDS.Api.Infrastructure;
using MDS.Services.Cliente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS.Api.Controllers.Test
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClientesController : BaseController
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        //By Henrry Torres
        [HttpGet, Route("GetClienteByRuc")]
        public async Task<IActionResult> GetClienteByRuc(string ruc)
        {
            var response = await _clienteService.GetClienteByRuc(ruc);

            return ReturnFormattedResponse(response);
        }

    }
}