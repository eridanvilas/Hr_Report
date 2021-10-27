import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EMPTY, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HoursWorked } from '../models/HoursWorked';
import { catchError, map } from 'rxjs/operators';
import { MatSnackBar } from "@angular/material/snack-bar";

@Injectable({
    providedIn: 'root'
})
export class HoursWorkedService {

    baseUrl = environment.apiUrl + "api/v1/hoursworked/";

    constructor(private http: HttpClient, private snackBar: MatSnackBar) { }


    showMessage(msg: string, isError: boolean = false): void {
        this.snackBar.open(msg, 'X', {
            duration: 3000,
            horizontalPosition: "right",
            verticalPosition: "top",
            panelClass: isError ? ['msg-error'] : ['msg-success']
        });
    }


    getHoursMonthByUsuario(nameUser: string, month: string): Observable<HoursWorked[]> {
        let params = new HttpParams().set('usuario', nameUser).set('month', month);

        return this.http.get<HoursWorked[]>(this.baseUrl + "GetHoursMonthByUsuario", { params: params }).pipe(
            map((obj) => obj),
            catchError(e => this.errorHandler(e))
        );
    }


    errorHandler(e: any): Observable<any> {
        console.log("Error:" + e)
        this.showMessage('Ocorreu um erro!', true)
        return EMPTY;
    }

}
