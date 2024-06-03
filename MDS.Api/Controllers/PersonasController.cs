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

        //By William Vilca
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

                id_pais = model.CPAI_IDPAIS,
                id_ubigeo = model.CUBI_IDUBIGEO,
                departamento = model.SPER_DEPARTAMENTO,
                provincia = model.SPER_PROVINCIA,
                distrito = model.SPER_DISTRITO,
                direccion = model.SPER_DIRECCION,
                email1 = model.SPER_EMAIL1,
                email2 = model.SPER_EMAIL2,
                telefono_casa = model.SPER_TELEFONO_CASA,
                telefono_corporativo = model.SPER_TELEFONO_CORPORATIVO,
                estado = model.FPER_ESTADO,
                fecha_creacion = model.DPER_FECHA_CREACION,
                usuario_modificacion = model.NPER_USUARIO_MODIFICACION,
                fecha_modificacion = model.DPER_FECHA_MODIFICACION

            };

            var response = await _personaService.AddPersona(dto);

            return ReturnFormattedResponse(response);
        }

        //By Henrry Torres
        [HttpPost, Route("AddPersonaSctr")]
        public async Task<IActionResult> AddPersonaSctr(CreatePersonaViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelStateExtensions.GetErrorMessage(ModelState));

            MantenimientoPersonaDto dto = new MantenimientoPersonaDto
            {
                nombre = model.nombres,
                paterno = model.apellido_paterno,
                materno = model.apellido_materno,
                dni = model.dni,
                fecha_naciemiento = model.fecha_nacimiento,
                genero = model.sexo,
                telefono_celular = model.celular,
                usuario_creacion = model.usuario_creacion,
            };

            var response = await _personaService.AddPersonaSctr(dto);

            return ReturnFormattedResponse(response);
        }

    }
}
