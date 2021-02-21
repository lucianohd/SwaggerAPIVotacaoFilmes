using System;
using System.Linq;
using Domain.Implementation.Exceptions;
using Domain.Implementation.Mensagens;
using Domain.Specs.DomainServices;
using Domain.Specs.Filters;
using Domain.Specs.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        
        [Route("Listar/Filmes")]
        [HttpGet]
        public JsonResult ListarFilmes([FromBody] ListarFilmesModel listarFilmesModel)
        {
            try
            {
                var filtroFilme = new Filme(listarFilmesModel.Diretor,listarFilmesModel.Nome,listarFilmesModel.Genero,listarFilmesModel.Atores);
                var filtroOrdem = new OrdemFilter(listarFilmesModel.alfabetica,listarFilmesModel.votacao);
                var listaDeFilmes = _filmeDomainService.ListarFilmes(filtroFilme,filtroOrdem);
                
                if (!listaDeFilmes.Any())
                {
                    throw new IMDbException(005, Mensagens.MSG005);
                }
                string jsonResposta = JsonConvert.SerializeObject(listaDeFilmes);

                return new JsonResult(jsonResposta);
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
    }
}