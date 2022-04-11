import { CsvFile } from "./csv-file";

export interface CsvFileDetails {
  id: string;
  identification: string;
  firstNasme: string;
  lastName: string;
  direction: string;
  neighborhood: string;
  phoneNumber: string;
  gender: string;
  age: string;
  profession: string;
  fileModel: CsvFile;
}
