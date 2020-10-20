using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class FilmeModel
    {
        public string Diretor { get; set; }
        
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string Genero { get; set; }

        public string Atores { get; set; }
        
        [Required]
        public string Token { get; set; }
    }
}