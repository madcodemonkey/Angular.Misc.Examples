import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DownloadFileExampleComponent } from './features/downloadfile/download-file-example.component';
import { HomeComponent } from './features/home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TemplateFormsValidationSimple1Component } from './features/validation/template-forms-validation-simple1/template-forms-validation-simple1.component';
import { ToastrModule } from 'ngx-toastr';
import { ReactiveFormsValidationSimple1Component } from './features/validation/reactive-forms-validation-simple1/reactive-forms-validation-simple1.component';

@NgModule({
  declarations: [
    AppComponent,
    DownloadFileExampleComponent,
    HomeComponent,
    TemplateFormsValidationSimple1Component,
    ReactiveFormsValidationSimple1Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
