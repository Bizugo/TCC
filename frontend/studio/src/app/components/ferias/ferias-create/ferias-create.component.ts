import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Ferias } from 'src/app/models/ferias.model';
import { FeriasService } from 'src/app/services/ferias.service';

@Component({
  selector: 'app-ferias-create',
  templateUrl: './ferias-create.component.html',
  styleUrls: ['./ferias-create.component.css']
})
export class FeriasCreateComponent implements OnInit {

  ferias: Ferias = {
    ferias_id: undefined,
    cpf: "",
    dataFim: "", //Date
    dataInicio: "", //Date
  }

  constructor(private feriasService: FeriasService, private router: Router) { }

  ngOnInit(): void {
  }

  createFerias(): void {
    const mensagem = this.feriasService.validaFerias(this.ferias)
    if (mensagem !== null) {
      this.feriasService.exibirMensagem(mensagem);
    }
    else {
      const dataInicio = new DatePipe('en-US').transform(this.ferias.dataInicio, 'yyyy/MM/dd')
      const dataFim = new DatePipe('en-US').transform(this.ferias.dataFim, 'yyyy/MM/dd')
      this.ferias.dataInicio = dataInicio !== null ? dataInicio : ""
      this.ferias.dataFim = dataFim !== null ? dataFim : ""
      this.feriasService.criar(this.ferias).subscribe((data: any) => {
        this.feriasService.exibirMensagem(data);
        this.router.navigate(['/ferias'])
      });
    }
  }

  cancel(): void {
    this.router.navigate(['/ferias'])
  }

}
