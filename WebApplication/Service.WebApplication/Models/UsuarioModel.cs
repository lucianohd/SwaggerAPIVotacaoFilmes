using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class UsuarioModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public bool Administrador { get; set; }
    }
}