using Studio.API.Context;
using Studio.API.Entities;
using Studio.API.Models;
using Studio.API.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Studio.API.Helpers
{
    /// <summary>
    /// Classe ValidaFerias
    /// </summary>
    public static class ValidaFerias
    {
        /// <summary>
        /// Método VerificarPeriodo
        /// </summary>
        /// <param name="ferias"></param>
        /// <returns></returns>
        public static bool VerificaPeriodo(Ferias ferias)
        {
            IFeriasRepository feriasRepositorio = new FeriasModel(new StudioContext());
            IEnumerable<Ferias> f = feriasRepositorio.ConsultarFerias(ferias.cpf);
            int qtdDias = (ferias.dataFim.Subtract(ferias.dataInicio)).Days;
            int qtdDiasBanco = 0;
            bool retorno = false;

            if (f.Count() == 0)
                retorno = true;
            else if (f.Count() > 0 && f.Count() <= 2)
            {
                foreach (var item in f)
                {
                    qtdDiasBanco += (item.dataFim.Subtract(item.dataInicio)).Days;
                }
                if (qtdDias > 30 || (qtdDias + qtdDiasBanco) > 30)
                {
                    retorno = false;
                }
                else
                    retorno = true;
            }

            return retorno;
        }
        /// <summary>
        /// Método VerificaData
        /// </summary>
        /// <param name="ferias"></param>
        /// <returns></returns>
        public static bool VerificaData(Ferias ferias, bool update = false)
        {
            IFeriasRepository feriasRepositorio = new FeriasModel(new StudioContext());
            IEnumerable<Ferias> f = feriasRepositorio.ConsultarFerias(ferias.cpf);
            bool retorno = true;
            foreach (var item in f)
            {
                if (update)
                {
                    if (item.dataFim == ferias.dataFim && item.dataInicio == ferias.dataInicio)
                        retorno = false;
                }
                else
                {
                    if (item.dataFim == ferias.dataFim || item.dataInicio == ferias.dataInicio)
                        retorno = false;
                }
            }
            return retorno;
        }
    }
}