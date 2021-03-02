import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Ferias } from 'src/app/models/ferias.model';
import { FeriasService } from 'src/app/services/ferias.service';

@Component({
  selector: 'app-ferias-read',
  templateUrl: './ferias-read.component.html',
  styleUrls: ['./ferias-read.component.css']
})
export class FeriasReadComponent implements OnInit {

  ferias!: Ferias[];
  displayedColumns = ['CPF', 'DataInicio', 'DataFim', 'action'];
  cpfPesquisa: any;

  constructor(private feriasService: FeriasService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const cpf: any = this.route.snapshot.paramMap.get('cpf')
    console.log(cpf)
    if (cpf !== null) {
      this.cpfPesquisa = cpf
      this.feriasService.buscar(cpf).subscribe((data: any) => {
        if (data !== "Registro não encontrado") {
          this.ferias = JSON.parse(data)
        }
        else {
          this.feriasService.exibirMensagem(data);
        }
      })
    }
  }

  buscarFerias(): void {
    this.feriasService.buscar(this.cpfPesquisa).subscribe((data: any) => {
      if (data !== "Registro não encontrado") {
        this.ferias = JSON.parse(data)
      }
      else {
        this.feriasService.exibirMensagem(data);
      }
    })
  }
}
