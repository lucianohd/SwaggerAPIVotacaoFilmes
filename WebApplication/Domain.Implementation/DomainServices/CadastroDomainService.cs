using System;
using System.Collections.Generic;
using Domain.Implementation.Exceptions;
using Domain.Implementation.Validators;
using Domain.Specs.DomainServices;
using Domain.Specs.ValueObjects;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Repositories.Spec.Repositories;


namespace Domain.Implementation.DomainServices
{
    public class CadastroDomainService : ICadastroDomainService
    {
        private IUsuarioRepository _usuarioRepository;
        public CadastroDomainService(){}
        
        public CadastroDomainService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario CadastrarUsuario(Usuario usuario, string token)
        {
            ValidarUsuario(usuario);
            ValidaToken(token);
            var usuarioExiste = PesquisarUsuario(usuario.Login);

            var administrador = ChecaTokenAdministrador(token);
            if ((!usuarioExiste && administrador) || (!usuarioExiste && !administrador && usuario.Administrador == false))
            {
                RegistraUsuario(usuario);
            }

            return usuario;
        }

        private void ValidaToken(string token)
        {
            if(!_usuarioRepository.ValidaToken(token))
                throw new IMDbException(003, Mensagens.Mensagens.MSG003);
        }

        private void RegistraUsuario(Usuario usuario)
        {
            _usuarioRepository.RegistrarUsuario(usuario);
        }

        private bool ChecaTokenAdministrador(string token)
        {
            return _usuarioRepository.ChecaTokenAdministrador(token);
        }

        private bool PesquisarUsuario(string login)
        {
            return _usuarioRepository.PesquisarUsuario(login);;
        }

        public Usuario EditarUsuario(Usuario usuario, string token)
        {
            ValidarUsuario(usuario);
            ValidaToken(token);
            ValidaToken(usuario.Token);
            var administrador = ChecaTokenAdministrador(token);
            if (administrador||(!administrador && usuario.Administrador == false))
            {
                AlterarUsuario(usuario);
            }
            return usuario;
        }

        private void AlterarUsuario(Usuario usuario)
        {
            _usuarioRepository.AlterarUsuario(usuario);
        }

        public Usuario ExcluirUsuario(Usuario usuario, string token)
        {
            if (ValidarUsuario(usuario))
                throw new IMDbException(404, Mensagens.Mensagens.MSG006);

            ValidaToken(token);
            ValidaToken(usuario.Token);
            var administrador = ChecaTokenAdministrador(token); //Se for administrador pode mudar qualquer um, usuario só pode mudar se estiver tentando a si mesmo
            var usuarioDeletarClasse = ChecaTokenAdministrador(usuario.Token);
            if((administrador) || (!administrador && !usuarioDeletarClasse)){
                ExcluirUsuario(usuario);
            }
            return usuario;
        }

        public void ExcluirUsuario(Usuario usuario)
        {
            _usuarioRepository.ExcluirUsuario(usuario);
        }

        public List<UsuarioListar> ListarUsuarios(string token, bool ordemAlfabetica)
        {
            var administrador = ChecaTokenAdministrador(token);
            if(!administrador)
                throw new IMDbException(005, Mensagens.Mensagens.MSG003);
            var listaDeUsuarios = new List<UsuarioListar>();
            if (administrador)
            {
                listaDeUsuarios = ListarNaoAdministradores(token, ordemAlfabetica);
            }

            return listaDeUsuarios;
        }

        private List<UsuarioListar> ListarNaoAdministradores(string token, bool ordemAlfabetica)
        {
            return _usuarioRepository.ListarUsuarios(token, ordemAlfabetica);
        }

        public bool ValidarUsuario(Usuario usuario)
        {
            var validator = new UsuarioValidator();
            var resultado = validator.Validate(usuario);
            return resultado.IsValid;
        }
    }
    
}