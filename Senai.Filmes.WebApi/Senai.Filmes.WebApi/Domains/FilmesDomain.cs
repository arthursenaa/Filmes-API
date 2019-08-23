using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Domains
{
    public class FilmesDomain
    {
        public int IdFilme { get; set; }
        public string Titulo { get; set; }
        public int IdGenero { get; set; }
        public GenerosDomain Genero { get; set; }
    }
}
