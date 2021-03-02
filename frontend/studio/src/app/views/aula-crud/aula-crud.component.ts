import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Aula } from 'src/app/models/aula.model';
import { AulaService } from 'src/app/services/aula.service';
import { HeaderService } from 'src/app/services/header.service';

@Component({
  selector: 'app-aula-crud',
  templateUrl: './aula-crud.component.html',
  styleUrls: ['./aula-crud.component.css']
})
export class AulaCrudComponent implements OnInit {
  aula: Aula = {
    aula_id: undefined,
    nome: '',
    nome_instrutor: '',
    horario_inicio: '',
    horario_fim: '',
    dias_semana: '',
    sala: ''
  }
  nomePesquisa: string = '';
  diaSelecionado: string = '';
  dias: any = [
    { valor: "0", desc: "TODOS" },
    { valor: "1", desc: "SEG, QUA, SEX" },
    { valor: "2", desc: "TER, QUI, SÁB" }
  ];
  selectedQuantity = "0";
  constructor(private router: Router, private aulaService: AulaService, private headerService: HeaderService) {
    headerService.headerData = {
      title: 'Aulas',
      icon: 'event',
      routeUrl: '/aulas'
    }
  }

  ngOnInit(): void {
    if(localStorage.getItem('aut') === null || localStorage.getItem('aut') === '') {
      this.aulaService.exibirMensagem("Usuário não autorizado", false);
      this.router.navigate(['/login'])
    }
  }

  navegarParaAulaCreate(): void {
    this.router.navigate(['/aula/create'])
  }

  buscarAula(): void {
    if (this.nomePesquisa === undefined || this.nomePesquisa === "") {
      this.aulaService.exibirMensagem("Por favor informar o Nome da Aula!");
    }
    else {
      this.aulaService.buscar(this.nomePesquisa).subscribe((data: any) => {
        if (data !== "Registro não encontrado") {
          this.aula = JSON.parse(data)
          this.selectedQuantity = this.aula.dias_semana;
        }
        else {
          this.aulaService.exibirMensagem(data);
          this.limpar()
        }
      });
    }
  }

  atualizarAula(): void {
    if (this.aula.nome === undefined || this.aula.nome === "") {
      this.aulaService.exibirMensagem("Por favor informar uma aula!");
    }
    else {
      const mensagem = this.aulaService.validaAula(this.aula)
      if (mensagem !== null) {
        this.aulaService.exibirMensagem(mensagem);
      }
      else {
        this.aula.dias_semana = this.diaSelecionado
        this.aulaService.atualizar(this.aula).subscribe((data: any) => {
          this.aulaService.exibirMensagem(data);
        });
      }
    }
  }

  deletarAula(): void {
    if (this.aula.nome === undefined || this.aula.nome === "") {
      this.aulaService.exibirMensagem("Por favor informar um aula!");
    }
    else {
      this.aulaService.deletar(this.nomePesquisa).subscribe((data: any) => {
        if (data === "Registro deletado com Sucesso") {
          this.limpar();
        }
        this.aulaService.exibirMensagem(data);
      });
    }
  }

  limpar(): void {
    this.aula.aula_id = undefined;
    this.aula.nome = '';
    this.aula.nome_instrutor = '',
      this.aula.horario_inicio = '';
    this.aula.horario_fim = '';
    this.aula.dias_semana = '';
    this.aula.sala = '';
    this.selectedQuantity = "0";
    // this.nomePesquisa = '';
  }

  SelecionaDias(ob: any) {
    this.diaSelecionado = ob;
    console.log(this.diaSelecionado);
  }

}
