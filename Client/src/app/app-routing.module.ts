import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { DownloadFileExampleComponent } from './features/downloadfile/download-file-example.component';

const routes: Routes = [
   { path: '', component: DownloadFileExampleComponent},
   { path: 'download', component: DownloadFileExampleComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
