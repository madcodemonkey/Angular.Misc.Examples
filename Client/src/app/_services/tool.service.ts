import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { take } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ToolService {
  baseUrl = environment.apiUri;

  constructor(private http: HttpClient) { }

  /**
   * The component that uses this doesn't want any control over how the file is downloaded.
   * @param numberToCreate  Number of items to create in the CSV file inside the zip file you will download.
   */
  downloadToolReport(numberToCreate: number) {

    this.http.get(`${this.baseUrl}/ToolReport/${numberToCreate}`, {observe: 'response', responseType: 'blob' })
         .pipe(take(1))
        .subscribe(resp => {

          // Note that the server has to allow access to the content-disposition headers (see ToolReportController.cs where it exposes the headers.)
          var contentDisposition = resp.headers.get('content-disposition');
          var filename = contentDisposition !== null ? contentDisposition.split(';')[1].split('filename')[1].split('=')[1].trim() : 'unknown.zip';
          console.log(filename);

          if (resp.body !== null) this.downloadFile(resp.body, filename)
        });
  }

  getToolReport(numberToCreate: number): Observable<HttpResponse<Blob>> {
    return this.http.get(`${this.baseUrl}/ToolReport/${numberToCreate}`, {observe: 'response', responseType: 'blob' });
  }

  downloadFile(data: Blob, filename: string) {
    const blob = new Blob([data], { type: 'application/zip' });
    const url= window.URL.createObjectURL(blob);
    var anchor = document.createElement("a");
    anchor.download = filename;
    anchor.href = url;
    anchor.click();
    //window.open(url);
  }
}
