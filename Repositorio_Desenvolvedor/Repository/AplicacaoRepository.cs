using Dapper;
using Repositorio_Desenvolvedor.Entity;
using Repositorio_Desenvolvedor.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio_Desenvolvedor.Repository
{
    public class AplicacaoRepository : BaseRepository, IAplicacaoRepository
    {
        public List<Aplicacao> Listar()
        {
            string query = @"SELECT [Id]
                          ,[Nome]
                          ,[DesenvolvedorId]
                          ,[DataLancamento]
                          ,[Plataforma]
                           FROM [db_Rp_Dev].[dbo].[tb_Aplicacao]";
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn.Query<Aplicacao>(query).ToList();
        }
        public Aplicacao Obter(int Id)
        {
            string query = @"SELECT [Id]
                          ,[Nome]
                          ,[DesenvolvedorId]
                          ,[DataLancamento]
                          ,[Plataforma]
                           FROM [db_Rp_Dev].[dbo].[tb_Aplicacao]
                           WHERE Id = @Id";
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn.QueryFirstOrDefault<Aplicacao>(query, new { Id });
        }
        public void Inserir(Aplicacao aplicacao)
        {
            string query = @"INSERT INTO [dbo].[tb_Aplicacao]
                           ,[Nome]
                           ,[DataLancamento]
                           ,[Plataforma])VALUES
                           (@Nome
                           ,@DataLancamento
                           ,@Plataforma)";
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            conn.Execute(query, aplicacao);
        }
    }
}
