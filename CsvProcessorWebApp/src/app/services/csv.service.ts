import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { CsvProcessor } from '../Models/csv-processor';

@Injectable({
  providedIn: 'root'
})
export class CsvService {

  urlApi = "";

  constructor(
    private http: HttpClient) {
    this.urlApi = `${environment.apiUrl}/api`;
  }

  SendFile(file: File) : Observable<any> {
    const fileData = new FormData();
    fileData.append('file', file, file.name);
    return this.http.post<any>(
      `${this.urlApi}/Files`,
      fileData
    );
  }

  getFileDetails(page: number, take: number): Observable<CsvProcessor> {
    return this.http.get<CsvProcessor>(
      `${this.urlApi}/Files` + '/' + page + '/' + take
    );
  }
}
