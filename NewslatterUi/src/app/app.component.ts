import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `

<nav class="navbar navbar-expand-lg bg-body-tertiary ">
  <div class="container-fluid">
    <a class="navbar-brand" routerLink="/">Newslatter</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" routerLink="/">Ana Sayfa</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" routerLink="/newslatter" >Haberler</a>
        </li>

        <li class="nav-item">
          <a class="nav-link disabled">Disabled</a>
        </li>
      </ul>
      <form class="d-flex" role="search">

        <button class="btn btn-outline-success" routerLink="/login" *ngIf="!isAuth" type="submit">Login</button>
        <span class="alert alert-success mx-2"  *ngIf="isAuth,isSeen"  >Hoşgeldiniz Kadir Gültekin</span>
        <span class="alert alert-warning mx-2"  *ngIf="isAuth" style="cursor: pointer;">Çıkış Yap</span>
      </form>
    </div>
  </div>
</nav>

  <router-outlet></router-outlet>

  `,

})
export class AppComponent {
  isAuth=false;
  isSeen=true;
}
