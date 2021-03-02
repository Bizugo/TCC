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
    /// Classe FeriasModel
    /// </summary>
    public class FeriasModel : IFeriasRepository
    {
        /// <summary>
        /// Propriedade FeriasContext
        /// </summary>
        private readonly StudioContext _context;
        /// <summary>
        /// Construtor da Classe FeriasModel
        /// </summary>
        /// <param name="feriasContext"></param>
        public FeriasModel(StudioContext feriasContext)
        {
            this._context = feriasContext;
        }
        /// <summary>
        /// Método AtualizaFerias
        /// </summary>
        /// <param name="ferias"></param>
        public void AtualizaFerias(Ferias ferias)
        {
            Ferias f = _context.Ferias.Find(ferias.ferias_id);
            f.dataFim = ferias.dataFim;
            f.dataInicio = ferias.dataInicio;
            _context.Entry(f).State = EntityState.Modified;
        }
        /// <summary>
        /// Método ConsultarFeriasPorIDPessoa
        /// </summary>
        /// <param name="idferias"></param>
        /// <returns></returns>
        public Ferias ConsultarFeriasPorID(Int32 idferias)
        {
            return _context.Ferias.Find(idferias);
        }
        /// <summary>
        /// Método ConsultarFerias
        /// </summary>
        /// <returns></returns>
        public List<Ferias> ConsultarFerias(string cpf)
        {
            return _context.Ferias.Where(f => f.cpf == cpf).ToList();
        }
        /// <summary>
        /// Método DeletarFerias
        /// </summary>
        /// <param name="idPessoa"></param>
        public void DeletarFerias(Int32 idFerias)
        {
            Ferias ferias = _context.Ferias.Find(idFerias);
            _context.Ferias.Remove(ferias);
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
        /// Método InserirFerias
        /// </summary>
        /// <param name="ferias"></param>
        public void InserirFerias(Ferias ferias)
        {
            _context.Ferias.Add(ferias);
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