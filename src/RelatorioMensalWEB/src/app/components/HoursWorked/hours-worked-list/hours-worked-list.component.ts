import { Component, OnInit } from '@angular/core';
import { HoursWorked } from 'src/app/models/HoursWorked';
import { HoursWorkedService } from 'src/app/services/hours-worked.service';

@Component({
    selector: 'app-hours-worked-list',
    templateUrl: './hours-worked-list.component.html',
    styleUrls: ['./hours-worked-list.component.css']
})
export class HoursWorkedListComponent implements OnInit {

    hoursWorkeds!: HoursWorked[];
    nameUser = "eridan.batista";
    month = "6";

    displayedColumns = ['data', 'horaEntrada', 'horaSaida', 'totalHoras', 'projeto', 'descricao'];

    constructor(private hoursWorkedService: HoursWorkedService) { }

    ngOnInit(): void {
        this.hoursWorkedService.getHoursMonthByUsuario(this.nameUser, this.month).subscribe(hoursWorkeds => {
            this.hoursWorkeds = hoursWorkeds;
        });
    }

}
