using Repositorio_Desenvolvedor.Entity;
using Repositorio_Desenvolvedor.Interface;
using Repositorio_Desenvolvedor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio_Desenvolvedor.Service
{
    public class AplicacaoService : IAplicacaoService
    {
        private IAplicacaoRepository _aplicacaoRepository;

        public AplicacaoService(IAplicacaoRepository aplicacaoRepository)
        {
            _aplicacaoRepository = aplicacaoRepository;
        }

        public List<AplicacaoResponse> Listar()
        {
            var entity = _aplicacaoRepository.Listar();

            List<AplicacaoResponse> app = new List<AplicacaoResponse>();

            entity.ForEach(p =>
            app.Add(new AplicacaoResponse()
            {
                Id = p.Id,
                DesenvolvedorId = p.DesenvolvedorId,
                Nome = p.Nome,
                DataLancamento = p.DataLancamento,
                Plataforma = p.Plataforma
            }));
            return app;
        }
        public AplicacaoResponse Obter(int id)
        {
            var entity = _aplicacaoRepository.Obter(id);

            return new AplicacaoResponse()
            {
                Id = entity.Id,
                DesenvolvedorId = entity.DesenvolvedorId,
                Nome = entity.Nome,
                DataLancamento = entity.DataLancamento,
                Plataforma = entity.Plataforma
            };

        }
        public BaseResponse Inserir(AplicacaoRequest aplicacaoRequest)
        {
            if (aplicacaoRequest.Nome == "")
            {
                return new BaseResponse() { StatusCode = 400, Mensagem = "Erro: " + "Nome precisa ser preenchido!" };
            }
            if (aplicacaoRequest.DataLancamento == null)
            {
                return new BaseResponse() { StatusCode = 400, Mensagem = "Erro: " + "Data precisa ser preenchido!" };
            }
            if (aplicacaoRequest.Plataforma == "")
            {
                return new BaseResponse() { StatusCode = 400, Mensagem = "Erro: " + "Plataforma precisa ser preenchido!" };
            }

            Aplicacao app = new Aplicacao();
            app.Id = aplicacaoRequest.Id;
            app.DesenvolvedorId = aplicacaoRequest.DesenvolvedorId;
            app.Nome = aplicacaoRequest.Nome;
            app.DataLancamento = aplicacaoRequest.DataLancamento;
            app.Plataforma = aplicacaoRequest.Plataforma;
            _aplicacaoRepository.Inserir(app);
            return new BaseResponse() { StatusCode = 201, Mensagem = "Cliente Inserido com sucesso!" };
        }
    }
}
