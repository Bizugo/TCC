using Studio.API.Context;
using Studio.API.Entities;
using Studio.API.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Studio.API.Models
{
    /// <summary>
    /// Classe PessoaModel
    /// </summary>
    public class PessoaModel : IPessoaRepository
    {
        /// <summary>
        /// Propriedade PessoaContext
        /// </summary>
        private readonly StudioContext _context;
        /// <summary>
        /// Construtor da Classe PessoaModel
        /// </summary>
        /// <param name="pessoaContext"></param>
        public PessoaModel(StudioContext pessoaContext)
        {
            this._context = pessoaContext;
        }
        /// <summary>
        /// Método AtualizaPessoa
        /// </summary>
        /// <param name="pessoa"></param>
        public void AtualizaPessoa(Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;
        }
        /// <summary>
        /// Método ConsultarPessoaPorCPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public Pessoa ConsultarPessoaPorCPF(string cpf)
        {
            return _context.Pessoas.Where(p => p.cpf == cpf).FirstOrDefault();
            //return _context.Pessoas.Find(cpf);
        }
        /// <summary>
        /// Método ConsultarPessoas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Pessoa> ConsultarPessoas()
        {
            return _context.Pessoas.ToList();
        }
        /// <summary>
        /// Método DeletarPessoa
        /// </summary>
        /// <param name="pessoa"></param>
        public void DeletarPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Remove(pessoa);
        }
        private bool disposed = false;
        /// <summary>
        /// Método virtual Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        /// <summary>
        /// Método Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Método InserirPessoa
        /// </summary>
        /// <param name="pessoa"></param>
        public void InserirPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
        }
        /// <summary>
        /// Método Salvar
        /// </summary>
        public string Salvar()
        {
            return _context.SaveChanges().ToString();
        }
    }
}