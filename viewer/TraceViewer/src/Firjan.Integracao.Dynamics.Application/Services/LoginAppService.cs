using Firjan.Integracao.Dynamics.Domain.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Firjan.Integracao.Dynamics.Application.Services
{
    public class LoginAppService : Interfaces.ILoginAppService
    {
        private readonly Security.Configuration.SigningConfigurations _signingConfigurations;
        private readonly Security.Configuration.TokenConfiguration _tokenConfiguration;

        public LoginAppService(
            Security.Configuration.SigningConfigurations signingConfigurations,
        Security.Configuration.TokenConfiguration tokenConfiguration)
        {
            _signingConfigurations = signingConfigurations;
            _tokenConfiguration = tokenConfiguration;
        }

        public object FindByLogin(User user)
        {
            bool credentialIsValid = false;

            if (user != null && !string.IsNullOrEmpty(user.Login))
            {
                if (user.Login == "TFirjan12ab" && user.AccessKey == "DISISRules")
                    credentialIsValid = true;
            }

            if (credentialIsValid)
            {
                ClaimsIdentity identity = new ClaimsIdentity(new System.Security.Principal.GenericIdentity(user.Login, "Login"),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                         new Claim(JwtRegisteredClaimNames.UniqueName, user.Login)
                    });

                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);

                return SuccessObject(createDate, expirationDate, token);
            }
            else
            {
                return new
                {
                    autenticated = false,
                    message = "Falha na autenticação"
                };
            }
        }
        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(
                new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
                {
                    Issuer = _tokenConfiguration.Issuer,
                    Audience = _tokenConfiguration.Audience,
                    SigningCredentials = _signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = createDate,
                    Expires = expirationDate
                });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token)
        {
            return new
            {
                autenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }
    }
}