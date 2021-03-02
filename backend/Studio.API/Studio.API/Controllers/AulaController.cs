using Studio.API.Context;
using Studio.API.Entities;
using Studio.API.Models;
using Studio.API.Repository;
using System;
using System.Web.Http;

namespace Studio.API.Controllers
{
    /// <summary>
    /// Classe AulaController
    /// </summary>
    public class AulaController : ApiController
    {

        /// <summary>
        /// Propriedade IPessoaRepository
        /// </summary>
        private readonly IAulaRepository aulaRepositorio;
        /// <summary>
        /// Construtor da Classe AulaController
        /// </summary>
        public AulaController()
        {
            this.aulaRepositorio = new AulaModel(new StudioContext());
        }
        /// <summary>
        /// Método que expõe a funcionalidade de ConsultarAulaPorNome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [Route("ConsultarAulaPorNome")]
        [HttpGet]
        public IHttpActionResult ConsultarAulaPorNome(string nome)
        {
            try
            {
                Aula aula = aulaRepositorio.ConsultarAulaPorNome(nome);
                return Ok(aula != null ? Newtonsoft.Json.JsonConvert.SerializeObject(aula) : "Registro não encontrado");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
        /// <summary>
        /// Método que expõe a funcionalidade de InserirAula
        /// </summary>
        /// <param name="aula"></param>
        /// <returns></returns>
        [Route("InserirAula")]
        [HttpPost]
        public IHttpActionResult InserirAula(Aula aula)
        {
            try
            {
                if (aulaRepositorio.ConsultarAulaPorNome(aula.nome) == null)
                {
                    aulaRepositorio.InserirAula(aula);
                    return Ok(aulaRepositorio.Salvar() == "1" ? "Registro inserido com Sucesso" : "Registro não inserido");
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
        /// Método que expõe a funcionalidade de AtualizarAula
        /// </summary>
        /// <param name="aula"></param>
        /// <returns></returns>
        [Route("AtualizarAula")]
        [HttpPut]
        public IHttpActionResult AtualizarAula(Aula aula)
        {
            try
            {
                aulaRepositorio.AtualizarAula(aula);
                return Ok(aulaRepositorio.Salvar() == "1" ? "Registro atualizado com Sucesso" : "Registro não atualizado");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// Método que expõe a funcionalidade de DeletarAula
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [Route("DeletarAula")]
        [HttpDelete]
        public IHttpActionResult DeletarAula(string nome)
        {
            try
            {
                Aula aula = aulaRepositorio.ConsultarAulaPorNome(nome);
                if (aula != null)
                {
                    aulaRepositorio.DeletarAula(aula);
                    return Ok(aulaRepositorio.Salvar() == "1" ? "Registro deletado com Sucesso" : "Registro não deletado");
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
