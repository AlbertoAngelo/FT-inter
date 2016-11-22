using InterFood.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterFood.Models
{
    public class PessoaModel : ModelBase
    {
        public List<Pessoa> Read()
        {
            List<Pessoa> lista = new List<Pessoa>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM Pessoa";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Pessoa pessoa = new Pessoa();
                pessoa.IdPessoa = (int)reader["IdPessoa"];
                pessoa.Nome = reader["Nome"] as string;
                pessoa.Telefone = reader["Telefone"] as string;
                pessoa.Celular = reader["Celular"] as string;
                pessoa.Email = reader["Email"] as string;
                pessoa.Senha = reader["Senha"] as string;
                pessoa.TipoPessoa = (int)reader["TipoPessoa"];
                pessoa.Status = (int)reader["Status"];

                lista.Add(pessoa);
            }
            return lista;
        }

        //Validar Login
        public Pessoa Login(string email, string senha) { 

            Pessoa pessoa = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM Pessoa WHERE Email = @email AND Senha = @senha";

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                pessoa = new Pessoa();
                pessoa.IdPessoa = (int)reader["IdPessoa"];
                pessoa.TipoPessoa = (int)reader["TipoPessoa"];
                pessoa.Nome = reader["Nome"] as string;
            }
                return pessoa;
        }
    }
}