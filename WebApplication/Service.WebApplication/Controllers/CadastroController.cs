using System;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Domain.Implementation.Exceptions;
using Domain.Specs.ValueObjects;
using Domain.Implementation.DomainServices;
using Domain.Implementation.Mensagens;
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
        [HttpPut]
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
        [HttpDelete]
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
        [HttpGet]
        public JsonResult ListarUsuarios([FromBody] ListarUsuarioModel listarUsuario)
        {
            try
            {
                var listaDeUsuarios = _cadastroDomainService.ListarUsuarios(listarUsuario.Token,listarUsuario.OrdemAlfabetica);
                
                if (!listaDeUsuarios.Any())
                {
                    throw new IMDbException(005, Mensagens.MSG005);
                }
                string jsonResposta = JsonConvert.SerializeObject(listaDeUsuarios);

                return new JsonResult(jsonResposta);
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
    }
}