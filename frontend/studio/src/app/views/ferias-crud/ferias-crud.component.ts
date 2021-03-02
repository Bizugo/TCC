import { FeriasService } from 'src/app/services/ferias.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Ferias } from 'src/app/models/ferias.model';
import { HeaderService } from 'src/app/services/header.service';

@Component({
  selector: 'app-ferias-crud',
  templateUrl: './ferias-crud.component.html',
  styleUrls: ['./ferias-crud.component.css']
})
export class FeriasCrudComponent implements OnInit {

  ferias!: Ferias[];
  displayedColumns = ['CPF', 'DataInicio', 'DataFim', 'action'];
  cpfPesquisa: any;

  constructor(private router: Router, private headerService: HeaderService, private feriasService: FeriasService, private route: ActivatedRoute) {
    headerService.headerData = {
      title: 'Férias',
      icon: 'luggage',
      routeUrl: '/ferias'
    }
  }

  ngOnInit(): void {
    if (localStorage.getItem('aut') === null || localStorage.getItem('aut') === '') {
      this.feriasService.exibirMensagem("Usuário não autorizado", false);
      this.router.navigate(['/login'])
    }
    else {
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

  navegarParaFeriasCreate(): void {
    this.router.navigate(['/ferias/create'])
  }

}
