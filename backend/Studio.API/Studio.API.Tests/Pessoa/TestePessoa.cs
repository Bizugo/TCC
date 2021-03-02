using Microsoft.VisualStudio.TestTools.UnitTesting;
using Studio.API.Controllers;
using System;

namespace Studio.API.Tests.Pessoa
{
    [TestClass]
    public class TestePessoa
    {
        [TestMethod]
        public void TestarConsultaPorCPFComSucesso()
        {
            PessoaController pesssoaController = new PessoaController();
            var t = pesssoaController.ConsultarPessoaPorCPF("999.999.999-99");
            Assert.AreEqual("{\"nome\":\"string\",\"identidade\":\"string\",\"cpf\":\"999.999.999-99\",\"ativo\":true,\"endereco\":\"string\",\"data_pagamento\":\"2021-03-12T00:00:00\",\"inadimplente\":false,\"tipo_atividade\":\"\",\"funcionario\":false}",
                t);
        }

        [TestMethod]
        public void TestarInserirPessoaComSucesso()
        {
            PessoaController pesssoaController = new PessoaController();
            var t = pesssoaController.InserirPessoa(new Entities.Pessoa()
            {
                nome = "string",
                identidade = "string",
                cpf = "string",
                ativo = true,
                endereco = "string",
                data_pagamento = DateTime.Today,
                inadimplente = true,
                tipo_atividade = "string",
                funcionario = true
            });
            Assert.AreEqual("Registro inserido com Sucesso", t);
        }
    }
}
