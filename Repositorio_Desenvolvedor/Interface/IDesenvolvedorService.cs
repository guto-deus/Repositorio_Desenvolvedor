using Repositorio_Desenvolvedor.Entity;
using Repositorio_Desenvolvedor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio_Desenvolvedor.Interface
{
    public interface IDesenvolvedorService
    {
        List<DesenvolvedorResponse> Listar();
        DesenvolvedorResponse Obter(int id);
        BaseResponse Inserir(DesenvolvedorRequest desenvolvedorRequest);
        BaseResponse Atualizar(DesenvolvedorRequest desenvolvedorRequest);
        BaseResponse Deletar(int id);
    }
}
