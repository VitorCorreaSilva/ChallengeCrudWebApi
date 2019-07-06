using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CrudChallengeApiWeb.Util
{
    public class DAL
    {
        private static string Server = "localhost";
        private static string Database = "livraria";
        private static string User = "novousuario";
        private static string Password = "minhasenha";
        private MySqlConnection Connection;

        private string ConnectionString = $"Server={Server};Database={Database};Uid={User};Pwd={Password};Sslmode=none;charset=utf8;";

        public DAL()
        {
            Connection = new MySqlConnection(ConnectionString);
            Connection.Open();
        }

        //Executa: INSERT, UPDATE, DELETE
        public void ExecutarComandoSQL(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }

        //Retorna Dados do Banco
        public DataTable RetornarDataTable(string sql)
        {
            MySqlCommand Command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter DataAdaptar = new MySqlDataAdapter(Command);
            DataTable Dados = new DataTable();
            DataAdaptar.Fill(Dados);
            return Dados;
        }
    }
}
