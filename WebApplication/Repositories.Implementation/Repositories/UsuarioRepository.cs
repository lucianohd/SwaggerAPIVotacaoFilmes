using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Domain.Specs.ValueObjects;
using Repositories.Implementation.Context;
using Repositories.Spec.Repositories;


namespace Repositories.Implementation.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string connectionString;

        public UsuarioRepository()
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


        public bool PesquisarUsuario(string usuario)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlBuilder = string.Format("SELECT Login_Usuario from [dbo].[Usuario] where Login_Usuario = '{0}'",
                    usuario);
                return dbConnection.Query<string>(sqlBuilder).ToList().Any();
                
            }
        }

        public bool ChecaTokenAdministrador(string token)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlBuilder = string.Format("SELECT Token from [dbo].[Usuario] where Token = '{0}' and Administrador = 1",
                    token);
                var tokenEAdministrador =  dbConnection.Query<string>(sqlBuilder).ToList().Any();
                dbConnection.Close();
                return tokenEAdministrador;
            }
        }

        public void RegistrarUsuario(Usuario usuario)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlBuilder = string.Format("INSERT INTO [dbo].[Usuario] VALUES('{0}','{1}','{2}','{3}','{4}')",
                    usuario.Token,usuario.Login,usuario.Senha,usuario.Administrador,1);
                dbConnection.Query<string>(sqlBuilder);
                dbConnection.Close();
            }
        }

        public bool ValidaToken(string token)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlBuilder = string.Format("SELECT Token from [dbo].[Usuario] where Token = '{0}'",
                    token);
                bool valido = dbConnection.Query<string>(sqlBuilder).ToList().Any(); 
                dbConnection.Close();
                return valido;
            }
        }

        public void AlterarUsuario(Usuario usuario)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlBuilder = string.Format("UPDATE [dbo].[Usuario] SET Token = '{0}', Login_Usuario = '{1}', Senha_Usuario = '{2}',Administrador = '{3}',Ativo = '{4}' WHERE TOKEN ='{0}'",
                    usuario.Token,usuario.Login,usuario.Senha,usuario.Administrador,1);
                dbConnection.Query<string>(sqlBuilder); 
                dbConnection.Close();
            }
        }

        public void ExcluirUsuario(Usuario usuario)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlBuilder = string.Format(
                    "UPDATE [dbo].[Usuario] SET Ativo = '{1}' WHERE TOKEN = '{0}'",
                    usuario.Token, 0);
                dbConnection.Query<string>(sqlBuilder);
                dbConnection.Close();
            }
        }

        public List<UsuarioListar> ListarUsuarios(string token)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlBuilder = "SELECT * from [dbo].[Usuario] where Administrador = '0' and Ativo = '1'";
                var listaDeUsuarios = dbConnection.Query<UsuarioListar>(sqlBuilder).ToList();
                dbConnection.Close();
                return listaDeUsuarios;
            }
        }
    }
}