using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class FilmeRepository
    {

        public string StringConexao = "Data Source=localhost;Initial Catalog=RoteiroFilmes;User Id=sa;Pwd=132";

        public List<FilmesDomain> Listar()
        {
            List<FilmesDomain> filmes = new List<FilmesDomain>();

            string Query = "select * from Filmes";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FilmesDomain filme = new FilmesDomain
                        {
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                            Titulo = sdr["Titulo"].ToString(),
                            IdGenero = Convert.ToInt32(sdr["IdGenero"])
                        };
                        filmes.Add(filme);
                    }
                }
            }
            return filmes;
        }

        public FilmesDomain BuscarPorId(int Id)
        {

            string Query = "Select IdFilme , Titulo,IdGenero from Filmes where IdFilme = @Id ";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FilmesDomain filmes = new FilmesDomain()
                            {
                                IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                                Titulo = sdr["Titulo"].ToString(),
                                IdGenero = Convert.ToInt32(sdr["IdGenero"])
                            };

                            return filmes;
                        }
                    }
                    return null;
                }
            }
        }



        public void Cadastrar(FilmesDomain filmesDomain)
        {
            string Query = "Insert into Filmes (Titulo , IdGenero) values(@Titulo , @IdGenero)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", filmesDomain.Titulo);
                cmd.Parameters.AddWithValue("@IdGenero", filmesDomain.IdGenero);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
