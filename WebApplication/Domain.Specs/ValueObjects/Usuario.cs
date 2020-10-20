using System;

namespace Domain.Specs.ValueObjects
{
    public class Usuario 
    {
        public Usuario(string login, string senha, bool administrador)
        {
            Login = login;
            Senha = senha;
            Token = Guid.NewGuid().ToString();
            Administrador = administrador;
        }
        public Usuario(string login, string senha, bool administrador, string token)
        {
            Login = login;
            Senha = senha;
            Token = token;
            Administrador = administrador;
        }

        public Usuario(string token)
        {
            Login = "l";
            Senha = "s";
            Token = token;
            Administrador = false;
        }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
        public bool Administrador { get; set; }
    }
}