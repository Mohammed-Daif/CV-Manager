import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export abstract class ApiService {
  private baseURL = 'https://localhost:5001/api/';
  abstract prefix: string;
  constructor(protected http: HttpClient) {}

  getPagination<T>(
    index: number,
    size: number,
    prefix: string = this.prefix
  ): Observable<any> {
    return this.http.get<T>(`${this.baseURL}${prefix}/${index}/${size}`);
  }
  getGetById<T>(id: any, prefix: string = this.prefix): Observable<T> {
    return this.http.get<T>(`${this.baseURL}${prefix}/${id}`);
  }
  post(
    data: any,
    options: { headers?: HttpHeaders } = {},
    prefix: string = this.prefix
  ): Observable<any> {
    console.log('post', prefix, data);
    return this.http.post<any>(`${this.baseURL}${prefix}`, data, options);
  }

  Put(data: any, id: any, prefix: string = this.prefix): Observable<any> {
    return this.http.put<any>(`${this.baseURL}${prefix}/${id}`, data);
  }
  delete(id: any, prefix: string = this.prefix): Observable<any> {
    return this.http.delete<any>(`${this.baseURL}${prefix}/${id}`);
  }
}
