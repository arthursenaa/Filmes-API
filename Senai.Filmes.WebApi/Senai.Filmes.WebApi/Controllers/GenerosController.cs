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
            //GenerosDomain generosDomain = new GeneroRepository.BuscarId(Id);
            if (GeneroRepository == null)
                return NotFound();
            return Ok(GeneroRepository);
        }
    }
}