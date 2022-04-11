import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DownloadFileExampleComponent } from './features/downloadfile/download-file-example.component';
import { HomeComponent } from './features/home/home.component';
import { FormsValidationSimple1Component } from './features/validation/forms-validation-simple1/forms-validation-simple1.component';
import { PreventUnsavedChangesFormExampleGuard } from './_guards/prevent-unsaved-changes-form-example.guard';
import { StateListResolver } from './_resolvers/state-list.resolver';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'download', component: DownloadFileExampleComponent },
  {
    path: 'validation',
    children: [
      { path: 'forms/simple1/:id', component: FormsValidationSimple1Component,
        resolve: {states: StateListResolver},
        canDeactivate: [PreventUnsavedChangesFormExampleGuard]
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
