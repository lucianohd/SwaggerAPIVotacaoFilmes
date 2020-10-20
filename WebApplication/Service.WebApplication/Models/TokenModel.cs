using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class TokenModel
    {
        [Required]
        public string Token { get; set; }
    }
}