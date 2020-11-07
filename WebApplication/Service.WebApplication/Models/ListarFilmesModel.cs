using System.ComponentModel.DataAnnotations;
using Domain.Specs.Filters;
using Domain.Specs.ValueObjects;

namespace WebApplication.Models
{
    public class ListarFilmesModel
    {
        [Required]
        public string Diretor { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public string Atores { get; set; }
        [Required]
        public bool alfabetica { get; set; }
        [Required]
        public bool votacao { get; set; }
    }
}