using Google.Authenticator;
using MDS.Dto;
using MDS.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Services.DobleFactor.Implementation
{
    public class DobleFactorService : IDobleFactorService
    {
        //public string GenerateQrCodeUri(string email, string secretKey)
        //{
        //    var tfa = new TwoFactorAuthenticator();
        //    return tfa.GenerateQrCodeUri(email, secretKey);
        //}

        //public bool ValidateTwoFactorPin(string secretKey, string twoFactorCode)
        //{
        //    var tfa = new TwoFactorAuthenticator();
        //    return tfa.ValidateTwoFactorPIN(secretKey, twoFactorCode);
        //}

        //public string GenerateNewSecretKey()
        //{
        //    var tfa = new TwoFactorAuthenticator();
        //    var setupCode = tfa.GenerateSetupCode("My App", "My User", "mysecretkey", 300, 300);
        //    return setupCode.Secret;
        //}



        public Task<ServiceResponse> ValidateDobleFactor(DobleFactorDto dto)
        {
            var secretKey = "yourSecretKey";

            // Verify the One-Time Password (OTP) entered by the user
            var tfa = new TwoFactorAuthenticator();

            throw new NotImplementedException();
        }
    }
}
