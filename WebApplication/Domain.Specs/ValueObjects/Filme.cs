namespace Domain.Specs.ValueObjects
{
    public class Filme
    {
        public Filme(string diretor, string nome, string genero, string atores)
        {
            Diretor = diretor;
            Nome = nome;
            Genero = genero;
            Atores = atores;
        }
        public string Diretor { get; set; }
        
        public string Nome { get; set; }
        
        public string Genero { get; set; }

        public string Atores { get; set; }

    }
}