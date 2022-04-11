import { CsvFileDetails } from "./csv-file-details";

export interface CsvProcessor {
  items: CsvFileDetails[];
  total: number;
  page: number;
  pages: number;

}
