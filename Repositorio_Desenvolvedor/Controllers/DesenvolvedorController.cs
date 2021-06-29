using Microsoft.AspNetCore.Mvc;
using Repositorio_Desenvolvedor.Interface;
using Repositorio_Desenvolvedor.Model;
using Repositorio_Desenvolvedor.Service;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio_Desenvolvedor.Controllers
{
    [Route("[controller]")]
    public class DesenvolvedorController
    {
        private IDesenvolvedorService _desenvolvedorService;

        public DesenvolvedorController(IDesenvolvedorService desenvolvedorService)
        {
            _desenvolvedorService = desenvolvedorService;
        }
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            var response = _desenvolvedorService.Listar();
            return new ObjectResult(response) { StatusCode = 200 };
        }
        [HttpGet("obter")]
        public IActionResult Obter([FromQuery] int id)
        {
            var response = _desenvolvedorService.Obter(id);
            return new ObjectResult(response) { StatusCode = 200 };
        }
        [HttpPost("inserir")]
        public IActionResult Inserir([FromBody] DesenvolvedorRequest desenvolvedorRequest)
        {
            var response = _desenvolvedorService.Inserir(desenvolvedorRequest);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
        [HttpPut("atualizar")]
        public IActionResult Atualizar([FromBody] DesenvolvedorRequest desenvolvedorRequest)
        {
            var response = _desenvolvedorService.Atualizar(desenvolvedorRequest);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
        [HttpDelete("deletar")]
        public IActionResult Deletar([FromQuery] int id)
        {
            var response = _desenvolvedorService.Deletar(id);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
