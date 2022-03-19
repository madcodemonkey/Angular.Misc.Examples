import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ToolService {
  baseUrl = environment.apiUri;

  constructor(private http: HttpClient) { }

  downloadToolReport(numberToCreate: number) {

    return this.http.get(`${this.baseUrl}/ToolReport/${numberToCreate}`, {observe: 'response', responseType: 'blob' })
         .pipe(take(1))
        .subscribe(resp => {

          var contentDisposition = resp.headers.get('content-disposition');
          var filename = contentDisposition !== null ? contentDisposition.split(';')[1].split('filename')[1].split('=')[1].trim() : 'unknown.zip';
          console.log(filename);

          if (resp.body !== null) this.downloadFile(resp.body, filename)
        });
  }

  private downloadFile(data: Blob, filename: string) {
    const blob = new Blob([data], { type: 'application/zip' });
    const url= window.URL.createObjectURL(blob);
    var anchor = document.createElement("a");
    anchor.download = filename;
    anchor.href = url;
    anchor.click();
    //window.open(url);
  }
}
