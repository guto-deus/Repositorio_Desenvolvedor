using Repositorio_Desenvolvedor.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio_Desenvolvedor.Interface
{
    public interface IDesenvolvedorRepository
    {
        List<Desenvolvedor> Listar();
        Desenvolvedor Obter(int Id);
        void Inserir(Desenvolvedor desenvolvedor);
        Desenvolvedor ObterNome(string Nome);
        void Atualizar(Desenvolvedor desenvolvedor);
        void Deletar(int Id);
    }
}
