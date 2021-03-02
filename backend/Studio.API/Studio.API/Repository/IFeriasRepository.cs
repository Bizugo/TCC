using Studio.API.Entities;
using System;
using System.Collections.Generic;

namespace Studio.API.Repository
{
    interface IFeriasRepository : IDisposable
    {
        List<Ferias> ConsultarFerias(string cpf);
        Ferias ConsultarFeriasPorID(Int32 idFerias);
        void InserirFerias(Ferias ferias);
        void DeletarFerias(Int32 idFerias);
        void AtualizaFerias(Ferias ferias);
        string Salvar();
    }
}