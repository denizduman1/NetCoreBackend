using Core.Entity.Concrete;
using Core.Entity.Concrete.DTOs;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        private IConfiguration Configuration { get; }
        private readonly TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user, OperationClaimListDto operationClaimListDto)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions,user,signingCredentials, operationClaimListDto);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, OperationClaimListDto operationClaimListDto)
        {
            var jwt = new JwtSecurityToken
            (
                audience : tokenOptions.Audience,
                issuer : tokenOptions.Issuer,
                signingCredentials: signingCredentials,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaimListDto)
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, OperationClaimListDto operationClaimListDto)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.ID.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            if(operationClaimListDto != null && operationClaimListDto.OperationClaimDtos != null && operationClaimListDto.OperationClaimDtos.Count > 0)
                claims.AddRoles(operationClaimListDto.OperationClaimDtos.Select(c => c.Name).ToArray());
            return claims;
        }
    }
}
