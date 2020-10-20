using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class EditarUsuarioModel
    {
        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Senha { get; set; }
        
        [Required]
        public bool Administrador { get; set; }
        
        [Required]
        public string CodigoUsuario { get; set; }
        
        [Required]
        public string TokenEditor { get; set; }
    }
}