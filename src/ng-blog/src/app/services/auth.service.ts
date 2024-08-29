import { Injectable, Inject, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { API_URL } from '../../token';
import { firstValueFrom, Observable, Observer } from 'rxjs';

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
    return this.http.post(`${this.apiUrl}/in`, loginInfo);
  }

  public async loginAsync(loginInfo: any): Promise<any> {
    return await firstValueFrom(this.login(loginInfo));
  }
}