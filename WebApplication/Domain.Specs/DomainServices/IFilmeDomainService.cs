using System.Collections.Generic;
using Domain.Specs.Filters;
using Domain.Specs.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Specs.DomainServices
{
    public interface IFilmeDomainService
    {
        JsonResult CadastrarFilme(Filme Filme, string Token);
        JsonResult VotarFilme(Voto voto, string Token);
        List<FilmeOrdenado> ListarFilmes(Filme filtroFilme, OrdemFilter filtroOrdem);
        bool ValidarVoto(Voto voto);
        bool ValidarFilme(Filme filme);
    }
}