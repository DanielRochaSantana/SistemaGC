using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PrjGestaoClientes.Domain.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PrjGestaoClientes.Login.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        protected readonly IConfiguration configuracao;

        public LoginController(IConfiguration configuracao)
        {
            this.configuracao = configuracao;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel usuario)
        {
            try
            {
                IActionResult result = Unauthorized();

                var usuarioAutenticado = AutenticarUsuario(usuario);

                if (usuarioAutenticado != null)
                {
                    var tokenString = GerarJSONWebToken(usuarioAutenticado);
                    result = Ok(new { token = tokenString });
                }

                return result;

            }
            catch
            {
                return NoContent();
            }
        }

        private string GerarJSONWebToken(UserModel InformacoesUsuario)
        {
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuracao["Jwt:Chave"]));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, InformacoesUsuario.Username),
                new Claim(JwtRegisteredClaimNames.Email, InformacoesUsuario.EmailAddress),
                new Claim("DateOfJoing", InformacoesUsuario.DateOfJoing.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(configuracao["Jwt:Emissor"],
                configuracao["Jwt:Emissor"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credenciais);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel AutenticarUsuario(UserModel usuarioLogin)
        {
            UserModel usuario = null;

            if (usuarioLogin.Username.ToLower() == "usuario")
                usuario = new UserModel { Username = usuarioLogin.Username, EmailAddress = usuarioLogin.EmailAddress, DateOfJoing = usuarioLogin.DateOfJoing };

            if (usuario == null)
                return default;

            return usuario;
        }
    }
}
