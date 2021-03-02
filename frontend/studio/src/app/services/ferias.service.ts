import { Ferias } from './../models/ferias.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EMPTY, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { DatePipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class FeriasService {

  baseUrl = '/api/';

  constructor(private snackBar: MatSnackBar, private http: HttpClient) { }

  exibirMensagem(msg: string, isError: boolean = false): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top",
      panelClass: isError ? ['msg-error'] : ['msg-sucess']
    });
  }

  criar(ferias: Ferias): Observable<string> {
    return this.http.post<string>(this.baseUrl + "InserirFerias", ferias).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  buscar(cpf: string): Observable<string> {
    return this.http.get<string>(this.baseUrl + "ConsultarFeriasPorIDPessoa?cpf=" + cpf).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  buscarPorId(id: number): Observable<string> {
    return this.http.get<string>(this.baseUrl + "ConsultarFeriasPorID?id=" + id).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  atualizar(ferias: Ferias): Observable<string> {
    return this.http.put<string>(this.baseUrl + "AtualizarFerias", ferias).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  deletar(id: number): Observable<string> {
    return this.http.delete<string>(this.baseUrl + "DeletarFerias?idFerias=" + id).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  errorHandler(e: any): Observable<any> {
    this.exibirMensagem("Ocorreu um erro", true)
    return EMPTY

  }

  validaFerias(ferias: Ferias): any {
    if (ferias.cpf === '' || ferias.cpf === undefined) {
      return 'Digite o CPF'
    }
    if (ferias.dataInicio === '' || ferias.dataInicio === undefined) {
      return 'Selecione a Data de Início'
    }
    if (ferias.dataFim === '' || ferias.dataFim === undefined) {
      return 'Selecione a Data de Fim'
    }

    const dataInicio = new Date(ferias.dataInicio)
    const dataFim = new Date(ferias.dataFim)
    const hoje = new Date()

    if (dataFim.getTime() <= dataInicio.getTime()) {
      return 'Período inválido, selecione a data fim maior do que a data início'
    }

    if (dataFim.getTime() < hoje.getTime()) {
      return 'Data Fim tem que ser maior do que a data atual'
    }
    if (dataInicio.getTime() < hoje.getTime()) {
      return 'Data Início tem que ser maior do que a data atual'
    }
    return null
  }
}
