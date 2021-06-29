using Repositorio_Desenvolvedor.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio_Desenvolvedor.Interface
{
    public interface IAplicacaoRepository
    {
        List<Aplicacao> Listar();
        Aplicacao Obter(int Id);
        void Inserir(Aplicacao aplicacao);
    }
}
