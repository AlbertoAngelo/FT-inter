using InterFood.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterFood.Models
{
    public class TruckModel : ModelBase
    {


        public void Create(Truck truck)
        {
            SqlCommand cmd = new SqlCommand("AddTruck", connection);
            cmd.Connection = connection;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", truck.Nome);
            cmd.Parameters.AddWithValue("@Telefone", truck.Telefone);
            cmd.Parameters.AddWithValue("@Celular", truck.Celular);
            cmd.Parameters.AddWithValue("@Email", truck.Email);
            cmd.Parameters.AddWithValue("@Senha", truck.Senha);
            cmd.Parameters.AddWithValue("@TipoPessoa", 0);
            cmd.Parameters.AddWithValue("@Status", 1);
            cmd.Parameters.AddWithValue("@CNPJ", truck.CNPJ);
            cmd.Parameters.AddWithValue("@NomeTruck", truck.NomeTruck);
            cmd.Parameters.AddWithValue("@DescricaoTruck", truck.DescricaoTruck);
            cmd.Parameters.AddWithValue("@Logo", truck.Logo);
            cmd.Parameters.AddWithValue("@CEP", truck.CEP);
            cmd.Parameters.AddWithValue("@Estado", truck.Estado);
            cmd.Parameters.AddWithValue("@Cidade", truck.Cidade);
            cmd.Parameters.AddWithValue("@Bairro", truck.Bairro);
            cmd.Parameters.AddWithValue("@Endereco", truck.Endereco);
            cmd.Parameters.AddWithValue("@Numero", truck.Numero);
            cmd.Parameters.AddWithValue("@Referencia", truck.Referencia);
            cmd.Parameters.AddWithValue("@Latitude", truck.Latitude);
            cmd.Parameters.AddWithValue("@Longitude", truck.Longitude);

            cmd.ExecuteNonQuery();
        }

        public Truck Read(int IdPessoa)
        {
            Truck truck = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT truck.IdTruck, truck.IdPessoa, truck.CNPJ, truck.NomeTruck, truck.DescricaoTruck, truck.CEP, truck.Estado,
                                truck.Cidade, truck.Bairro, truck.Endereco, truck.Numero, truck.Referencia, pessoa.Nome, pessoa.IdPessoa, pessoa.Telefone,
                                pessoa.Celular, pessoa.Email
                FROM Truck, Pessoa WHERE truck.IdPessoa = pessoa.IdPessoa AND truck.IdPessoa = @id";

            cmd.Parameters.AddWithValue("@id", IdPessoa);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                truck = new Truck();
                truck.IdTruck = (int)reader["IdTruck"];
                truck.IdPessoa = (int)reader["IdPessoa"];
                truck.CNPJ = reader["CNPJ"] as string;
                truck.Nome = reader["Nome"] as string;
                truck.NomeTruck = reader["NomeTruck"] as string;
                truck.DescricaoTruck = reader["DescricaoTruck"] as string;
                truck.CEP = reader["CEP"] as string;
                truck.Estado = reader["Estado"] as string;
                truck.Cidade = reader["Cidade"] as string;
                truck.Bairro = reader["Bairro"] as string;
                truck.Endereco = reader["Endereco"] as string;
                truck.Numero = reader["Numero"] as string;
                truck.Referencia = reader["Referencia"] as string;
                truck.Telefone = reader["Telefone"] as string;
                truck.Celular = reader["Celular"] as string;
                truck.Email = reader["Email"] as string;
            }
            return truck;
        }
        public void Update(Truck truck)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Truck SET NomeTruck = @NomeTruck, DescricaoTruck = @DescricaoTruck 
                                WHERE IdTruck = @IdTruck";

            cmd.Parameters.AddWithValue("@NomeTruck", truck.NomeTruck);
            cmd.Parameters.AddWithValue("@DescricaoTruck", truck.DescricaoTruck);
            cmd.Parameters.AddWithValue("@IdTruck", truck.IdTruck);


            cmd.ExecuteNonQuery();
        }
        public void UpdateLocalizacao(Truck truck)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Truck SET CEP = @CEP, Endereco = @Endereco, Numero = @Numero, Bairro = @Bairro, Cidade = @Cidade,
                                Estado = @Estado, Referencia = @Referencia 
                                WHERE IdTruck = @IdTruck";

            cmd.Parameters.AddWithValue("@CEP", truck.CEP);
            cmd.Parameters.AddWithValue("@Endereco", truck.Endereco);
            cmd.Parameters.AddWithValue("@Numero", truck.Numero);
            cmd.Parameters.AddWithValue("@Bairro", truck.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", truck.Cidade);
            cmd.Parameters.AddWithValue("@Estado", truck.Estado);
            cmd.Parameters.AddWithValue("@Referencia", truck.Referencia);
            cmd.Parameters.AddWithValue("@IdTruck", truck.IdTruck);

            cmd.ExecuteNonQuery();
        }
        public void UpdateInformacoes(Truck truck)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Pessoa SET Nome = @Nome, Telefone = @Telefone, Celular = @Celular
                                WHERE IdPessoa = @IdPessoa";

            cmd.Parameters.AddWithValue("@Nome", truck.Nome);
            cmd.Parameters.AddWithValue("@Telefone", truck.Telefone);
            cmd.Parameters.AddWithValue("@Celular", truck.Celular);
            cmd.Parameters.AddWithValue("@IdPessoa", truck.IdPessoa);

            cmd.ExecuteNonQuery();
        }
        public void UpdateUsuario(Truck truck)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Pessoa SET Email = @Email, Senha = @Senha
                                WHERE IdPessoa = @IdPessoa";

            cmd.Parameters.AddWithValue("@Email", truck.Email);
            cmd.Parameters.AddWithValue("@Senha", truck.Senha);
            cmd.Parameters.AddWithValue("@IdPessoa", truck.IdPessoa);

            cmd.ExecuteNonQuery();
        }
    }
}