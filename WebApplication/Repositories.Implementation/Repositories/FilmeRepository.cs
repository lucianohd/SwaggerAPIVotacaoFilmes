using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
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

    }
}