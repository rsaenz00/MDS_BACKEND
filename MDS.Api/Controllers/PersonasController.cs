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

                id_pais = model.CPAI_IDPAIS,
                id_ubigeo = model.CUBI_IDUBIGEO,
                nombre = model.SPER_NOMBRES,
                paterno = model.SPER_APELLIDO_PATERNO,
                materno = model.SPER_APELLIDO_MATERNO,
                dni = model.SPER_DNI,
                fecha_naciemiento = model.DPER_FECHA_NACIMIENTO,
                genero = model.SPER_GENERO,
                departamento = model.SPER_DEPARTAMENTO,
                provincia = model.SPER_PROVINCIA,
                distrito = model.SPER_DISTRITO,
                direccion = model.SPER_DIRECCION,
                email1 = model.SPER_EMAIL1,
                email2 = model.SPER_EMAIL2,
                telefono_casa = model.SPER_TELEFONO_CASA,
                telefono_celular = model.SPER_TELEFONO_CELULAR,
                telefono_corporativo = model.SPER_TELEFONO_CORPORATIVO,
                estado = model.FPER_ESTADO,
                usuario_creacion = model.NPER_USUARIO_CREACION,
                fecha_creacion = model.DPER_FECHA_CREACION,
                usuario_modificacion = model.NPER_USUARIO_MODIFICACION,
                fecha_modificacion = model.DPER_FECHA_MODIFICACION

            };

            var response = await _personaService.AddPersona(dto);

            return ReturnFormattedResponse(response);
        }


    }
}
