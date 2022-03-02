import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Inscrito } from '../../model/Inscrito';

@Injectable({
  providedIn: 'root'
})
export class InscritoService {

  baseURL = 'https://localhost:7009/api/Inscrito';
  constructor(private http: HttpClient) { }

  public getAll(): Observable<Inscrito[]>{
    return this.http.get<Inscrito[]>(this.baseURL);
  }

  public getById(id: number ): Observable<Inscrito>{
    return this.http.get<Inscrito>(`${this.baseURL}/${id}`);
  }

  public post(inscrito: Inscrito ): Observable<Inscrito>{
    return this.http.post<Inscrito>(this.baseURL, inscrito);
  }

  public put( inscrito: Inscrito): Observable<Inscrito[]>{
    return this.http.put<Inscrito[]>(`${this.baseURL}`, inscrito);
  }

  public delete(id: number): Observable<any>{
    return this.http.delete<string>(`${this.baseURL}/${id}`);
  }

}
