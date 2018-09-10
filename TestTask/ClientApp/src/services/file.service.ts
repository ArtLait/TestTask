import { Injectable, Inject } from '@angular/core';
import { FileModel } from '../models/fileModel';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class FileService {
  baseUrl: any;
  httpOptions: any = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  images: FileModel[] = [];

  uploadImg(file: FileModel) {   
    this.http.post<any>(this.baseUrl + 'api/file', file, this.httpOptions).subscribe(responce => {
      this.loadImages();
    }, error => console.error(error));
  }

  loadImages() {
    this.http.get<FileModel[]>(this.baseUrl + 'api/file').subscribe((resp: FileModel[]) => {
       this.images = resp;
    });
  }
}
