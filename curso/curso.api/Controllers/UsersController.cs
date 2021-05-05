using curso.api.Configuration;
using curso.api.Domain.Entities;
using curso.api.Filters;
using curso.api.Infraestrutura.Data.Repositories;
using curso.api.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace curso.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthenticationService _authentication;

        public UsersController(IUsuarioRepository usuarioRepository, IAuthenticationService authentication)
        {
            _usuarioRepository = usuarioRepository;
            _authentication = authentication;
        }

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
            User usuario = _usuarioRepository.ObterUsuario(loginViewModel.Login);

            if (usuario == null)
            {
                return BadRequest("Erro ao tentar acessar.");
            }

            var userViewModel = new UserViewModel()
            {
                Codigo = usuario.Codigo,
                Login = loginViewModel.Login,
                Email = usuario.Email
            };
            
            
           
            var token = _authentication.GerarToken(userViewModel);

            return Ok(new 
            {
                Token = token,
                Usuario = userViewModel
            } );
        }
        /// <summary>
        /// Este Serviço permite cadastrar um usuario. 
        /// </summary>
        /// <param name="resgistrarViewModel">View model do login</param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModel))]
        [SwaggerResponse(statusCode: 400, description: "Campos Obrigatórios", Type = typeof(ValidarCampoViewModel))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErrorViewModel))]
        [HttpPost]
        [Route("registrar")]
        [ValidarModelState]
        public IActionResult Registrar(ResgistrarViewModel resgistrarViewModel)
        {
            
          /*  

            var migrationPending = context.Database.GetPendingMigrations(); //recebe as migrations pendentes

            if (migrationPending.Count() > 0)
            {
                context.Database.Migrate();
            } */

            var usuario = new User();
            usuario.Login = resgistrarViewModel.Login;
            usuario.Email = resgistrarViewModel.Email;
            usuario.Password = resgistrarViewModel.Passoword;
            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.Comit();

            return Created("", resgistrarViewModel);
        }
    }
}
