using System.Collections.Generic;
using Domain.Specs.ValueObjects;

namespace Repositories.Spec.Repositories
{
    public interface IUsuarioRepository
    {
        bool PesquisarUsuario(string usuario);
        bool ChecaTokenAdministrador(string token);
        void RegistrarUsuario(Usuario usuario);
        bool ValidaToken(string token);
        void AlterarUsuario(Usuario usuario);
        void ExcluirUsuario(Usuario usuario);
        List<UsuarioListar> ListarUsuarios(string token, bool ordemAlfabetica);
    }
}