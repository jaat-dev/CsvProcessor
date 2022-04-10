import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { CsvService } from '../services/csv.service';

@Component({
  selector: 'app-csv-file',
  templateUrl: './csv-file.component.html',
  styleUrls: ['./csv-file.component.css']
})
export class CsvFileComponent implements OnInit {

  selectedFile!: File;
  @ViewChild('fileUpload', { static: false })
  fileUpload!: ElementRef;

  constructor(protected csvService: CsvService) { }

  ngOnInit(): void {
  }

  onFileSelected(event: any): void {
    this.selectedFile = <File>event.target.files[0];
    this.fileUpload.nativeElement.value = null;
  }

  onUpLoad() {
    this.csvService.SendFile(this.selectedFile).subscribe(
      res => {
        var result = res;
      },
      err => {
        console.error("Se presento el siguiente error: " + err);
      }
    );
  }

}
