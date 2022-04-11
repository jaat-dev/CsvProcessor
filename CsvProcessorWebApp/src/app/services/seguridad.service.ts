import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthResponse } from '../Models/auth-response';
import { Login } from '../Models/login';

@Injectable({
  providedIn: 'root'
})
export class SeguridadService {

  urlApi = "";

  constructor(private httpClient: HttpClient) {
    this.urlApi = `${environment.apiUrl}/api/`+'account';
  }

  private readonly llaveToken = 'token';
  private readonly llaveExpiracion = 'token-expiracion';
  private readonly campoRol = 'role';

  isLoged(): boolean{
    const token = localStorage.getItem(this.llaveToken);
    if (!token){
      return false;
    }

    const expiracion = localStorage.getItem(this.llaveExpiracion);
    const expiracionFecha = new Date(expiracion!);

    if (expiracionFecha <= new Date()){
      this.logout();
      return false;
    }

    return true;
  }

  login(login: Login): Observable<AuthResponse>{
    return this.httpClient.post<AuthResponse>(this.urlApi + '/login', login);
  }

  logout(){
    localStorage.removeItem(this.llaveToken);
    localStorage.removeItem(this.llaveExpiracion);
  }

  getRol(): string {
    return this.obtenerCampoJWT(this.campoRol);
  }

  obtenerCampoJWT(campo: string): string{
    const token = localStorage.getItem(this.llaveToken);
    if (!token){return '';}
    var dataToken = JSON.parse(atob(token.split('.')[1]));
    return dataToken[campo];
  }

  guardarToken(auth: AuthResponse){
    localStorage.setItem(this.llaveToken, auth.token);
    localStorage.setItem(this.llaveExpiracion, auth.expiracion.toString());
  }

  obtenerToken(){
    return localStorage.getItem(this.llaveToken);
  }

}
