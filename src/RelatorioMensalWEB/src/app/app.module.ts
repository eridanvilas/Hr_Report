import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './components/template/header/header.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FooterComponent } from './components/template/footer/footer.component';
import { NavComponent } from './components/template/nav/nav.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatTableModule } from "@angular/material/table";

import { MatFormFieldModule } from '@angular/material/form-field';
import { HomeComponent } from './views/home/home.component';
import { RelatorioComponent } from './views/relatorio/relatorio.component';
import { FileToUpdateComponent } from './views/file-to-update/file-to-update.component';
import { LoadingComponent } from './components/loading/loading.component';
import { HoursWorkedListComponent } from './components/HoursWorked/hours-worked-list/hours-worked-list.component';


// import from '@angular/material/grid-list';

@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        FooterComponent,
        NavComponent,
        HomeComponent,
        RelatorioComponent,
        FileToUpdateComponent,
        LoadingComponent,
        HoursWorkedListComponent,

    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        MatToolbarModule,
        MatProgressSpinnerModule,
        MatSnackBarModule,
        MatSidenavModule,
        MatListModule,
        MatCardModule,
        MatTableModule,
        HttpClientModule,
        MatFormFieldModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
