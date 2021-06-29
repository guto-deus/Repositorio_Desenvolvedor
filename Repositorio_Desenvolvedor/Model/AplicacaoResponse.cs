using Repositorio_Desenvolvedor.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio_Desenvolvedor.Model
{
    public class AplicacaoResponse
    {
        public int Id { get; set; }
        public int DesenvolvedorId { get; set; }
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Plataforma { get; set; }
    }
}
