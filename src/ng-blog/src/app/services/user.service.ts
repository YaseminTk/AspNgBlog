import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { API_URL } from '../../token';
import { firstValueFrom, Observable, pipe, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  public readonly http: HttpClient;
  private readonly apiUrl: string;

  constructor() {
    this.http = inject(HttpClient);
    this.apiUrl = `${inject(API_URL)}/user`;
  }

  public getCurrent(): Observable<any> {
    const params = new HttpParams().set('current', 'true');

    return this.http.get(`${this.apiUrl}`, {
      params: params,
      withCredentials: true
    });
  }

  public async getCurrentAsync(): Promise<any> {
    return await firstValueFrom(this.getCurrent());
  }

  public update(user: any): Observable<any> {
    return this.http.put(`${this.apiUrl}`, user)
  }

  public async updateAsync(user: any): Promise<any> {
    return await firstValueFrom(this.update(user));
  }

  private _currentUser?: any;
  public get currentUser(): any | undefined {
    return this._currentUser;
  }
}