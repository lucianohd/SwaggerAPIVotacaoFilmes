using System.Collections.Generic;
using Domain.Specs.ValueObjects;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Specs.DomainServices
{
    public interface ICadastroDomainService
    {
        Usuario CadastrarUsuario(Usuario usuario, string token);
        Usuario EditarUsuario(Usuario usuario, string token);
        Usuario ExcluirUsuario(Usuario usuario, string token);
        List<UsuarioListar> ListarUsuarios(string token, bool ordemAlfabetica);
        bool ValidarUsuario(Usuario usuario);
    }
}