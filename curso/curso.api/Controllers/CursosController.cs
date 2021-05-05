using curso.api.Domain.Entities;
using curso.api.Infraestrutura.Data.Repositories;
using curso.api.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace curso.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CursosController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;

        public CursosController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

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
            Curso curso = new Curso();
            curso.Nome = cursoViewModel.Nome;
            curso.Descricao = cursoViewModel.Descricao;
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            curso.CodigoUsuario = codigoUsuario;
            _cursoRepository.Adicionar(curso);
            _cursoRepository.Comit();
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
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var cursos = _cursoRepository.ObterCursoUsuario(codigoUsuario).Select(s => new CursoViewModel()
            {
                Nome = s.Nome,
                Descricao = s.Descricao,
                Login = s.Usuario.Login

            });
            
            

            return Ok(cursos);
        }
    }
}
