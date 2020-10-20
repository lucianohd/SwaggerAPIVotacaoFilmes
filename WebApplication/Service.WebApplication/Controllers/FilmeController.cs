using System;
using Domain.Implementation.Exceptions;
using Domain.Specs.DomainServices;
using Domain.Specs.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class FilmeController : ControllerBase
    {
        private IFilmeDomainService _filmeDomainService;
        
        public FilmeController(IFilmeDomainService filmeDomainService)
        {
            _filmeDomainService = filmeDomainService;
        }
        
        [Route("Cadastrar/Filme")]
        [HttpPost]
        public JsonResult CadastrarFilme([FromBody] FilmeModel filmeModel)
        {
            try
            {
                var filme = new Filme(filmeModel.Diretor, filmeModel.Nome, filmeModel.Genero, filmeModel.Atores);
                _filmeDomainService.CadastrarFilme(filme, filmeModel.Token);
                return new JsonResult(filme);
            }
            catch (IMDbException ex)
            {
                return new JsonResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }
        [Route("Votar/Filme")]
        [HttpPost]
        public JsonResult VotarFilme([FromBody] VotoModel votoModel)
        {
            try
            {
                var voto = new Voto(votoModel.FilmeId, null, votoModel.Nota);
                _filmeDomainService.VotarFilme(voto, votoModel.Token);
                return new JsonResult("Voto Computado");
            }
            catch (IMDbException ex)
            {
                return new JsonResult(ex);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }
    }
}