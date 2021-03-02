using Studio.API.Entities;
using System;
using System.Collections.Generic;

namespace Studio.API.Repository
{
    interface IAulaRepository : IDisposable
    {
        IEnumerable<Aula> ConsultarAulas();
        Aula ConsultarAulaPorNome(string nome);
        void InserirAula(Aula aula);
        void DeletarAula(Aula aula);
        void AtualizarAula(Aula aula);
        string Salvar();
    }
}