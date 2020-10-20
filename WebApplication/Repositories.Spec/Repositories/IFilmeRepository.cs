using Domain.Specs.ValueObjects;

namespace Repositories.Spec.Repositories
{
    public interface IFilmeRepository
    {
        void CadastrarFilme(Filme filme);
        bool ChecarSeFilmeExiste(string filmeId);
        string RetornaNomeUsuarioPorToken(string token);
        void RegistraVoto(Voto voto);
    }
}