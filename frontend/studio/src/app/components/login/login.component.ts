import { PessoaService } from './../../services/pessoa.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Pessoa } from 'src/app/models/pessoa.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  usuario: Pessoa = {
    cpf: '999.999.999-99',
    nome: 'Recepcionista 1',
    identidade: '99.999.999-9',
    endereco: 'Rua Teste, 1234',
    data_pagamento: '',
    funcionario: true,
    senha: '12345678',
    tipo_pessoa: 'Recepcionista'
  }
  cpf: any
  senha: any
  constructor(private router: Router, private usuarioService: PessoaService) { }

  ngOnInit(): void {
  }

  Login() {
    if (this.usuario.cpf !== this.cpf || this.usuario.senha !== this.senha) {
      this.usuarioService.exibirMensagem("Usuario ou Senha inválido");
    }
    else {
      localStorage.setItem("aut", this.usuario.tipo_pessoa)
      this.router.navigate([''])
    }
  }
}
