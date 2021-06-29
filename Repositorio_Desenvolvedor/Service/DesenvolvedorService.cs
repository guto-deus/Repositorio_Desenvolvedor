using Repositorio_Desenvolvedor.Entity;
using Repositorio_Desenvolvedor.Interface;
using Repositorio_Desenvolvedor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio_Desenvolvedor.Service
{
    public class DesenvolvedorService : IDesenvolvedorService
    {
        private IDesenvolvedorRepository _desenvolvedorRepository;

        public DesenvolvedorService(IDesenvolvedorRepository desenvolvedorRepository)
        {
            _desenvolvedorRepository = desenvolvedorRepository;
        }

        public List<DesenvolvedorResponse> Listar()
        {
            var entity = _desenvolvedorRepository.Listar();

            List<DesenvolvedorResponse> dev = new List<DesenvolvedorResponse>();

            entity.ForEach(p =>
            dev.Add(new DesenvolvedorResponse()
            {
                Id = p.Id,
                Nome = p.Nome,
                Email = p.Email
            }));

            return dev;
        }
        public DesenvolvedorResponse Obter(int id)
        {
            var entity = _desenvolvedorRepository.Obter(id);

            return new DesenvolvedorResponse()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Email = entity.Email
            };
        }
        public BaseResponse Inserir(DesenvolvedorRequest desenvolvedorRequest)
        {
            if (desenvolvedorRequest.Nome == "")
            {
                return new BaseResponse() { StatusCode = 400, Mensagem = "Erro: " + "Nome precisa ser preenchido!" };
            }
            if (desenvolvedorRequest.Email == "")
            {
                return new BaseResponse() { StatusCode = 400, Mensagem = "Erro: " + "E-mail precisa ser preenchido!" };
            }
            var entity = _desenvolvedorRepository.ObterNome(desenvolvedorRequest.Nome);

            if (entity != null)
            {
                return new BaseResponse() { StatusCode = 400, Mensagem = "Erro: " + "Já existe este nome na base de dados!" };
            }

            Desenvolvedor dev = new Desenvolvedor();
            dev.Id = desenvolvedorRequest.Id;
            dev.Nome = desenvolvedorRequest.Nome;
            dev.Email = desenvolvedorRequest.Email;
            _desenvolvedorRepository.Inserir(dev);

            return new BaseResponse() { StatusCode = 201, Mensagem = "Cliente Inserido com sucesso!" };
        }
        public BaseResponse Atualizar(DesenvolvedorRequest desenvolvedorRequest)
        {
            if (desenvolvedorRequest.Nome == "")
            {
                return new BaseResponse() { StatusCode = 400, Mensagem = "Erro: " + "Nome precisa ser preenchido!" };
            }

            if (desenvolvedorRequest.Email == "")
            {
                return new BaseResponse() { StatusCode = 400, Mensagem = "Erro: " + "E-mail precisa ser preenchido!" };
            }
            var entity = _desenvolvedorRepository.ObterNome(desenvolvedorRequest.Nome);

            if (entity != null)
            {
                if (entity.Id != desenvolvedorRequest.Id)
                {
                    return new BaseResponse() { StatusCode = 400, Mensagem = "Erro: " + "Já existe este nome na base de dados!" };
                }
            }

            Desenvolvedor dev = new Desenvolvedor();
            dev.Id = desenvolvedorRequest.Id;
            dev.Nome = desenvolvedorRequest.Nome;
            dev.Email = desenvolvedorRequest.Email;
            _desenvolvedorRepository.Atualizar(dev);

            return new BaseResponse() { StatusCode = 200, Mensagem = "Cliente Atualizado com sucesso!" };
        }
        public BaseResponse Deletar(int id)
        {
            if (id == 0)
            {
                return new BaseResponse() { StatusCode = 400, Mensagem = "O Id precisa ser preenchido!" };
            }
            _desenvolvedorRepository.Deletar(id);
            return new BaseResponse() { StatusCode = 200, Mensagem = "Cliente excluído com sucesso!" };
        }
    }
}
