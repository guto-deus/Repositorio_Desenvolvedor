using Repositorio_Desenvolvedor.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Repositorio_Desenvolvedor.Interface;

namespace Repositorio_Desenvolvedor.Repository
{
    public class DesenvolvedorRepository : BaseRepository, IDesenvolvedorRepository
    {

        public List<Desenvolvedor> Listar()
        {
            string query = @"SELECT[Id]
                ,[Nome]
                ,[Email]
                 FROM.[tb_Desenvolvedor]";
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn.Query<Desenvolvedor>(query).ToList();

        }
        public Desenvolvedor Obter(int Id)
        {
            string query = @"SELECT[Id]
                ,[Nome]
                ,[Email]
                 FROM.[tb_Desenvolvedor]
                    WHERE Id = @Id";
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn.QueryFirstOrDefault<Desenvolvedor>(query, new { Id });
        }
        public void Inserir(Desenvolvedor desenvolvedor)
        {
            string query = @"INSERT INTO [dbo].[tb_Desenvolvedor]
               ([Nome]
               ,[Email])
                VALUES
               (@Nome
               ,@Email)";
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            conn.Execute(query, desenvolvedor);
        }
        public Desenvolvedor ObterNome(string Nome)
        {
            string query = @"SELECT[Id]
                ,[Nome]
                ,[Email]
                 FROM.[tb_Desenvolvedor]
                    WHERE Nome = @Nome";
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn.QueryFirstOrDefault<Desenvolvedor>(query, new { Nome });
        }
        public void Atualizar(Desenvolvedor desenvolvedor)
        {
            string query = @"UPDATE[dbo].[tb_Desenvolvedor]
                           SET[Nome] = @Nome 
                          ,[Email] = @Email
                           WHERE Id = @Id";
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            conn.Execute(query, desenvolvedor);
        }
        public void Deletar(int Id)
        {
            string query = @"delete from tb_Desenvolvedor where Id = @Id";
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            conn.Execute(query, new { Id });
        }





    }
}
