import { ForecastTemperature } from "./forecasttemperature";
import { ShiftsTemperature } from "./shiftstemperature";

export interface Forecast {
    date: string;
    forecasttemp: ForecastTemperature;
    feelslike: ShiftsTemperature;
    desc: string;
} 
