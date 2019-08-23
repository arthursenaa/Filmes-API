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
    public class FilmesController : Controller
    {

        FilmeRepository FilmeRepository = new FilmeRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(FilmeRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int Id)
        {

            FilmesDomain filmesDomain = FilmeRepository.BuscarPorId(Id);
            //GenerosDomain generosDomain = new GeneroRepository.BuscarId(Id);
            if (filmesDomain == null)
                return NotFound();
            return Ok(filmesDomain);
        }

        [HttpPost]
        public IActionResult Cadastro(FilmesDomain filmesDomain)
        {
            FilmeRepository.Cadastrar(filmesDomain);
            return Ok();
        }
    }
}