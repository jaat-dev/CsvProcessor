import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SeguridadService } from '../services/seguridad.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(
    public seguridadService: SeguridadService,
    private router: Router) { }
  isAdmin:boolean=false;
  isLoged:boolean=false;

  ngOnInit(): void {
    this.validateRol();
  }

  validateRol() {
    if (this.seguridadService.getRol() === "admin") {
      this.isAdmin = true;
    } else {
      if (this.seguridadService.isLoged()) {
        this.isLoged = true;
      }
    }
  }

  logout() {
    this.seguridadService.logout();
    this.router.navigate(['']);
  }

}
