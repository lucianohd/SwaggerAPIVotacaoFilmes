using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class ListarUsuarioModel
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public bool OrdemAlfabetica { get; set; }
    }
}