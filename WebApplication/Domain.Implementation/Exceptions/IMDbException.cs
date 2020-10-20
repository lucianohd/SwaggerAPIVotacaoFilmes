using System;

namespace Domain.Implementation.Exceptions
{
    public class IMDbException : Exception
    {
        public IMDbException(int codigo, string mensagem) : base(mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
    }
}