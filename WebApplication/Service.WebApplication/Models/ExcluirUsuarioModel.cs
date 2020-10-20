using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class ExcluirUsuarioModel
    {
        [Required] 
        public string TokenUsuarioAExcluir { get; set; }
        [Required] 
        public string TokenIdentificador { get; set; }
        
    }
}