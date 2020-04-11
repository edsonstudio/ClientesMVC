using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Clientes.DAO
{
    public class Dao
    {
        private readonly MySqlConnection connection;

        public MySqlConnection Connection
        {
            get { return this.connection; }
        }

        public Dao()
        {
            this.connection = new MySqlConnection("Server=localhost;Database=db_clientes;USER=root;PASSWORD=;");
        }

        public void Conectar()
        {
            this.connection.Open();
        }

        public void Desconectar()
        {
            this.connection.Close();
        }
    }
}