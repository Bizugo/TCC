import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Ferias } from 'src/app/models/ferias.model';
import { FeriasService } from 'src/app/services/ferias.service';

@Component({
  selector: 'app-ferias-update',
  templateUrl: './ferias-update.component.html',
  styleUrls: ['./ferias-update.component.css']
})
export class FeriasUpdateComponent implements OnInit {

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
      }
      else {
        this.feriasService.exibirMensagem(data);
      }
    })
  }

  updateFerias(): void {
    if (this.ferias.ferias_id === undefined || this.ferias.ferias_id === 0) {
      this.feriasService.exibirMensagem("Por favor informar um registro de férias!");
    }
    else {
      const mensagem = this.feriasService.validaFerias(this.ferias)
      if (mensagem !== null) {
        this.feriasService.exibirMensagem(mensagem);
      }
      else {
        this.feriasService.atualizar(this.ferias).subscribe((data: any) => {
          this.feriasService.exibirMensagem(data);
          this.router.navigate(['/ferias/crud/' + this.ferias.cpf])
        });
      }
    }
  }

  cancel(): void {
    this.router.navigate(['/ferias/crud/' + this.ferias.cpf])
  }
}
