using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using XYZ.BOUTIQUE.Application.Dto;
using XYZ.BOUTIQUE.Application.Interface;
using XYZ.BOUTIQUE.Services.WebApi.Helpers;
using XYZ.BOUTIQUE.Transversal.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static XYZ.BOUTIQUE.Services.WebApi.Helpers.AppSettings;

namespace XYZ.BOUTIQUE.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersApplication _usersApplication;
        private readonly JWTSettings _jwtSettings;
        public UsersController(IUsersApplication authApplication, IOptions<JWTSettings> jwtSettings)
        {
            _usersApplication = authApplication;
            _jwtSettings = jwtSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] UsersDto usersDto)
        {
            var response = _usersApplication.Authenticate(usersDto.codigo_trabajador, usersDto.password);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                    return NotFound(response.Message);
            }

            return BadRequest(response.Message);
        }

        private string BuildToken(Response<UsersDto> usersDto)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, usersDto.Data.usuario_id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Issuer = _jwtSettings.Issuer,
                    Audience = _jwtSettings.Audience
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                return tokenString;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error while generating JWT token", ex);
            }


        }

    }
}
