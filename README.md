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
#High-level Architecture diagram


#Improvements:
- Session/token storage login.
- API to implement Oauth 2.0 and improve security.
- Mediatr pattern for decoupling.
- Unit-tests for API and e2e karma tests for UI
- Fluent validation for API
