import { Injectable, Inject, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { API_URL } from '../../token';
import { firstValueFrom, map, Observable, Observer, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public readonly http: HttpClient;
  private readonly apiUrl: string;

  constructor() {
    this.http = inject(HttpClient);
    this.apiUrl = `${inject(API_URL)}/auth`;
  }

  public login(loginInfo: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/in`, loginInfo).pipe(
      tap({
        next: res => this._isLogedIn = true,
        error: err => this._isLogedIn = false
      })
    );
  }

  public async loginAsync(loginInfo: any): Promise<any> {
    return await firstValueFrom(this.login(loginInfo));
  }

  public logout(): Observable<any> {
    return this.http.post(`${this.apiUrl}/out`, {}).pipe(
      tap({
        next: res => this._isLogedIn = false,
        error: err => this._isLogedIn = true
      })
    );
  }

  public async logoutAsync(): Promise<any> {
    return await firstValueFrom(this.logout());
  }

  public check(): Observable<boolean> {
    return this.http.get<boolean>(`${this.apiUrl}/check`).pipe(
      map((res: boolean) => {
        this._isLogedIn = res;
        return res;
      }),
      tap({
        error: err => this._isLogedIn = false
      })
    );
  }

  public checkAsync(): Promise<boolean> {
    return firstValueFrom(this.check())
  }

  private _isLogedIn = false;
  get isLogedIn() {
    return this._isLogedIn;
  }
}