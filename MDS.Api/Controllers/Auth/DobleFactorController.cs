using Google.Authenticator;
using MDS.Api.Infrastructure;
using MDS.Api.Models;
using MDS.Dto;
using MDS.Services.Blog;
using MDS.Services.DobleFactor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MDS.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class DobleFactorController : BaseController
    {
        private readonly IDobleFactorService _dobleFactorService;

        public DobleFactorController(IDobleFactorService dobleFactorService)
        {
            _dobleFactorService = dobleFactorService;
        }

        [HttpGet("GenerateDobleFactor")]
        [AllowAnonymous]
        public IActionResult GenerateDobleFactor() 
        {
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            SetupCode setupInfo = tfa.GenerateSetupCode("Test Two Factor", "roberto.saenz@sanna.pe", "lalalalala", false, 3);

            return Ok(setupInfo);
        }
        
        [HttpPost("ValidateDobleFactor")]
        public async Task<IActionResult> ValidateDobleFactor(ValidateDobleFactorViewModel model)
        {
            DobleFactorDto dto = new DobleFactorDto
            {
                email = model.email
            };

            var response = await _dobleFactorService.ValidateDobleFactor(dto);

            return ReturnFormattedResponse(response);
        }
    }
}
