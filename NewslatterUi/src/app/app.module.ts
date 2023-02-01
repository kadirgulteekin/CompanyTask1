import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { LoginComponent } from './component/login/login.component';
import { CheckInputValidDirective } from './directives/check-input-valid.directive';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CheckInputValidDirective
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot([
      {
        path:"login",
        component:LoginComponent
      }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
