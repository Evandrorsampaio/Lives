import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Inscricao } from '../../model/Inscricao';

@Injectable({
  providedIn: 'root'
})
export class InscricaoService {

  baseURL = 'https://localhost:7009/api/Inscricao';
  constructor(private http: HttpClient) { }

  public getAll(): Observable<Inscricao[]>{
    return this.http.get<Inscricao[]>(this.baseURL);
  }

  public getById(id: number ): Observable<Inscricao>{
    return this.http.get<Inscricao>(`${this.baseURL}/${id}`);
  }

  public post(inscricao: Inscricao ): Observable<Inscricao>{
    return this.http.post<Inscricao>(this.baseURL, inscricao);
  }

  public put( inscricao: Inscricao): Observable<Inscricao[]>{
    return this.http.put<Inscricao[]>(`${this.baseURL}`, inscricao);
  }

  public delete(id: number): Observable<any>{
    return this.http.delete<string>(`${this.baseURL}/${id}`);
  }

}
