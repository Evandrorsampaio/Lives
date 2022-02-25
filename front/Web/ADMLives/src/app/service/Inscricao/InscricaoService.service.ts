import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Inscricao } from '../../model/Inscricao';

@Injectable({
  providedIn: 'root'
})
export class InscricaoServiceService {

  baseURL = 'https://localhost:7009/api/Inscricao';
  constructor(private http: HttpClient) { }

  public getInscricaos(): Observable<Inscricao[]>{
    return this.http.get<Inscricao[]>(this.baseURL);
  }

  public getInscricaoById(id: number ): Observable<Inscricao>{
    return this.http.get<Inscricao>(`${this.baseURL}/${id}`);
  }

  public postInscricao(inscricao: Inscricao ): Observable<Inscricao>{
    return this.http.post<Inscricao>(this.baseURL, inscricao);
  }

  public putInscricao( inscricao: Inscricao): Observable<Inscricao[]>{
    return this.http.put<Inscricao[]>(`${this.baseURL}`, inscricao);
  }

  public deleteInscricao(id: number): Observable<any>{
    return this.http.delete<string>(`${this.baseURL}/${id}`);
  }

}
