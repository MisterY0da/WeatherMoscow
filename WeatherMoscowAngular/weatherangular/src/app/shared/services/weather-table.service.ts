import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { WeatherTableDTO } from "../../models/weather-table.type";

@Injectable({
    providedIn: 'root'
})

export class WeatherTableService {
    constructor(private http: HttpClient) {}

    getTable(): Observable<WeatherTableDTO[]> {
        return this.http.get<WeatherTableDTO[]>('api/weatherrecord');
    }
}