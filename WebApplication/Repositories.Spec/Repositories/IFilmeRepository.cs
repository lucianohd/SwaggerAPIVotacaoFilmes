using System.Collections.Generic;
using Domain.Specs.Filters;
using Domain.Specs.ValueObjects;

namespace Repositories.Spec.Repositories
{
    public interface IFilmeRepository
    {
        void CadastrarFilme(Filme filme);
        bool ChecarSeFilmeExiste(string filmeId);
        string RetornaNomeUsuarioPorToken(string token);
        void RegistraVoto(Voto voto);
        List<FilmeOrdenado> ProcurarFilmes(Filme filtroFilme, OrdemFilter filtroOrdem);
    }
}