using Microsoft.AspNetCore.Mvc;
using Repositorio_Desenvolvedor.Interface;
using Repositorio_Desenvolvedor.Model;
using Repositorio_Desenvolvedor.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio_Desenvolvedor.Controllers
{
    [Route("[controller]")]
    public class AplicacaoController
    {
        private IAplicacaoService _aplicacaoService;

        public AplicacaoController(IAplicacaoService aplicacaoService)
        {
            _aplicacaoService = aplicacaoService;
        }
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            var response = _aplicacaoService.Listar();
            return new ObjectResult(response) { StatusCode = 200 };
        }
        [HttpGet("obter")]
        public IActionResult Obter([FromQuery] int id)
        {
            var response = _aplicacaoService.Obter(id);
            return new ObjectResult(response) { StatusCode = 200 };
        }
        [HttpPost("inserir")]
        public IActionResult Inserir([FromBody] AplicacaoRequest _aplicacaoRequest)
        {
            var response = _aplicacaoService.Inserir(_aplicacaoRequest);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
      
    }
}
