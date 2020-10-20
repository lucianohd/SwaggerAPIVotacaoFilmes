using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public interface ICadastroController
    {
        JsonResult CadastrarUsuario([FromBody] UsuarioModel usuarioModel);
    }
}