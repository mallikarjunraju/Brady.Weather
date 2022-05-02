import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WeatherResponse } from "../models/weatherresponse";
import { HttpClient } from '@angular/common/http';
import { ForecastResponse } from "../models/forecastresponse";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  weatherinfo: WeatherResponse;
  forecastinfo: ForecastResponse;
  iscityinputgiven: boolean;
  constructor(private route: ActivatedRoute, private http: HttpClient) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.iscityinputgiven = this.isEmpty(params.searchTerm);
      //if (!this.isEmpty(params.searchTerm))
      this.http.get<WeatherResponse>("http://20.195.92.172:8080/Weather/City/" + params.searchTerm).subscribe(result => {
        this.weatherinfo = result;
      }, error => console.error(error));
    });
    this.route.params.subscribe(params => {
      //if (!this.isEmpty(params.searchTerm))
      this.http.get<ForecastResponse>("http://20.195.92.172:8080/Forecast/City/" + params.searchTerm).subscribe(result => {
        this.forecastinfo = result;
      }, error => console.error(error));

    });
  }

  isEmpty(val: any) {
    return (val === undefined || val == null || val.length <= 0) ? true : false;
  }

  expand(data: any): string[] {
    let stringArr = [];
    for (const prop in data) {
      data[prop] instanceof Object
        ? (stringArr = stringArr.concat([`${prop}: `]).concat(this.expand(data[prop])))
        : stringArr.push(`${prop}: ${data[prop]}`);
    }
    return stringArr;
  }

}
