import { ApiException } from "./apiexception";
import { Weather } from "./weather";

export interface WeatherResponse {
    isSuccessResponse: boolean,
    data: Weather,
    exception: ApiException
  }