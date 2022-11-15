import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ApplyforinternshipComponent } from './applyforinternship/applyforinternship.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SectionComponent } from './applyforinternship/section/section.component';
import { ApplyformComponent } from './applyforinternship/applyform/applyform.component';
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
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TokenService } from './services/token.service';
import { MatDialogModule } from '@angular/material/dialog';
import { AddselectionComponent } from './selection/selectionstable/addselection/addselection.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { EditselectionComponent } from './selection/selectionstable/selectioninformation/editselection/editselection.component';
import { EditorsmodalComponent } from './editors/editorsmodal/editorsmodal.component';
import { MatSnackBarModule, MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material/snack-bar';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidebarComponent,
    ApplyforinternshipComponent,
    SectionComponent,
    ApplyformComponent,
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
    EditselectionComponent,
    EditorsmodalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    NgxPaginationModule,
    PaginationModule.forRoot(),
    FormsModule,
    MatDialogModule,
    MatDatepickerModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatSnackBarModule,
  ],
  exports: [
    PaginationModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: TokenService, multi: true },
  { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 3000 } }],

  bootstrap: [AppComponent]
})
export class AppModule { }
