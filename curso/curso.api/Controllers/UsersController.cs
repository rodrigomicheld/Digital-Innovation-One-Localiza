using curso.api.Domain.Entities;
using curso.api.Filters;
using curso.api.Infraestrutura.Data;
using curso.api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace curso.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Este Serviço permite autenticar um usuário cadastrado e ativo. 
        /// </summary>
        /// <param name="loginViewModel">View model do login</param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModel))]
        [SwaggerResponse(statusCode: 400, description: "Campos Obrigatórios", Type = typeof(ValidarCampoViewModel))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErrorViewModel))]
        [HttpPost]
        [Route("logar")]
        [ValidarModelState]
        public IActionResult Logar(LoginViewModel loginViewModel)
        {
            var userViewModel = new UserViewModel()
            {
                Codigo = 1,
                Login = "rodrigomichel",
                Email = "rodrigomichel@gmail.com"
            };
            
            
            var secret = Encoding.ASCII.GetBytes("MzfsT&d9gprP>!9$Es(X!5g@;ef!5sbk:jH\\2.}8ZP'qY#7");
            var symetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userViewModel.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, userViewModel.Login.ToString()),
                    new Claim(ClaimTypes.Email, userViewModel.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256)
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return Ok(new 
            {
                Token = token,
                Usuario = userViewModel
            } );
        }

        [HttpPost]
        [Route("registrar")]
        [ValidarModelState]
        public IActionResult Registrar(ResgistrarViewModel resgistrarViewModel)
        {
            string mySqlConnection = "server=localhost;userid=dev;password=1234567;database=cursoDb";
            var optionsBuilder = new DbContextOptionsBuilder<CursoDbContext>();
            optionsBuilder.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection));
            
            CursoDbContext context = new CursoDbContext(optionsBuilder.Options);

            var usuario = new User();
            usuario.Login = resgistrarViewModel.Login;
            usuario.Email = resgistrarViewModel.Email;
            usuario.Password = resgistrarViewModel.Passoword;

            context.User.Add(usuario);
            context.SaveChanges();

            return Created("", resgistrarViewModel);
        }
    }
}
