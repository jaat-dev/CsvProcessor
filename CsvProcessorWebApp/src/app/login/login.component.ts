import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from '../Models/login';
import { SeguridadService } from '../services/seguridad.service';
import { parsearErroresAPI } from '../utils/utilities';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private formBuilder: FormBuilder,
    private seguridadService: SeguridadService,
    private router: Router) { }

  form: FormGroup = new FormGroup({});
  errores: string[] = [];

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      email: ['', { validators: [Validators.required, Validators.email] } ],
      password: ['', { validators: [Validators.required] } ]
    });
  }

  onSubmit(){
    console.log(this.form.value)
    var login:Login = this.form.value;
    this.seguridadService.login(login)
    .subscribe(
      respuesta => {
        this.seguridadService.guardarToken(respuesta);
        if (this.seguridadService.getRol() === "admin") {
          this.router.navigate(['cargar-archivo']);
        } else {
          if (this.seguridadService.isLoged()) {
            this.router.navigate(['consultar']);
          }
        }
      },
      errores => this.errores = parsearErroresAPI(errores));
  }

  getErrorMessageEmail(): string {
    var messaje: string = ""
    var campo = this.form.get('email');
    if (campo!.hasError('required')){
      messaje = 'El campo Email es requerido';
    }
    if (campo!.hasError('email')){
      messaje = 'El email no es válido';
    }
    return messaje;
  }

}
