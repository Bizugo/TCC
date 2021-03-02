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
    /// Classe AulaModel
    /// </summary>
    public class AulaModel : IAulaRepository
    {
        /// <summary>
        /// Propriedade FeriasContext
        /// </summary>
        private readonly StudioContext _context;
        /// <summary>
        /// Construtor da Classe FeriasModel
        /// </summary>
        /// <param name="aulaContext"></param>
        public AulaModel(StudioContext aulaContext)
        {
            this._context = aulaContext;
        }
        /// <summary>
        /// Método AtualizarAula
        /// </summary>
        /// <param name="aula"></param>
        public void AtualizarAula(Aula aula)
        {
            _context.Entry(aula).State = EntityState.Modified;
        }
        /// <summary>
        /// Método ConsultarAulaPorNome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Aula ConsultarAulaPorNome(string nome)
        {
            return _context.Aula.Where(a => a.nome == nome).FirstOrDefault();
        }
        /// <summary>
        /// Método ConsultarAulas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Aula> ConsultarAulas()
        {
            return _context.Aula.ToList();
        }
        /// <summary>
        /// Método DeletarAula
        /// </summary>
        /// <param name="aula"></param>
        public void DeletarAula(Aula aula)
        {
            _context.Aula.Remove(aula);
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
        /// Método InserirAula
        /// </summary>
        /// <param name="aula"></param>
        public void InserirAula(Aula aula)
        {
            _context.Aula.Add(aula);
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