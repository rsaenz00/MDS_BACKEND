using MDS.Dto;
using MDS.Infrastructure.DbUtility;
using System.Data;
using MDS.Infrastructure.Helper;
using Microsoft.Data.SqlClient;
using System;

namespace MDS.Services.Persona.Implementation
{
    public class PersonaService : IPersonaService
    {

        private readonly IUnitOfWork _uow;

        public PersonaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ServiceResponse> GetPersonas()
        {
            try
            {
                List<DbContext.Entities.Persona> personas = new List<DbContext.Entities.Persona>();

                personas = await _uow.ExecuteStoredProcAll<DbContext.Entities.Persona>("SPRMDS_LIST_PERSONA");

                List<PersonaDto> listPersona = new List<PersonaDto>();

                listPersona = personas.Select(p => new PersonaDto { id_persona = p.CPER_IDPERSONA, paterno = p.SPER_APELLIDO_PATERNO, materno = p.SPER_APELLIDO_MATERNO, nombre = p.SPER_NOMBRES, dni = p.SPER_DNI, genero = p.SPER_GENERO, estado = p.FPER_ESTADO }).ToList();

                if (!personas.Any())
                    return ServiceResponse.ReturnResultWith204();

                return ServiceResponse.ReturnResultWith200(listPersona);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }


        public async Task<ServiceResponse> GetPersona(long personaId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ID", SqlDbType.BigInt) {Direction = ParameterDirection.Input, Value = personaId },
                };


                List<DbContext.Entities.Persona> personas = new List<DbContext.Entities.Persona>();

                personas = await _uow.ExecuteStoredProcByParam<DbContext.Entities.Persona>("SPRMDS_LIST_PERSONA_BY_PARAM", parameters);

                List<PersonaDto> listPersona = new List<PersonaDto>();

                listPersona = personas.Select(p => new PersonaDto { id_persona = p.CPER_IDPERSONA, paterno = p.SPER_APELLIDO_PATERNO, materno = p.SPER_APELLIDO_MATERNO, nombre = p.SPER_NOMBRES, dni = p.SPER_DNI, genero = p.SPER_GENERO, estado = p.FPER_ESTADO }).ToList();

                if (!listPersona.Any())
                    return ServiceResponse.Return404();

                return ServiceResponse.ReturnResultWith200(listPersona);
            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }



        public async Task<ServiceResponse> AddPersona(MantenimientoPersonaDto dto)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@CPAI_IDPAIS", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CPAI_IDPAIS },
                    new SqlParameter("@CUBI_IDUBIGEO", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.CUBI_IDUBIGEO },
                    new SqlParameter("@SPER_NOMBRES", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPER_NOMBRES },
                    new SqlParameter("@SPER_APELLIDO_PATERNO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPER_APELLIDO_PATERNO },
                    new SqlParameter("@SPER_APELLIDO_MATERNO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPER_APELLIDO_MATERNO },
                    new SqlParameter("@SPER_DNI", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPER_DNI },
                    new SqlParameter("@DPER_FECHA_NACIMIENTO", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.DPER_FECHA_NACIMIENTO },
                    new SqlParameter("@SPER_GENERO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPER_GENERO },
                    new SqlParameter("@SPER_DEPARTAMENTO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPER_DEPARTAMENTO },
                    new SqlParameter("@SPER_PROVINCIA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPER_PROVINCIA },
                    new SqlParameter("@SPER_DISTRITO", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPER_DISTRITO },
                    new SqlParameter("@SPER_DIRECCION", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPER_DIRECCION },
                    new SqlParameter("@SPER_EMAIL1", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPER_EMAIL1 },
                    new SqlParameter("@SPER_EMAIL2", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPER_EMAIL2 },
                    new SqlParameter("@SPER_TELEFONO_CASA", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPER_TELEFONO_CASA },
                    new SqlParameter("@SPER_TELEFONO_CELULAR", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = dto.SPER_TELEFONO_CELULAR },
                    new SqlParameter("@SPER_TELEFONO_CORPORATIVO", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = dto.SPER_TELEFONO_CORPORATIVO },
                    new SqlParameter("@NPER_USUARIO_CREACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NPER_USUARIO_CREACION },
                    new SqlParameter("@DPER_FECHA_CREACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.DPER_FECHA_CREACION },
                    new SqlParameter("@NPER_USUARIO_MODIFICACION", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = dto.NPER_USUARIO_MODIFICACION },
                    new SqlParameter("@DPER_FECHA_MODIFICACION", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value = dto.DPER_FECHA_MODIFICACION },
                    new SqlParameter("@onRespuesta", SqlDbType.Int) {Direction = ParameterDirection.Output}
                };

                int response = await _uow.ExecuteStoredProcReturnValue("SPRMDS_CREATE_PERSONA", parameters);

                dto.Id = Convert.ToInt64(response);

                return ServiceResponse.ReturnResultWith201(dto);

            }
            catch (Exception e)
            {
                //_logger.Error(e);
                return ServiceResponse.Return500(e);
            }
        }



    }
}
