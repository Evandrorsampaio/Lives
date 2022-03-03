import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Instrutor } from '../../model/Instrutor';

@Injectable({
  providedIn: 'root'
})
export class InstrutorService {

  baseURL = 'https://localhost:7009/api/Instrutor';
  constructor(private http: HttpClient) { }

  public getAll(): Observable<Instrutor[]>{
    return this.http.get<Instrutor[]>(this.baseURL);
  }

  public getById(id: number ): Observable<Instrutor>{
    return this.http.get<Instrutor>(`${this.baseURL}/${id}`);
  }

  public post(instrutor: Instrutor ): Observable<Instrutor>{
    return this.http.post<Instrutor>(this.baseURL, instrutor);
  }

  public put( instrutor: Instrutor): Observable<Instrutor[]>{
    return this.http.put<Instrutor[]>(`${this.baseURL}`, instrutor);
  }

  public delete(id: number): Observable<any>{
    return this.http.delete<string>(`${this.baseURL}/${id}`);
  }

}
