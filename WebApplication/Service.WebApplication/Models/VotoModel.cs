using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class VotoModel
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string FilmeId { get; set; }
        [Required]
        public double Nota { get; set; }
    }
}