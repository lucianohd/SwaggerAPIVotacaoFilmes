namespace Domain.Specs.Filters
{
    public class OrdemFilter
    {
        public OrdemFilter(bool alfabetica, bool votacao)
        {
            Alfabetica = alfabetica;
            Votacao = votacao;
        }
        public bool Alfabetica;
        public bool Votacao;
    }
}