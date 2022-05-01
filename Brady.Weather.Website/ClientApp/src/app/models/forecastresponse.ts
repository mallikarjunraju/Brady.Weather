import { ApiException } from "./apiexception";
import { Forecast } from "./forecast";

export interface ForecastResponse {
  isSuccessResponse: boolean,
  data: Forecast[],
  exception: ApiException
}