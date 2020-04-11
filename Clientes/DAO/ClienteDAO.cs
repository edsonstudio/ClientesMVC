using System.Collections.Generic;
using Clientes.Models;
using MySql.Data.MySqlClient;

namespace Clientes.DAO
{
    public class ClienteDAO : Dao
    {
        private const string SQL_SELECT = "SELECT id, nome, cpf FROM cliente";
        private const string SQL_INSERT = "INSERT INTO Cliente (id, nome, cpf) VALUES (?,?,?)";
        private const string SQL_UPDATE = "UPDATE cliente SET nome=@nome, cpf=@cpf WHERE id=@id";
        private const string SQL_DELETE = "DELETE FROM Cliente WHERE Id=?";
        private const string SQL_PESQUISAR = "SELECT id, nome, cpf FROM cliente WHERE id=@id";
        private const string SQL_PESQUISAR_NOME = "SELECT id, nome, cpf FROM cliente WHERE nome=@nome";
        private const string SQL_PESQUISAR_CPF = "SELECT id, nome, cpf FROM cliente WHERE cpf=@cpf";

        public void Adicionar(Cliente cliente)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_INSERT, this.Connection);

                cmd.Parameters.AddWithValue("@id", cliente.Id);
                cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);

                this.Conectar();

                cmd.ExecuteNonQuery();
            }
            finally
            {
                this.Desconectar();
            }
        }

        public void Atualizar(Cliente cliente)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_UPDATE, this.Connection);

                cmd.Parameters.AddWithValue("@id", cliente.Id);
                cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);

                this.Conectar();

                cmd.ExecuteNonQuery();
            }
            finally
            {
                this.Desconectar();
            }
        }

        public void Delete(int id)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_DELETE, this.Connection);

                cmd.Parameters.AddWithValue("@id", id);

                this.Conectar();

                cmd.ExecuteNonQuery();
            }
            finally
            {
                this.Desconectar();
            }
        }

        public List<Cliente> SelecionarTodos()
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT, this.Connection);

                this.Conectar();

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var c = new Cliente();
                    c.Id = (int)dr["id"];
                    c.Nome = (string)dr["nome"];
                    c.Cpf = (string)dr["cpf"];

                    clientes.Add(c);
                }

                return clientes;
            }
            finally
            {
                this.Desconectar();
            }
        }

        public Cliente PesqId(Cliente cliente)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_PESQUISAR, this.Connection);

                cmd.Parameters.AddWithValue("@id", cliente.Id);

                this.Conectar();

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    var c = new Cliente();
                    c.Id = (int)dr["id"];
                    c.Nome = (string)dr["nome"];
                    c.Cpf = (string)dr["cpf"];

                    cliente = c;
                }

                return cliente;
            }
            finally
            {
                this.Desconectar();
            }
        }

        public Cliente PesqNm(Cliente cliente)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_PESQUISAR_NOME, this.Connection);

                cmd.Parameters.AddWithValue("@nome", cliente.Nome);

                this.Conectar();

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    var c = new Cliente();
                    c.Id = (int)dr["id"];
                    c.Nome = (string)dr["nome"];
                    c.Cpf = (string)dr["cpf"];

                    cliente = c;
                }

                return cliente;
            }
            finally
            {
                this.Desconectar();
            }
        }

        public Cliente PesqCpf(Cliente cliente)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL_PESQUISAR_CPF, this.Connection);

                cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);

                this.Conectar();

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    var c = new Cliente();
                    c.Id = (int)dr["id"];
                    c.Nome = (string)dr["nome"];
                    c.Cpf = (string)dr["cpf"];

                    cliente = c;
                }

                return cliente;
            }
            finally
            {
                this.Desconectar();
            }
        }
    }
}