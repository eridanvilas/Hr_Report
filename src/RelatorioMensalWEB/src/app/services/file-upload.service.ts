import { HttpClient } from '@angular/common/http';
import { ElementRef, Injectable, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class FileUploadService {

    fileToUpload: File | undefined;
    fileName?= '';
    @ViewChild('file') file!: ElementRef;

    baseUrl = environment.apiUrl;

    constructor(private snackBar: MatSnackBar,
        private http: HttpClient) { }

    showMessage(msg: string): void {
        this.snackBar.open(msg, "X", {
            duration: 3000,
            horizontalPosition: "center",
            verticalPosition: "top"
        });
    }

    fileupload(request: FormData): Observable<FormData> {
        return this.http.post<FormData>(this.baseUrl + "/api/v1/file/Upload", request);
    }
}
