using System;
using Api_MongoDB.Data;
using Api_MongoDB.Data.Collections;
using Api_MongoDB.Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api_MongoDB.Controllers
{
    [ApiController]
    [Route("[Controller]")]
     public class InfectadoController : ControllerBase
    {
        private MongoDBContext _mongoDBContext;
        private IMongoCollection<Infectados> _colletionsInfectados;
        public InfectadoController ( MongoDBContext mongoDBContext){
            _mongoDBContext = mongoDBContext;
            _colletionsInfectados = _mongoDBContext.DB.GetCollection<Infectados>(typeof(Infectados).Name.ToLower());
        }

        [HttpPost]
        public IActionResult SalvarInfectado([FromBody] InfectadoViewModel infectadoViewModel){
            var infectado = new Infectados(infectadoViewModel.DataNascimento, infectadoViewModel.Sexo, infectadoViewModel.Latitude, infectadoViewModel.Longitude);
            _colletionsInfectados.InsertOne(infectado);
            return StatusCode(201, "Infectado inserido com sucesso");
        }

        [HttpGet]
        public IActionResult ObterInfectados(){
            var infectados = _colletionsInfectados.Find(Builders<Infectados>.Filter.Empty).ToList();
            return Ok(infectados);
        }

        [HttpPut]
        public IActionResult AtualizarInfectado([FromBody] InfectadoViewModel infectadoViewModel){
             _colletionsInfectados.UpdateOne(Builders<Infectados>.Filter.Where(i => i.DataNascimento == infectadoViewModel.DataNascimento), Builders<Infectados>.Update.Set("sexo",infectadoViewModel));
            return Ok("Atualizado com sucesso");
        }

        [HttpDelete("{dataNascimento}")]
        public IActionResult DeletetarInfectados(DateTime dataNascimento ){
             _colletionsInfectados.DeleteOne(Builders<Infectados>.Filter.Where(i => i.DataNascimento == dataNascimento));
            return Ok("Deletado com sucesso");
        }
        
    }
}