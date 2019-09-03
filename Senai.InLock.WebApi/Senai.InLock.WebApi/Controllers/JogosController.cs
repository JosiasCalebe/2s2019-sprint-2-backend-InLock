using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;
using Senai.InLock.WebApi.ViewsModel;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        JogoRepository jogoRepository = new JogoRepository();
        //CRUD PARA ADMS E SÓ LISTAGEM PARA USER


        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(jogoRepository.Listar());
        }


        [Authorize(Roles ="A")]
        [HttpPost]
        public IActionResult Inserir(Jogos jogo)
        {
            try
            {
                jogoRepository.Inserir(jogo);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
         
        [Authorize(Roles ="A")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                jogoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "A")]
        [HttpPut("{id}")]
        public IActionResult Alterar(int id,Jogos jogo)
        {
            jogo.JogoId = id;
            try
            {
                jogoRepository.Alterar(jogo);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpGet("{lancamentos}")]
        public IActionResult Lancamentos()
        {
            return Ok(jogoRepository.Lancamentos());
        }

        [Authorize]
        [HttpGet("{nome}/buscar")]
        public IActionResult BuscarPeloNome(string nome)
        {
            try
            {
                List<JogoViewModel> a = jogoRepository.BuscarPeloNome(nome);
                return Ok(a);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [Authorize]
        [HttpGet("maiscaros")]
        public IActionResult MaisCaros()
        {

            return Ok(jogoRepository.MaisCaros());
        }

        [Authorize]
        [HttpGet("lancamentos")]
        public IActionResult Listarr()
        {
            return Ok(jogoRepository.Listarr());

        }

    }
}
