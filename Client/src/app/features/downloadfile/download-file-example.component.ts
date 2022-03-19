import { Component, OnInit } from '@angular/core';
import { ToolService } from './tool.service';

@Component({
  selector: 'app-download-file-example',
  templateUrl: './download-file-example.component.html',
  styleUrls: ['./download-file-example.component.css']
})
export class DownloadFileExampleComponent implements OnInit {

  constructor(private toolService: ToolService) { }

  ngOnInit(): void {
  }

  downloadIt() : void{
      this.toolService.downloadToolReport(1000);
  }

}
