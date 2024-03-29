﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;
using Senai.InLock.WebApi.ViewsModel;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        EstudioRepository estudioRepository = new EstudioRepository();
        //CRUD PARA ADMS E SÓ LISTAGEM PARA USER

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estudioRepository.Listar());
        }

        [Authorize(Roles = "A")]
        [HttpPost]
        public IActionResult Inserir(Estudios estudio)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            estudio.UsuarioId = Convert.ToInt32(identity.FindFirst(JwtRegisteredClaimNames.Jti).Value);

            try
            {
                estudioRepository.Inserir(estudio);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "A")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                estudioRepository.Deletar(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "A")]
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Estudios estudio)
        {
            estudio.EstudioId = id;
            try
            {
                estudioRepository.Alterar(estudio);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpGet("jogos")]
        public IActionResult ListarComJogos()
        {
            return Ok(estudioRepository.ListarComJogos());
        }


        [Authorize]
        [HttpGet("{nome}/buscar")]
        public IActionResult BuscarPeloNome(string nome)
        {
            try
            {
                List<JogoViewModel> a = estudioRepository.BuscarPeloNome(nome);
                return Ok(a);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [Authorize(Roles = "A")]
        [HttpGet("inseridos")]
        public IActionResult InseridosPeloAdm()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int idUser = Convert.ToInt32(identity.FindFirst(JwtRegisteredClaimNames.Jti).Value);

            try
            {
                List<EstudioViewModel> a = estudioRepository.BuscarPeloIdUsuario(idUser);
                return Ok(a);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [Authorize]
        [HttpGet("dezdias")]
        public IActionResult Listarr()
        {
            return Ok(estudioRepository.Listarr());
        }

        [Authorize]
        [HttpGet("pais/{id}")]
        public IActionResult ListarPorPais(int id)
        {
            return Ok(estudioRepository.ListarPorPais(id));
        }
        [Authorize]
        [HttpGet("pais/jogos/{id}")]
        public IActionResult ListarJogosPorPais(int id)
        {
            return Ok(estudioRepository.ListarJogosPorPais(id));
        }



    }
}