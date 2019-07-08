using CrudChallengeApiWeb.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CrudChallengeApiWeb.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public double Valor { get; set; }
        public string Autor { get; set; }
        public string Tipo { get; set; }

        public void RegistrarLivro()
        {
            DAL objDAL = new DAL();

            string sql = "insert into livro(titulo, valor, autor, tipo) " +
                         $"values('{Titulo}','{Valor}','{Autor}','{Tipo}')";

            objDAL.ExecutarComandoSQL(sql);
        }

        public void AtualizarLivro()
        {
            DAL objDAL = new DAL();

            string sql = "update livro set " +
                         $"titulo ='{Titulo}'," +
                         $"valor='{Valor}', " +
                         $"autor='{Autor}', " +
                         $"tipo='{Tipo}' where id={Id}";

            objDAL.ExecutarComandoSQL(sql);
        }

        public void Excluir(int id)
        {
            DAL objDAL = new DAL();

            string sql = $"delete from livro where id = {id}";
            objDAL.ExecutarComandoSQL(sql);
        }

        public List<LivroModel> Listagem()
        {
            List<LivroModel> lista = new List<LivroModel>();
            LivroModel item;

            DAL objDAL = new DAL();

            string sql = "select * from livro order by titulo asc";
            DataTable dados = objDAL.RetornarDataTable(sql);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                item = new LivroModel()
                {
                    Id = int.Parse(dados.Rows[i]["Id"].ToString()),
                    Titulo = dados.Rows[i]["Titulo"].ToString(),
                    Valor = double.Parse(dados.Rows[i]["Valor"].ToString()),
                    Autor = dados.Rows[i]["Autor"].ToString(),
                    Tipo = dados.Rows[i]["Tipo"].ToString()
                };

                lista.Add(item);
            }
            return lista;
        }

        public LivroModel RetornaLivro(int id)
        {
            LivroModel item;
            DAL objDAL = new DAL();

            string sql = $"select * from livro where id = {id}";
            DataTable dados = objDAL.RetornarDataTable(sql);

            item = new LivroModel()
            {
                Id = int.Parse(dados.Rows[0]["Id"].ToString()),
                Titulo = dados.Rows[0]["Titulo"].ToString(),
                Valor = double.Parse(dados.Rows[0]["Valor"].ToString()),
                Autor = dados.Rows[0]["Autor"].ToString(),
                Tipo = dados.Rows[0]["Tipo"].ToString()
            };

            return item;
        }
    }
}
