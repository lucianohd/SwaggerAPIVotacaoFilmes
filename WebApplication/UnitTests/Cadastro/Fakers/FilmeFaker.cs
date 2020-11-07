using Domain.Specs.ValueObjects;

namespace UnitTests.Cadastro.Fakers
{
    public class FilmeFaker
    {
        public static Filme GetFilmeCerto()
        {
            return new Filme("Teste","Teste","Teste","Teste");
        }
        public static Filme GetFilmeErrado()
        {
            return new Filme("TESTETETETETETETETE","Teste","Tetesteataetaetaetaetaetojiaoeijtaoiste","teste");
        }
    }
}