using Repositorio_Desenvolvedor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio_Desenvolvedor.Interface
{
    public interface IAplicacaoService
    {
        List<AplicacaoResponse> Listar();
        AplicacaoResponse Obter(int id);
        BaseResponse Inserir(AplicacaoRequest aplicacaoRequest);
    }
}
