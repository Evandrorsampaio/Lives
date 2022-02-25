import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Live } from '../../model/Live';

@Injectable({
  providedIn: 'root'
})
export class LiveServiceService {

  baseURL = 'https://localhost:7009/api/Live';
  constructor(private http: HttpClient) { }

  public getLives(): Observable<Live[]>{
    return this.http.get<Live[]>(this.baseURL);
  }

  public getLiveById(id: number ): Observable<Live>{
    return this.http.get<Live>(`${this.baseURL}/${id}`);
  }

  public postLive(live: Live ): Observable<Live>{
    return this.http.post<Live>(this.baseURL, live);
  }

  public putLive( live: Live): Observable<Live[]>{
    return this.http.put<Live[]>(`${this.baseURL}`, live);
  }

  public deleteLive(id: number): Observable<any>{
    return this.http.delete<string>(`${this.baseURL}/${id}`);
  }


}
