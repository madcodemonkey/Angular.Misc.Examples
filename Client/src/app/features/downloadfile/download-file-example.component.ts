import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { ToolService } from '../../_services/tool.service';

@Component({
  selector: 'app-download-file-example',
  templateUrl: './download-file-example.component.html',
  styleUrls: ['./download-file-example.component.css'],
})
export class DownloadFileExampleComponent implements OnInit {
  constructor(
    private toolService: ToolService,
    private toaster: ToastrService
  ) {}

  ngOnInit(): void {}

  downloadIt1(): void {
    this.toolService.downloadToolReportUseServerFileName(1000);
  }

  downloadIt2(): void {
    this.toolService
      .getToolReport(1000)
      .pipe(take(1))
      .subscribe({
        next: (resp) => {
          if (resp.body) {
            this.toolService.downloadFile(resp.body, 'MoreControlFile.zip');
            this.toaster.success('File downloaded.');
          } else {
            this.toaster.error(
              'No blob data returned for the file (see console output)'
            );
            console.log(resp);
          }
        },
        error: (e) => {
          this.toaster.error('Error (see console output)');
          console.log(e);
        },
      });
  }
}
