import { Pessoa } from 'src/app/models/pessoa.model';
import { Router } from '@angular/router';
import { PessoaService } from 'src/app/services/pessoa.service';
import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-aluno-create',
  templateUrl: './aluno-create.component.html',
  styleUrls: ['./aluno-create.component.css']
})
export class AlunoCreateComponent implements OnInit {

  aluno: Pessoa = {
    cpf: '',
    nome: '',
    identidade: '',
    endereco: '',
    data_pagamento: '',
    funcionario: false,
    tipo_pessoa: 'Aluno'
  }
  pagamentoSelecionado: string = ""
  constructor(private alunoService: PessoaService, private router: Router) { }

  ngOnInit(): void {

  }

  createAluno(): void {
    this.aluno.tipo_pagamento = this.pagamentoSelecionado;

    const mensagem = this.alunoService.validaPessoa(this.aluno)
    if (mensagem !== null) {
      this.alunoService.exibirMensagem(mensagem);
    } else {
      this.alunoService.criar(this.aluno).subscribe((data: any) => {
        this.alunoService.exibirMensagem(data);
        this.router.navigate(['/alunos'])
      });
    }

  }

  cancel(): void {
    this.router.navigate(['/alunos'])
  }

  SelecionaPagamento(ob: any) {
    this.pagamentoSelecionado = ob.value;
  }
}
