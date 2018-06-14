import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http'
import { Employee } from "../entities/Employee";
@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    constructor(private _httpService: Http) { }
    apiValues: Employee[] = [];
    ngOnInit() {
        this._httpService.get('/api/Employee/getAllEmployee').subscribe(values => {
            console.log(values.json());
            this.apiValues = values.json() as Employee[];
        });
    }
}