import { Pessoa } from '../models/pessoa.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar} from '@angular/material/snack-bar'
import { EMPTY, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PessoaService {

  baseUrl = '/api/';

  constructor(private snackBar: MatSnackBar, private http: HttpClient) { }

  exibirMensagem(msg:string, isError: boolean = false): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top",
      panelClass: isError ? ['msg-error'] : ['msg-sucess']
    });
  }

  criar(aluno: Pessoa): Observable<string> {
    return this.http.post<string>(this.baseUrl + "InserirPessoa", aluno).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  buscar(cpf: string): Observable<string> {
    return this.http.get<string>(this.baseUrl + "ConsultarPessoaPorCPF?cpf=" + cpf).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  atualizar(aluno: Pessoa): Observable<string> {
    return this.http.put<string>(this.baseUrl + "AtualizarPessoa", aluno).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  deletar(cpf: string): Observable<string> {
    return this.http.delete<string>(this.baseUrl + "DeletarPessoa?cpf=" + cpf).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  errorHandler(e: any): Observable<any> {
    this.exibirMensagem("Ocorreu um erro", true)
    return EMPTY

  }

  validaPessoa(aluno: Pessoa): any {
    if (aluno.nome === '' || aluno.nome === undefined) {
      return 'Digite o nome'
    }
    if (aluno.identidade === '' || aluno.identidade === undefined) {
      return 'Digite a identidade'
    }
    if (aluno.cpf === '' || aluno.cpf === undefined) {
      return 'Digite o CPF'
    }
    if (aluno.endereco === '' || aluno.endereco === undefined) {
      return 'Digite o endereço'
    }
    
    return null
  }
}
