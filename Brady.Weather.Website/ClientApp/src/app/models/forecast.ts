import { ForecastTemperature } from "./foreCasttemperature";
import { ShiftsTemperature } from "./shiftstemperature";

export interface Forecast {
    date: string;
    forecasttemp: ForecastTemperature;
    feelslike: ShiftsTemperature;
    desc: string;
} 