import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { ToolService } from '../../_services/tool.service';

@Component({
  selector: 'app-download-file-example',
  templateUrl: './download-file-example.component.html',
  styleUrls: ['./download-file-example.component.css'],
})
export class DownloadFileExampleComponent implements OnInit {
  constructor(private toolService: ToolService) {}

  ngOnInit(): void {}

  downloadIt1(): void {
    this.toolService.downloadToolReport(1000);
  }

  downloadIt2(): void {
    this.toolService.getToolReport(1000).pipe(take(1)).subscribe(resp => {
        if (resp.body)
        {
          this.toolService.downloadFile(resp.body, 'MoreControlFile.zip')
        } else {
          console.log("response is null or undefined!")
        }
    });
  }
}
