using Domain.Specs.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Specs.DomainServices
{
    public interface IFilmeDomainService
    {
        JsonResult CadastrarFilme(Filme Filme, string Token);
        JsonResult VotarFilme(Voto voto, string Token);
    }
}