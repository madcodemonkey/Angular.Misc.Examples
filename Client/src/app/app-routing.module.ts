import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DownloadFileExampleComponent } from './features/downloadfile/download-file-example.component';
import { HomeComponent } from './features/home/home.component';

const routes: Routes = [
   { path: '', component: HomeComponent},
   { path: 'download', component: DownloadFileExampleComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
