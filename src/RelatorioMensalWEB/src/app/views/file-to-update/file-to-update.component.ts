import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-file-to-update',
  templateUrl: './file-to-update.component.html',
  styleUrls: ['./file-to-update.component.css']
})
export class FileToUpdateComponent implements OnInit {

  loading = false;
  fileToUpload: File | undefined;
  fileName?= '';
  @ViewChild('file') file!: ElementRef;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {

  }

  fileupload = (files: any) => {
    if (files.length === 0)
      return;

    this.fileToUpload = <File>files[0];
    this.fileName = this.fileToUpload?.name;
    const request = new FormData();
    request.append('FormFile', this.fileToUpload, this.fileToUpload.name);


    this.http.post(`${environment.apiUrl}/api/v1/file/Upload`, request, { reportProgress: true, observe: 'events' })
      .subscribe(event => {

        if (event.type === HttpEventType.Response) {
          this.file.nativeElement.value = "";
          this.fileName = '';
          console.log("Arquivo importado com sucesso!.");
        }
      }, err => {
        this.file.nativeElement.value = "";
        this.fileName = '';
        console.log(err.error);
      });
  }
}
