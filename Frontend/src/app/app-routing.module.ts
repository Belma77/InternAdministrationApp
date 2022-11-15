import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApplicantComponent } from './applications/applicationstable/applicant/applicant.component';
import { ApplicationstableComponent } from './applications/applicationstable/applicationstable.component';
import { ApplyforinternshipComponent } from './applyforinternship/applyforinternship.component';
import { ApplyformComponent } from './applyforinternship/applyform/applyform.component';
import { EditorsComponent } from './editors/editors.component';
import { LoginComponent } from './login/login.component';
import { SelectionComponent } from './selection/selection.component';
import { SelectioninformationComponent } from './selection/selectionstable/selectioninformation/selectioninformation.component';
import { AuthguardGuard } from './services/authguard.guard';
import { EditorguardGuard } from './services/editorguard.guard';

const appRoutes: Routes = [
  { path: '', component: ApplyforinternshipComponent },
  { path: 'applyjap', component: ApplyformComponent },
  { path: 'login', component: LoginComponent },
  { path: 'applications', component: ApplicationstableComponent, canActivate: [AuthguardGuard] },
  { path: 'applications/:id', component: ApplicantComponent, canActivate: [AuthguardGuard] },
  { path: 'selections', component: SelectionComponent, canActivate: [AuthguardGuard] },
  { path: 'selections/:id', component: SelectioninformationComponent, canActivate: [AuthguardGuard] },
  { path: 'editors', component: EditorsComponent, canActivate: [EditorguardGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
