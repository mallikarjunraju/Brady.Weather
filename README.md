# Brady.Weather
This is a simple weather website which is using [openweathermap](https://openweathermap.org/api).

The Brady.Weather.API is a .net core 3.1 webapi.
The Brady.Weather.Website is a angular application.
 
The Website is currently hosted in Azure AKS and using kubernetes loadbalancer service the ip is made available to internet.
```
Website url : http://20.24.122.182:8081/
username: admin
password: admin123
```
## High-level Architecture diagram
![Weather app high leve architecture](https://github.com/mallikarjunraju/Brady.Weather/blob/master/Assets/Architecture%20diagrams/WeatherApp.png)


## REST API resources

### Weather API
GET {url}/weather/city/{cityname}

### Forecast API
GET {url}/forecast/city/{cityname}

## Improvements
*(listing few that I can think of)*
- Session/token storage login.
- API to implement Oauth 2.0 and improve security.
- Mediatr pattern for decoupling.
- Unit-tests for API and e2e karma tests for UI
- Fluent validation for API
- API Swagger url not working from loadbalancer service.
- Secure openweathermap token in Azure keyvault.
