using curso.api.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CursosController : ControllerBase
    {
        /// <summary>
        /// Este Serviço permite autenticar um usuário cadastrado e ativo. 
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao Cadastrar um Curso")]
        [SwaggerResponse(statusCode: 401, description: "Não Autorizado")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CursoViewModel cursoViewModel)
        {
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", cursoViewModel);
        }
        /// <summary>
        /// Este Serviço permite autenticar um usuário cadastrado e ativo. 
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao Cadastrar um Curso")]
        [SwaggerResponse(statusCode: 401, description: "Não Autorizado")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var cursos = new List<CursoViewModel>();
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            cursos.Add(new CursoViewModel
            {
                Login = "",
                Descricao = "Logica",
                Nome = "Logica"

            });

            return Ok(cursos);
        }
    }
}
