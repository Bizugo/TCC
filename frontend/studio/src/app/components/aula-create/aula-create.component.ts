import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Aula } from 'src/app/models/aula.model';
import { AulaService } from 'src/app/services/aula.service';

@Component({
  selector: 'app-aula-create',
  templateUrl: './aula-create.component.html',
  styleUrls: ['./aula-create.component.css']
})
export class AulaCreateComponent implements OnInit {
  aula: Aula = {
    aula_id: undefined,
    nome: '',
    nome_instrutor: '',
    horario_inicio: '',
    horario_fim: '',
    dias_semana: '',
    sala: ''
  }
  diaSelecionado: string = '';

  constructor(private aulaService: AulaService, private router: Router) {

  }

  ngOnInit(): void {

  }

  createAula(): void {
    this.aula.dias_semana = this.diaSelecionado;
    const mensagem = this.aulaService.validaAula(this.aula)
    if (mensagem !== null) {
      this.aulaService.exibirMensagem(mensagem);
    }
    else {
      this.aulaService.criar(this.aula).subscribe((data: any) => {
        this.aulaService.exibirMensagem(data);
        this.router.navigate(['/aulas'])
      });
    }
  }

  cancel(): void {
    this.router.navigate(['/aulas'])
  }

  SelecionaDias(ob: any) {
    this.diaSelecionado = ob.value;
  }
}
