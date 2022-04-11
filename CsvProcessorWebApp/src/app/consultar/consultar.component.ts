import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { CsvFileDetails } from '../Models/csv-file-details';
import { CsvProcessor } from '../Models/csv-processor';
import { CsvService } from '../services/csv.service';

@Component({
  selector: 'app-consultar',
  templateUrl: './consultar.component.html',
  styleUrls: ['./consultar.component.css']
})
export class ConsultarComponent implements OnInit, AfterViewInit  {

  displayedColumns: string[] = [
    'identification',
    'firstNasme',
    'lastName',
    'direction',
    'neighborhood',
    'phoneNumber',
    'gender',
    'age',
    'profession'
  ];

  csvProcessor!: CsvProcessor;
  fileDetails: CsvFileDetails[] = [];
  dataSource = new MatTableDataSource<CsvFileDetails>([]);
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  totalRecords: number = 0;
  recordsForPage:number = 10;
  pageCombo: number[] = [10, 25, 50];
  actualPage:number = 1;

  constructor(protected csvService: CsvService) { }

  ngOnInit(): void {
    this.GetFileDetails(this.actualPage, this.recordsForPage);
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  GetFileDetails(actualPage:number, recordsForPage:number): void {
    this.csvService
    .getFileDetails(actualPage, recordsForPage)
    .subscribe(
      (res): void => {
        if (res.items.length > 0) {
          this.dataSource = new MatTableDataSource<CsvFileDetails>(res.items);
          this.totalRecords = res.total;
        }
      },
      function (err): void { console.error("Error: " + err); });
  }

  eventPaginator(event: PageEvent): void {
    debugger;
    this.recordsForPage = event.pageSize;
    this.actualPage = event.pageIndex + 1;
    this.GetFileDetails(this.actualPage, this.recordsForPage);
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
