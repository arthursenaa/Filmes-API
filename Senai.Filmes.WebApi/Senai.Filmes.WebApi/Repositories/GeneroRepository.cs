using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class GeneroRepository
    {
        public string StringConexao = "Data Source=localhost;Initial Catalog=RoteiroFilmes;User Id=sa;Pwd=132";

        public List<GenerosDomain> Listar()
        {
            List<GenerosDomain> generos = new List<GenerosDomain>();

            string Query = "select* from Generos";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        GenerosDomain genero = new GenerosDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }

        public GenerosDomain Buscarid(int Id)
        {

            string Query = "Select * from Generos where IdGenero = @Id ";

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
                            GenerosDomain genero = new GenerosDomain()
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            };

                            return genero;
                        }
                    }
                    return null;

                }
            }
        }

        public void Cadastrar(GenerosDomain generosDomain)
        {
            string Query = "Insert into Generos (Nome) values(@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", generosDomain.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Atualizar(GenerosDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // string Query = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome WHERE IdFuncionario = @IdFuncionario";
                string QueryUp = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(QueryUp, con))
                {

                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            string QueryDel = "DELETE FROM Generos WHERE IdGenero = @IdGenero;";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(QueryDel, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    con.Open();
                    //cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
