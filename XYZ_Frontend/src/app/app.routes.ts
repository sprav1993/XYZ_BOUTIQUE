import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { MenuComponent } from './components/menu/menu.component';
import { UsuarioComponent } from './components/usuario/usuario.component';
import { ProductoComponent } from './components/producto/producto.component';

export const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'login' }, // Ruta por defecto redirige a '/login'
  { path: 'login', component: LoginComponent },
  { path: 'menu', component: MenuComponent, children: [
    { path: 'usuario', component: UsuarioComponent },
    { path: 'producto', component: ProductoComponent },
  ] },
  { path: '**', redirectTo: '/login' } // Manejo de rutas desconocidas


];
