using Microsoft.AspNetCore.Cors;
using Studio.API.Context;
using Studio.API.Entities;
using Studio.API.Models;
using Studio.API.Repository;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Studio.API.Controllers
{
    /// <summary>
    /// Classe PessoaController
    /// </summary>

    [Route("api")]
    [EnableCors()]
    public class PessoaController : ApiController
    {
        /// <summary>
        /// Propriedade IPessoaRepository
        /// </summary>
        private readonly IPessoaRepository pessoaRepositorio;
        /// <summary>
        /// Construtor da Classe PessoaController
        /// </summary>
        public PessoaController()
        {
            this.pessoaRepositorio = new PessoaModel(new StudioContext());
        }
        /// <summary>
        /// Método que expõe a funcionalidade de ConsultarPessoaPorCPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [Route("ConsultarPessoaPorCPF")]
        [HttpGet]
        public IHttpActionResult ConsultarPessoaPorCPF(string cpf)
        {
            try
            {
                Pessoa pessoa = pessoaRepositorio.ConsultarPessoaPorCPF(cpf);
                return Ok(pessoa != null ? Newtonsoft.Json.JsonConvert.SerializeObject(pessoa) : "Registro não encontrado");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
        /// <summary>
        /// Método que expõe a funcionalidade de InserirPessoa
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        [Route("InserirPessoa")]
        [HttpPost]
        public IHttpActionResult InserirPessoa(Pessoa pessoa)
        {
            try
            {
                if (pessoaRepositorio.ConsultarPessoaPorCPF(pessoa.cpf) == null)
                {
                    pessoa.data_pagamento = DateTime.Today.AddDays(30);
                    pessoaRepositorio.InserirPessoa(pessoa);
                    return Ok(pessoaRepositorio.Salvar() == "1" ? "Registro inserido com Sucesso" : "Registro não inserido");
                }
                else
                    return Ok("Registro já cadastrado");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Método que expõe a funcionalidade de AtualizarPessoa
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        [Route("AtualizarPessoa")]
        [HttpPut]
        public IHttpActionResult AtualizarPessoa(Pessoa pessoa)
        {
            try
            {
                pessoaRepositorio.AtualizaPessoa(pessoa);
                return Ok(pessoaRepositorio.Salvar() == "1" ? "Registro atualizado com Sucesso" : "Registro não atualizado");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Método que expõe a funcionalidade de DeletarPessoa
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [Route("DeletarPessoa")]
        [HttpDelete]
        public IHttpActionResult DeletarPessoa(string cpf)
        {
            try
            {
                bool ret = false;
                Pessoa pessoa = pessoaRepositorio.ConsultarPessoaPorCPF(cpf);
                if (pessoa != null)
                {
                    pessoaRepositorio.DeletarPessoa(pessoa);
                    if (pessoaRepositorio.Salvar() == "1")
                    {
                        ret = true;
                        IFeriasRepository feriasRepositorio = new FeriasModel(new StudioContext());
                        List<Ferias> ferias = feriasRepositorio.ConsultarFerias(cpf);
                        if (ferias.Count > 0)
                            foreach (var item in ferias)
                            {
                                feriasRepositorio.DeletarFerias(item.ferias_id);
                                feriasRepositorio.Salvar();
                            }
                    }
                    return Ok(ret ? "Registro deletado com Sucesso" : "Registro não deletado");
                }
                else
                    return Ok("Registro não encontrado");

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}