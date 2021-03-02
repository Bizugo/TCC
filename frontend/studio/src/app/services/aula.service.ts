import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EMPTY, Observable } from 'rxjs';
import { Aula } from '../models/aula.model';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AulaService {
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

  criar(aula: Aula): Observable<string> {
    return this.http.post<string>(this.baseUrl + "InserirAula", aula).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  buscar(nome: string): Observable<string> {
    return this.http.get<string>(this.baseUrl + "ConsultarAulaPorNome?nome=" + nome).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  atualizar(aula: Aula): Observable<string> {
    return this.http.put<string>(this.baseUrl + "AtualizarAula", aula).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  deletar(nome: string): Observable<string> {
    return this.http.delete<string>(this.baseUrl + "DeletarAula?nome=" + nome).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  errorHandler(e: any): Observable<any> {
    this.exibirMensagem("Ocorreu um erro", true)
    return EMPTY

  }

  validaAula(aula: Aula): any {
    if (aula.nome === '' || aula.nome === undefined) {
      return 'Digite o nome da aula'
    }
    if (aula.nome_instrutor === '' || aula.nome_instrutor === undefined) {
      return 'Digite o nome do instrutor'
    }
    if (aula.horario_inicio === '' || aula.horario_inicio === undefined) {
      return 'Digite o horário do início da aula'
    }
    if (aula.horario_fim === '' || aula.horario_fim === undefined) {
      return 'Digite o horário do fim da aula'
    }
    if (aula.sala === '' || aula.sala === undefined) {
      return 'Digite a sala'
    }
    if (aula.dias_semana === '' || aula.dias_semana === undefined) {
      return 'Selecione os dias da semana'
    }

    return null
  }
}
