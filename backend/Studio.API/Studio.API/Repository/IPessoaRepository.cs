using Studio.API.Entities;
using System;
using System.Collections.Generic;

namespace Studio.API.Repository
{
    interface IPessoaRepository : IDisposable
    {
        IEnumerable<Pessoa> ConsultarPessoas();
        Pessoa ConsultarPessoaPorCPF(string cpf);
        void InserirPessoa(Pessoa pessoa);
        void DeletarPessoa(Pessoa pessoa);
        void AtualizaPessoa(Pessoa pessoa);
        string Salvar();
    }
}
