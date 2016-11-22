using InterFood.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterFood.Models
{
    public class ClienteModel : ModelBase
    {
        public void Create(Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand("AddCliente", connection);
            cmd.Connection = connection;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
            cmd.Parameters.AddWithValue("@Celular", cliente.Celular);
            cmd.Parameters.AddWithValue("@Email", cliente.Email);
            cmd.Parameters.AddWithValue("@Senha", cliente.Senha);
            cmd.Parameters.AddWithValue("@TipoPessoa", 1);
            cmd.Parameters.AddWithValue("@Status", 1);
            cmd.Parameters.AddWithValue("@CPFCNPJ", cliente.CPFCNPJ);

            cmd.ExecuteNonQuery();
        }
    }
}