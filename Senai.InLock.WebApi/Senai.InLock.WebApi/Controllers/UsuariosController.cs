using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        UsuarioRepository usuarioRepository = new UsuarioRepository();
        
        [Authorize (Roles ="A")]
        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                usuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }




    }
}