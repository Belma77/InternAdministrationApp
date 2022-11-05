import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ApplyforinternshipComponent } from './applyforinternship/applyforinternship.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JapnavbarComponent } from './applyforinternship/japnavbar/japnavbar.component';
import { SectionComponent } from './applyforinternship/section/section.component';
import { ApplyformComponent } from './applyforinternship/applyform/applyform.component';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { LoginformComponent } from './login/loginform/loginform.component';

const appRoutes: Routes = [
  { path: '', component: ApplyforinternshipComponent },
  { path: 'applyjap', component: ApplyformComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'login', component: LoginComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidebarComponent,
    ApplyforinternshipComponent,
    JapnavbarComponent,
    SectionComponent,
    ApplyformComponent,
    DashboardComponent,
    LoginComponent,
    LoginformComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
