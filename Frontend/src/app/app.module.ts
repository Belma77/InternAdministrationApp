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
import { ApplicationsComponent } from './applications/applications.component';
import { ApplicationstableComponent } from './applications/applicationstable/applicationstable.component';
import { SelectionComponent } from './selection/selection.component';
import { SelectionstableComponent } from './selection/selectionstable/selectionstable.component';
import { EditorsComponent } from './editors/editors.component';
import { EditorsformComponent } from './editors/editorsform/editorsform.component';
import { ApplicantComponent } from './applications/applicationstable/applicant/applicant.component';
import { SelectioninformationComponent } from './selection/selectionstable/selectioninformation/selectioninformation.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgxPaginationModule } from 'ngx-pagination';
import { PaginationModule } from 'ngx-bootstrap/pagination'
import { FormsModule } from '@angular/forms';
import { TokenService } from './services/token.service';
import { MatDialogModule } from '@angular/material/dialog';
import { AddselectionComponent } from './selection/selectionstable/addselection/addselection.component';

const appRoutes: Routes = [
  { path: '', component: ApplyforinternshipComponent },
  { path: 'applyjap', component: ApplyformComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'login', component: LoginComponent },
  { path: 'applications', component: ApplicationsComponent },
  { path: 'selections', component: SelectionComponent },
  { path: 'editors', component: EditorsComponent },
  { path: 'applicant', component: ApplicantComponent },
  { path: 'selection', component: SelectioninformationComponent },
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
    LoginformComponent,
    ApplicationsComponent,
    ApplicationstableComponent,
    SelectionComponent,
    SelectionstableComponent,
    EditorsComponent,
    EditorsformComponent,
    ApplicantComponent,
    SelectioninformationComponent,
    AddselectionComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    NgxPaginationModule,
    PaginationModule.forRoot(),
    FormsModule,
    MatDialogModule
  ],
  exports: [
    PaginationModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: TokenService, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
