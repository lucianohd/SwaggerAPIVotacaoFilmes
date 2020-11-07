using Domain.Specs.ValueObjects;

namespace UnitTests.Cadastro.Fakers
{
    public class VotoFaker
    {
        public static Voto GetVotoCerto()
        {
            return new Voto("1","testeUsuario",3);
        }
        public static Voto GetVotoErrado()
        {
            return new Voto("1","testeUsuario",7);
        }
    }
}