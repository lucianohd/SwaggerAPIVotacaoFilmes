using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Domain.Specs.Filters;
using Domain.Specs.ValueObjects;
using Repositories.Spec.Repositories;

namespace Repositories.Implementation.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string connectionString;

        public FilmeRepository()
        {
            connectionString = "Server=.;Database=IMDb;Trusted_Connection=True";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        
        public void CadastrarFilme(Filme filme)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlBuilder = string.Format("INSERT INTO [dbo].[Filmes] VALUES('{0}','{1}','{2}','{3}')",
                    filme.Diretor,filme.Nome,filme.Genero,filme.Atores);
                dbConnection.Query<string>(sqlBuilder);
                dbConnection.Close();
            }
        }
        public bool ChecarSeFilmeExiste(string VotoId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var VotoIdInt = Int32.Parse(VotoId);
                string sqlBuilder = string.Format("Select * from [dbo].[Filmes] where Id = {0}", VotoIdInt);
                var existeFilme = dbConnection.Query<string>(sqlBuilder).ToList().Any();
                dbConnection.Close();
                return existeFilme;
            }
        }

        public string RetornaNomeUsuarioPorToken(string token)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlBuilder = string.Format("Select * from [dbo].[Usuario] where Token = '{0}'", token);
                var usuario = dbConnection.Query<string>(sqlBuilder).FirstOrDefault();
                dbConnection.Close();
                return usuario;
            }
        }

        public void RegistraVoto(Voto voto)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlBuilder = string.Format("INSERT INTO [dbo].[Votos] VALUES('{0}','{1}','{2}')",
                    voto.FilmeId,voto.Usuario,voto.Nota);
                dbConnection.Query<string>(sqlBuilder);
                dbConnection.Close();
            }
        }

        public List<FilmeOrdenado> ProcurarFilmes(Filme filtroFilme, OrdemFilter filtroOrdem)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlBuilder = "SELECT	AVG(v.Nota) as Media_Nota, COUNT(v.VotoId) as Total_Votos, v.FilmeId, f.Nome, f.Diretor, f.Genero, f.Atores from Votos v  INNER JOIN Filmes f ON v.filmeid=f.id group by FilmeId,f.Nome,f.Diretor,f.Genero,f.Atores ";
                sqlBuilder += AplicarFiltrosOrdem(filtroOrdem);
                var filmes = dbConnection.Query<FilmeOrdenado>(sqlBuilder).ToList();
                return filmes;
            }
        }

        private string AplicarFiltrosOrdem(OrdemFilter filtroOrdem)
        {
            string sql = " order by";
            if (filtroOrdem.Alfabetica) 
                sql += " 4";
            if (filtroOrdem.Alfabetica && filtroOrdem.Votacao)
                sql += ",";
            if (filtroOrdem.Votacao) 
                sql += " 1";
            return sql;
        }

        private string AplicaFiltrosFilme(Filme filtroFilme, OrdemFilter filtroOrdem)
        {
            string sql = " where ";
            if (!string.IsNullOrEmpty(filtroFilme.Atores))
            {
                sql += string.Format(" Atores = '{0}'",filtroFilme.Atores);
            }
            if (!string.IsNullOrEmpty(filtroFilme.Diretor))
            {
                sql += string.Format(" Diretor = '{0}'",filtroFilme.Diretor);
            }
            if (!string.IsNullOrEmpty(filtroFilme.Genero))
            {
                sql += string.Format(" Genero = '{0}'",filtroFilme.Genero);
            } 
            if (!string.IsNullOrEmpty(filtroFilme.Nome))
            {
                sql += string.Format(" Nome = '{0}'",filtroFilme.Nome);
            }


            if (sql == " order by ")
                sql = "";
            
            return sql;
        }
    }
}