using Domain.Specs.ValueObjects;

namespace UnitTests.Cadastro.Fakers
{
    public class CadastroFaker
    {
        public static Usuario GetUsuarioCerto()
        {
            return new Usuario("testeLogin","testeSenha",true);
        }
        public static Usuario GetUsuarioErrado()
        {
            return new Usuario("testeLoginteateatasdfasdfaefasefasefsaefasefaefasdfdasfefasdfhsfdh","testeSenha",true);
        }
    }
}