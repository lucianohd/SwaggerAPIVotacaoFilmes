using Domain.Implementation.DomainServices;
using FluentAssertions;
using UnitTests.Cadastro.Fakers;
using Xunit;

namespace UnitTests.Cadastro
{
    public class FilmeTeste
    {
        private FilmeDomainService _filmeDomain; 
        public FilmeTeste()
        {
            _filmeDomain = new FilmeDomainService();
        }
        [Fact]
        public void Retorna_Sucesso_Ao_Tentar_Validar_Voto()
        {
            //arrange
            var usuario = VotoFaker.GetVotoCerto();
            //act
            var validacao = _filmeDomain.ValidarVoto(usuario);
            //assert
            validacao.Should().BeFalse();
        }
        [Fact]
        public void Retorna_Erro_Ao_Tentar_Validar_Voto()
        {
            //arrange
            var usuario = VotoFaker.GetVotoErrado();
            //act
            var validacao = _filmeDomain.ValidarVoto(usuario);
            //assert
            validacao.Should().BeTrue();
        }
        [Fact]
        public void Retorna_Sucesso_Ao_Tentar_Validar_Filme()
        {
            //arrange
            var usuario = FilmeFaker.GetFilmeCerto();
            //act
            var validacao = _filmeDomain.ValidarFilme(usuario);
            //assert
            validacao.Should().BeTrue();
        } 
        [Fact]
        public void Retorna_Erro_Ao_Tentar_Validar_Filme()
        {
            //arrange
            var usuario = FilmeFaker.GetFilmeErrado();
            //act
            var validacao = _filmeDomain.ValidarFilme(usuario);
            //assert
            validacao.Should().BeFalse();
        }
        
        
        
        
    }
}