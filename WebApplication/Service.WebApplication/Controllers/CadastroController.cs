using System;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Domain.Implementation.Exceptions;
using Domain.Specs.ValueObjects;
using Domain.Implementation.DomainServices;
using Domain.Specs.DomainServices;
using JsonApiSerializer;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace WebApplication.Controllers
{
    public class CadastroController : ControllerBase
    {
        private ICadastroDomainService _cadastroDomainService;

        public CadastroController(ICadastroDomainService cadastroDomainService)
        {
            _cadastroDomainService = cadastroDomainService;
        }

        /// <summary>
        /// 1.1. Cadastrar Usuário
        /// </summary>
        [Route("Cadastrar/Usuario")]
        [HttpPost]
        public JsonResult CadastrarUsuario([FromBody] UsuarioModel usuarioModel)
        {
            try
            {
                var usuario = new Usuario(usuarioModel.Login, usuarioModel.Senha, usuarioModel.Administrador);
                _cadastroDomainService.CadastrarUsuario(usuario, usuarioModel.Token);
                return new JsonResult(usuario);
            }
            catch (IMDbException ex)
            {
                return new JsonResult(ex);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }
        /// <summary>
        /// 1.2. Editar Usuário
        /// </summary>
        [Route("Editar/Usuario")]
        [HttpPost]
        public JsonResult EditarUsuario([FromBody] EditarUsuarioModel usuarioModel)
        {
            try
            {
                var usuario = new Usuario(usuarioModel.Login, usuarioModel.Senha, usuarioModel.Administrador, usuarioModel.CodigoUsuario);
                _cadastroDomainService.EditarUsuario(usuario, usuarioModel.TokenEditor);
                return new JsonResult(usuario);
            }
            catch (IMDbException ex)
            {
                return new JsonResult(ex);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }
        /// <summary>
        /// 1.3. Excluir Usuário
        /// </summary>
        [Route("Excluir/Usuario")]
        [HttpPost]
        public JsonResult ExcluirUsuario([FromBody] ExcluirUsuarioModel usuarioModel)
        {
            try
            {
                var usuario = new Usuario(usuarioModel.TokenUsuarioAExcluir);
                _cadastroDomainService.ExcluirUsuario(usuario, usuarioModel.TokenIdentificador);
                return new JsonResult(usuario);
            }
            catch (IMDbException ex)
            {
                return new JsonResult(ex.Message);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }
        /// <summary>
        /// 1.4. Listar Usuários
        /// </summary>
        [Route("Listar/Usuarios")]
        [HttpPost]
        public JsonResult ListarUsuarios([FromBody] TokenModel token)
        {

                var listaDeUsuarios = _cadastroDomainService.ListarUsuarios(token.Token);
                var options = new JsonApiSerializerSettings(){
                    WriteIndented = true
                };
                var json = new string("");
                var json2 = JsonSerializer.Serialize(listaDeUsuarios.First(), options);
                foreach (var usuario in listaDeUsuarios)
                {
                    json2 = JsonSerializer.Serialize(usuario, options);

                }
                //string json = JsonSerializer.Serialize(listaDeUsuarios, options);

                return new JsonResult(json);
        }
    }
}