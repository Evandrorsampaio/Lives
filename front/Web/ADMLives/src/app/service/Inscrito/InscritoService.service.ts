import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Inscrito } from '../../model/Inscrito';

@Injectable({
  providedIn: 'root'
})
export class InscritoServiceService {

  baseURL = 'https://localhost:7009/api/Inscrito';
  constructor(private http: HttpClient) { }

  public getInscritos(): Observable<Inscrito[]>{
    return this.http.get<Inscrito[]>(this.baseURL);
  }

  public getInscritoById(id: number ): Observable<Inscrito>{
    return this.http.get<Inscrito>(`${this.baseURL}/${id}`);
  }

  public postInscrito(inscrito: Inscrito ): Observable<Inscrito>{
    return this.http.post<Inscrito>(this.baseURL, inscrito);
  }

  public putInscrito( inscrito: Inscrito): Observable<Inscrito[]>{
    return this.http.put<Inscrito[]>(`${this.baseURL}`, inscrito);
  }

  public deleteInscrito(id: number): Observable<any>{
    return this.http.delete<string>(`${this.baseURL}/${id}`);
  }

}
