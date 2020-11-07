using Domain.Implementation.DomainServices;
using Domain.Specs.DomainServices;
using Moq;
using UnitTests.Cadastro.Fakers;
using FluentAssertions;
using Xunit;

namespace UnitTests.Cadastro
{
    public class CadastroTeste
    {
        private CadastroDomainService _cadastroDomain;

        public CadastroTeste()
        {
            _cadastroDomain = new CadastroDomainService();
        }
        [Fact]
        public void Retorna_Sucesso_Ao_Tentar_Validar_Usuario()
        {
            //arrange
            var usuario = CadastroFaker.GetUsuarioCerto();
            //act
            var validacao = _cadastroDomain.ValidarUsuario(usuario);
            //assert
            validacao.Should().BeTrue();
        }
        [Fact]
        public void Retorna_Erro_Ao_Tentar_Validar_Usuario()
        {
            //arrange
            var usuario = CadastroFaker.GetUsuarioErrado();
            //act
            var validacao = _cadastroDomain.ValidarUsuario(usuario);
            //assert
            validacao.Should().BeFalse();
        }
    }
}