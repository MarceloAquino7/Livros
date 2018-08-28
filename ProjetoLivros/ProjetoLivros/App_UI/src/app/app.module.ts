import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { AppComponent } from './app.component';
import { ApiService } from './api/api.service';


@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule
    ],
    providers: [
        ApiService,
        HttpModule
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }