import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Ferias } from 'src/app/models/ferias.model';
import { FeriasService } from 'src/app/services/ferias.service';

@Component({
  selector: 'app-ferias-delete',
  templateUrl: './ferias-delete.component.html',
  styleUrls: ['./ferias-delete.component.css']
})
export class FeriasDeleteComponent implements OnInit {

  ferias: Ferias = {
    ferias_id: undefined,
    cpf: "",
    dataFim: "", //Date
    dataInicio: "", //Date
  }
  constructor(private feriasService: FeriasService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id: any = this.route.snapshot.paramMap.get('id')
    this.feriasService.buscarPorId(id).subscribe((data: any) => {
      if (data !== "Registro não encontrado") {
        this.ferias = JSON.parse(data)
        const dtInicio = new DatePipe('en-US').transform(this.ferias.dataInicio, 'dd/MM/yyyy')
        const dtFim = new DatePipe('en-US').transform(this.ferias.dataFim, 'dd/MM/yyyy')
        this.ferias.dataInicio = dtInicio !== null ? dtInicio : ""
        this.ferias.dataFim = dtFim !== null ? dtFim : ""
      }
      else {
        this.feriasService.exibirMensagem(data);
      }
    })
  }

  deleteFerias(): void {
    if (this.ferias.ferias_id === undefined || this.ferias.ferias_id === 0) {
      this.feriasService.exibirMensagem("Por favor informar um registro de férias!");
    }
    else {
      this.feriasService.deletar(this.ferias.ferias_id).subscribe((data: any) => {
        this.feriasService.exibirMensagem(data);
        this.router.navigate(['/ferias/crud/' + this.ferias.cpf])
      });
    }
  }

  cancel(): void {
    this.router.navigate(['/ferias/crud/' + this.ferias.cpf])
  }

}
