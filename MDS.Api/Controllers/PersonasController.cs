using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Api.Utility.Extensions;
using MDS.Dto;
using MDS.Services.Persona;
using MDS.Utility.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MDS.Api.Controllers.Test
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : BaseController
    {

        private readonly IPersonaService _personaService;
        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpGet, Route("GetPersonas")]
        public async Task<IActionResult> GetPersonas()
        {
            var response = await _personaService.GetPersonas();

            return ReturnFormattedResponse(response);
        }


        [HttpGet, Route("GetPersona")]
        public async Task<IActionResult> GetPersona(long personaId)
        {
            var response = await _personaService.GetPersona(personaId);

            return ReturnFormattedResponse(response);
        }



        [HttpPost, Route("AddPersona")]
        public async Task<IActionResult> AddPersona(CreatePersonaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            MantenimientoPersonaDto dto = new MantenimientoPersonaDto
            {

                CPAI_IDPAIS = model.CPAI_IDPAIS,
                CUBI_IDUBIGEO = model.CUBI_IDUBIGEO,
                SPER_NOMBRES = model.SPER_NOMBRES,
                SPER_APELLIDO_PATERNO = model.SPER_APELLIDO_PATERNO,
                SPER_APELLIDO_MATERNO = model.SPER_APELLIDO_MATERNO,
                SPER_DNI = model.SPER_DNI,
                DPER_FECHA_NACIMIENTO = model.DPER_FECHA_NACIMIENTO,
                SPER_GENERO = model.SPER_GENERO,
                SPER_DEPARTAMENTO = model.SPER_DEPARTAMENTO,
                SPER_PROVINCIA = model.SPER_PROVINCIA,
                SPER_DISTRITO = model.SPER_DISTRITO,
                SPER_DIRECCION = model.SPER_DIRECCION,
                SPER_EMAIL1 = model.SPER_EMAIL1,
                SPER_EMAIL2 = model.SPER_EMAIL2,
                SPER_TELEFONO_CASA = model.SPER_TELEFONO_CASA,
                SPER_TELEFONO_CELULAR = model.SPER_TELEFONO_CELULAR,
                SPER_TELEFONO_CORPORATIVO = model.SPER_TELEFONO_CORPORATIVO,
                FPER_ESTADO = model.FPER_ESTADO,
                NPER_USUARIO_CREACION = model.NPER_USUARIO_CREACION,
                DPER_FECHA_CREACION = model.DPER_FECHA_CREACION,
                NPER_USUARIO_MODIFICACION = model.NPER_USUARIO_MODIFICACION,
                DPER_FECHA_MODIFICACION = model.DPER_FECHA_MODIFICACION

            };

            var response = await _personaService.AddPersona(dto);

            return ReturnFormattedResponse(response);
        }


    }
}
