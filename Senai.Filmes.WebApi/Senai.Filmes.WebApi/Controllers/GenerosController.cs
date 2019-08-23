using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repositories;

namespace Senai.Filmes.WebApi.Controllers
{

    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GenerosController : Controller
    {

        GeneroRepository GeneroRepository = new GeneroRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(GeneroRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarId(int Id)
        {
            GenerosDomain generosDomain = GeneroRepository.Buscarid(Id);
            //GenerosDomain generosDomain = new GeneroRepository.BuscarId(Id);
            if (generosDomain == null)
                return NotFound();
            return Ok(generosDomain);
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, GenerosDomain genero)
        {
            genero.IdGenero = id;
            GeneroRepository.Atualizar(genero);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            GeneroRepository.Deletar(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Cadastro(GenerosDomain generosDomain)
        {
            GeneroRepository.Cadastrar(generosDomain);
            return Ok();
        }
    }
}