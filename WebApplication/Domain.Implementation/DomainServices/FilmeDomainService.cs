using Domain.Implementation.Exceptions;
using Domain.Implementation.Validators;
using Domain.Specs.DomainServices;
using Domain.Specs.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories.Implementation.Repositories;
using Repositories.Spec.Repositories;

namespace Domain.Implementation.DomainServices
{
    public class FilmeDomainService : IFilmeDomainService
    {
        private IFilmeRepository _filmeRepository;
        private IUsuarioRepository _usuarioRepository;

        public FilmeDomainService(IFilmeRepository filmeRepository, IUsuarioRepository usuarioRepository)
        {
            _filmeRepository = filmeRepository;
            _usuarioRepository = usuarioRepository;
        }
        public JsonResult CadastrarFilme(Filme filme, string token)
        {
            //ValidarFilme();
            var administrador = _usuarioRepository.ChecaTokenAdministrador(token);
            if (administrador){
                IncluiFilme(filme);
            }else
            {
                throw new IMDbException(003, Mensagens.Mensagens.MSG003);
            }

            return new JsonResult("Filme Incluido Com Sucesso");
        }

        private void IncluiFilme(Filme filme)
        {
            _filmeRepository.CadastrarFilme(filme);
        }

        public JsonResult VotarFilme(Voto voto, string token)
        {
            ValidarVoto(voto);
            _usuarioRepository.ValidaToken(token);
            ChecaSeFilmeExiste(voto.FilmeId);
            var usuario = PegaNomeUsuarioPorToken(token); // posso ter que castar algo
            voto.Usuario = usuario;
            RegistraVoto(voto);
            return new JsonResult("deu bom no voto");
        }

        private void ValidarVoto(Voto voto)
        {
            var validator = new VotoValidator();
            var resultado = validator.Validate(voto);
            if (!resultado.IsValid){ 
                throw new IMDbException(404, resultado.ToString(" , "));
            }
        }

        private void RegistraVoto(Voto voto)
        {
            _filmeRepository.RegistraVoto(voto);
        }

        private string PegaNomeUsuarioPorToken(string token)
        {
            return _filmeRepository.RetornaNomeUsuarioPorToken(token);
        }

        private void ChecaSeFilmeExiste(string votoFilmeId)
        {
            if(!_filmeRepository.ChecarSeFilmeExiste(votoFilmeId)){
                throw new IMDbException(004, Mensagens.Mensagens.MSG004);
            }
        }
    }
}