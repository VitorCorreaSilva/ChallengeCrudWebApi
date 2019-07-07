using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudChallengeApiWeb.Models;
using CrudChallengeApiWeb.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudChallengeApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        Autenticacao AutenticacaoServico;

        public LivroController(IHttpContextAccessor context)
        {
            AutenticacaoServico = new Autenticacao(context);
        }

        // GET api/livro/listagem
        [HttpGet]
        [Route("listagem")]
        public List<LivroModel> Listagem()
        {
            return new LivroModel().Listagem();
        }

        // GET api/livro/5
        [HttpGet]
        [Route("{id}")]
        public LivroModel RetornarLivro(int id)
        {
            return new LivroModel().RetornaLivro(id);
        }

        // POST api/livro/registrarlivro
        [HttpPost]
        [Route("registrarlivro")]
        public ReturnAllServices RegistrarLivro([FromBody]LivroModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                AutenticacaoServico.Autenticar();
                dados.RegistrarLivro();
                retorno.Result = true;
                retorno.ErrorMessage = "Livro cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar registrar um cliente: " + ex.Message;
            }

            return retorno;
        }

        // PUT api/livro/atualizar/5
        [HttpPut]
        [Route("atualizar/{id}")]
        public ReturnAllServices Atualizar(int id, [FromBody]LivroModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.Id = id;
                AutenticacaoServico.Autenticar();
                dados.AtualizarLivro();
                retorno.Result = true;
                retorno.ErrorMessage = "Livro atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar atualizar um livro: " + ex.Message;
            }

            return retorno;
        }

        // DELETE api/livro/excluir/5
        [HttpDelete]
        [Route("excluir/{id}")]
        public ReturnAllServices Excluir(int id)
        {
            ReturnAllServices retorno = new ReturnAllServices();
            try
            {
                retorno.Result = true;
                retorno.ErrorMessage = "Livro excluído com sucesso!";
                AutenticacaoServico.Autenticar();
                new LivroModel().Excluir(id);

            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = ex.Message;
            }
            return retorno;
        }
    }
}
