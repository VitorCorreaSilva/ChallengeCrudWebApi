﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudChallengeApiWeb.Util
{
    public class Autenticacao
    {
        public static string TOKEN = "chave_secreta";
        public static string FALHA_AUTENTICACAO = "Falha na Autenticação... O Token informado é inválido!";
        IHttpContextAccessor contextAccessor;

        public Autenticacao(IHttpContextAccessor context)
        {
            contextAccessor = context;
        }

        public void Autenticar()
        {
            try
            {
                string TokenRecebido = contextAccessor.HttpContext.Request.Headers["Token"].ToString();

                if (String.Equals(TOKEN, TokenRecebido) == false)
                {
                    throw new Exception(FALHA_AUTENTICACAO);
                }
            }
            catch
            {
                throw new Exception(FALHA_AUTENTICACAO);
            }
        }
    }
}
