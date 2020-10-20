namespace Domain.Specs.ValueObjects
{
    public class Voto
    {
        public Voto(string filmeId,string? usuario, double nota)
        {
            FilmeId = filmeId;
            Usuario = usuario;
            Nota = nota;
        }
        public string FilmeId { get; set; }
        public string Usuario { get; set; }
        public double Nota { get; set; }
    }
}