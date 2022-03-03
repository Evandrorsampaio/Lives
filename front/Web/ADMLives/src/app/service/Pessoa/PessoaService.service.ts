import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pessoa } from '../../model/Pessoa';

@Injectable({
  providedIn: 'root'
})
export class PessoaServiceService {

  baseURL = 'https://localhost:7009/api/Pessoa';
  constructor(private http: HttpClient) { }

  public getPessoas(): Observable<Pessoa[]>{
    return this.http.get<Pessoa[]>(this.baseURL);
  }

  public getPessoaById(id: number ): Observable<Pessoa>{
    return this.http.get<Pessoa>(`${this.baseURL}/${id}`);
  }

  public postPessoa(pessoa: Pessoa ): Observable<Pessoa>{
    return this.http.post<Pessoa>(this.baseURL, pessoa);
  }

  public putPessoa(pessoa: Pessoa): Observable<Pessoa[]>{
    return this.http.put<Pessoa[]>(`${this.baseURL}`, pessoa);
  }

  public deletePessoa(id: number): Observable<any>{
    return this.http.delete<string>(`${this.baseURL}/${id}`);
  }

}
