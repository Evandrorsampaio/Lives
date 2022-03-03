import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Live } from '../../model/Live';

@Injectable({
  providedIn: 'root'
})
export class LiveService {

  baseURL = 'https://localhost:7009/api/Live';
  constructor(private http: HttpClient) { }

  public getAll(): Observable<Live[]>{
    return this.http.get<Live[]>(this.baseURL);
  }

  public getById(id: number ): Observable<Live>{
    return this.http.get<Live>(`${this.baseURL}/${id}`);
  }

  public post(live: Live ): Observable<Live>{
    return this.http.post<Live>(this.baseURL, live);
  }

  public put( live: Live): Observable<Live[]>{
    return this.http.put<Live[]>(`${this.baseURL}`, live);
  }

  public delete(id: number): Observable<any>{
    return this.http.delete<string>(`${this.baseURL}/${id}`);
  }


}
