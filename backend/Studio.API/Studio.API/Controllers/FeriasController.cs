using Studio.API.Context;
using Studio.API.Entities;
using Studio.API.Helpers;
using Studio.API.Models;
using Studio.API.Repository;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Studio.API.Controllers
{
    /// <summary>
    /// Classe FeriasController
    /// </summary>
    public class FeriasController : ApiController
    {
        /// <summary>
        /// Propriedade IFeriasRepository
        /// </summary>
        private readonly IFeriasRepository feriasRepositorio;
        /// <summary>
        /// Construtor da Classe FeriasController
        /// </summary>
        public FeriasController()
        {
            this.feriasRepositorio = new FeriasModel(new StudioContext());
        }
        /// <summary>
        /// Método que expõe a funcionalidade de ConsultarFeriasPorIDPessoa
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [Route("ConsultarFeriasPorIDPessoa")]
        [HttpGet]
        public IHttpActionResult ConsultarFeriasPorIDPessoa(string cpf)
        {
            try
            {
                List<Ferias> ferias = feriasRepositorio.ConsultarFerias(cpf);
                return Ok(ferias.Count > 0 ? Newtonsoft.Json.JsonConvert.SerializeObject(ferias) : "Registro não encontrado");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Método que expõe a funcionalidade de ConsultarFeriasPorID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("ConsultarFeriasPorID")]
        [HttpGet]
        public IHttpActionResult ConsultarFeriasPorID(Int32 id)
        {
            try
            {
                Ferias ferias = feriasRepositorio.ConsultarFeriasPorID(id);
                return Ok(ferias != null ? Newtonsoft.Json.JsonConvert.SerializeObject(ferias) : "Registro não encontrado");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Método que expõe a funcionalidade de InserirFerias
        /// </summary>
        /// <param name="ferias"></param>
        /// <returns></returns>
        [Route("InserirFerias")]
        [HttpPost]
        public IHttpActionResult InserirFerias(Ferias ferias)
        {
            try
            {
                IPessoaRepository pessoaRepositorio = new PessoaModel(new StudioContext());
                Pessoa pessoa = pessoaRepositorio.ConsultarPessoaPorCPF(ferias.cpf);
                if (pessoa == null)
                {
                    return Ok("CPF não encontrado na base.");
                }
                else if (pessoa.tipo_pagamento == "1")
                {
                    return Ok("Registro de férias não pode ser feito para clientes mensais.");
                }
                else
                {
                    if (ValidaFerias.VerificaData(ferias))
                    {
                        if (feriasRepositorio.ConsultarFerias(ferias.cpf) != null && !ValidaFerias.VerificaPeriodo(ferias))
                            return Ok("A soma dos dias é maior do que 30 ou já existem 3 períodos cadastrados");
                        else
                            feriasRepositorio.InserirFerias(ferias);

                        if (feriasRepositorio.Salvar() == "1")
                        {
                            //IPessoaRepository pessoaRepositorio = new PessoaModel(new StudioContext());
                            //Pessoa pessoa = pessoaRepositorio.ConsultarPessoaPorCPF(ferias.cpf);
                            pessoa.data_pagamento = pessoa.data_pagamento.AddDays((ferias.dataFim.Subtract(ferias.dataInicio)).Days);
                            pessoaRepositorio.AtualizaPessoa(pessoa);
                            return Ok(pessoaRepositorio.Salvar() == "1" ? "Registro inserido com Sucesso, nova data de pagamento será dia: " + pessoa.data_pagamento : "Registro não inserido");
                        }
                        else
                            return Ok("Registro não inserido");
                    }
                    else
                        return Ok("Data de início ou Data de Fim já cadastrados.");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Método que expõe a funcionalidade de AtualizarFerias
        /// </summary>
        /// <param name="ferias"></param>
        /// <returns></returns>
        [Route("AtualizarFerias")]
        [HttpPut]
        public IHttpActionResult AtualizarFerias(Ferias ferias)
        {
            try
            {
                if (ValidaFerias.VerificaData(ferias, true))
                {
                    if (feriasRepositorio.ConsultarFerias(ferias.cpf) != null && !ValidaFerias.VerificaPeriodo(ferias))
                        return Ok("A soma dos dias é maior do que 30 ou já existem 3 períodos cadastrados");
                    else
                        feriasRepositorio.AtualizaFerias(ferias);

                    if (feriasRepositorio.Salvar() == "1")
                    {
                        IPessoaRepository pessoaRepositorio = new PessoaModel(new StudioContext());
                        Pessoa pessoa = pessoaRepositorio.ConsultarPessoaPorCPF(ferias.cpf);
                        pessoa.data_pagamento = pessoa.data_pagamento.AddDays((ferias.dataFim.Subtract(ferias.dataInicio)).Days);
                        pessoaRepositorio.AtualizaPessoa(pessoa);
                        return Ok(pessoaRepositorio.Salvar() == "1" ? "Registro atualizado com Sucesso" : "Registro não atualizado");
                    }
                    else
                        return Ok("Registro não atualizado");
                }
                else
                    return Ok("Data de início ou Data de Fim já cadastrados.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Método que expõe a funcionalidade de DeletarFerias
        /// </summary>
        /// <param name="idFerias"></param>
        /// <returns></returns>
        [Route("DeletarFerias")]
        [HttpDelete]
        public IHttpActionResult DeletarFerias(Int32 idFerias)
        {
            try
            {
                feriasRepositorio.DeletarFerias(idFerias);
                return Ok(feriasRepositorio.Salvar() == "1" ? "Registro deletado com Sucesso" : "Registro não deletado");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
