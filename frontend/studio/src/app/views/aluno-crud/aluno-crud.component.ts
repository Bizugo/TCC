import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router'
import { Pessoa } from 'src/app/models/pessoa.model'
import { PessoaService } from 'src/app/services/pessoa.service'
import { HeaderService } from 'src/app/services/header.service';

@Component({
  selector: 'app-aluno-crud',
  templateUrl: './aluno-crud.component.html',
  styleUrls: ['./aluno-crud.component.css']
})
export class AlunoCrudComponent implements OnInit {

  aluno: Pessoa = {
    cpf: '',
    nome: '',
    identidade: '',
    endereco: '',
    data_pagamento: '',
    funcionario: false,
    tipo_pessoa: ''
  }

  cpfPesquisa: string = '';
  pagamentoSelecionado: string = ""
  pagamentos: any = [
    { valor: "0", desc: "Anual" },
    { valor: "1", desc: "Mensal" },
  ];
  selectedPagamento = "0";

  constructor(private router: Router, private alunoService: PessoaService, private headerService: HeaderService) {
    headerService.headerData = {
      title: 'Alunos',
      icon: 'person',
      routeUrl: '/alunos'
    }
  }

  ngOnInit(): void {
    if (localStorage.getItem('aut') === null || localStorage.getItem('aut') === '') {
      this.alunoService.exibirMensagem("Usuário não autorizado", false);
      this.router.navigate(['/login'])
    }
  }

  navegarParaAlunoCreate(): void {
    this.router.navigate(['/aluno/create'])
  }

  buscarAluno(): void {
    if (this.cpfPesquisa === undefined || this.cpfPesquisa === "") {
      this.alunoService.exibirMensagem("Por favor informar um CPF!");
    }
    else {
      this.alunoService.buscar(this.cpfPesquisa).subscribe((data: any) => {
        if (data !== "Registro não encontrado") {
          this.aluno = JSON.parse(data)
          const dtPagamento = new DatePipe('en-US').transform(this.aluno.data_pagamento, 'dd/MM/yyyy')
          this.aluno.data_pagamento = dtPagamento !== null ? dtPagamento : ""
          this.selectedPagamento = this.aluno.tipo_pagamento !== undefined ? this.aluno.tipo_pagamento : "0"

          if (this.aluno.inadimplente) {
            this.alunoService.exibirMensagem("Aluno Inadimplente");
          }
        }
        else {
          this.alunoService.exibirMensagem(data);
        }
      });
    }
  }

  atualizarAluno(): void {
    if (this.aluno.cpf === undefined || this.aluno.cpf === "") {
      this.alunoService.exibirMensagem("Por favor informar um aluno!");
    }
    else {
      const mensagem = this.alunoService.validaPessoa(this.aluno)
      if (mensagem !== null) {
        this.alunoService.exibirMensagem(mensagem);
      } else {
        this.aluno.tipo_pagamento = this.pagamentoSelecionado;
        this.alunoService.atualizar(this.aluno).subscribe((data: any) => {
          this.alunoService.exibirMensagem(data);
        });
      }
    }
  }

  deletarAluno(): void {
    if (this.aluno.cpf === undefined || this.aluno.cpf === "") {
      this.alunoService.exibirMensagem("Por favor informar um aluno!");
    }
    else {
      this.alunoService.deletar(this.cpfPesquisa).subscribe((data: any) => {
        if (data === "Registro deletado com Sucesso") {
          this.limpar();
        }
        this.alunoService.exibirMensagem(data);
      });
    }
  }

  limpar(): void {
    this.aluno.cpf = '';
    this.aluno.nome = '';
    this.aluno.identidade = '';
    this.aluno.endereco = '';
    this.aluno.data_pagamento = '';
    this.aluno.funcionario = false;
    this.aluno.tipo_pessoa = '';
    this.selectedPagamento = "0";
  }

  
  SelecionaPagamento(ob: any) {
    this.pagamentoSelecionado = ob.value;
  }
}
