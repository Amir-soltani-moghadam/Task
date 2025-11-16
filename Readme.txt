Task Management API - راهنمای سریع

.NET 9 SDK
SQL Server
IDE = {Visual Studio 2022 - VS Code }
Test API = {Swagger UI - Postman - curl }
---------------------------------------------------------
ورژن پروژه :   ASP.NET Core 9
معماری : **CQRS**، **MediatR** و **Unit of Work**
ارتباط دیتابیس : EF Core و Dapper
---------------------------------------------------------
ویژگی‌ها:

* CQRS + MediatR
* Unit of Work
* EF Core + Dapper
* محاسبه اضافه‌کار:

  * CalculatorA: 10%
  * CalculatorB: 15%
  * CalculatorC: 20%
* فرمت ورودی: JSON, XML, CSV, Custom
* مستندات Swagger / NSwag
* AutoMapper برای Map کردن DTO و Entity
* اعتبارسنجی با FluentValidation

پکیج‌های استفاده شده:
MediatR
MediatR.Extensions.Microsoft.DependencyInjection
Microsoft.AspNetCore.OpenApi
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
NSwag.AspNetCore
NSwag.Generation.AspNetCore
AutoMapper.Extensions.Microsoft.DependencyInjection
FluentValidation.DependencyInjectionExtensions
Dapper
Microsoft.Data.SqlClient
Microsoft.Extensions.Configuration.Abstractions
Microsoft.Extensions.Options.ConfigurationExtensions

پیش‌نیازها:

* Windows 10/11 یا Windows Server
* Docker Desktop با WSL2
* .NET 9 SDK (اختیاری، فقط برای build محلی)

Docker:
ساخت و اجرا:

```
docker build -t taskmanagementapi:latest .
docker run -d -p 8080:8080 -p 8443:8443 taskmanagementapi:latest
```

بعد از اجرای کانتینر روی سرور تست:

* HTTP: [http://<Server IP>:8080](http://a-soltani.ir:8080)
* HTTPS: [https://<<Server IP>>:8443](https://a-soltani.ir:8443)

Server Test Demo:

* دریافت بازه حقوق: [https://a-soltani.ir:8080/api/SalaryCalculation/GetSalaryCalculation/{fromDate}/{toDate}?datatype={datatype}]
* دریافت یک رکورد: [https://a-soltani.ir:8080/api/SalaryCalculation/GetSalaryCalculation/{id}?datatype={datatype}]
* ایجاد رکورد: [https://a-soltani.ir:8080/api/SalaryCalculation/CreateSalaryCalculation?datatype={datatype}]
* بروزرسانی رکورد: [https://a-soltani.ir:8080/api/SalaryCalculation/UpdateSalaryCalculation/{id}?datatype={datatype}]
* حذف رکورد: [https://a-soltani.ir:8080/api/SalaryCalculation/DeleteSalaryCalculation/{id}?datatype={datatype}]

Datatype می‌گه داده‌ها به چه فرمتی باشه: json, xml, csv یا custom.

نمونه DataTye :

json

{
  "data": "[{\"FirstName\":\"Ali\",\"LastName\":\"Ahmadi\",\"BasicSalary\":1200000,\"Allowance\":400000,\"Transportation\":350000,\"Date\":\"14010801\"}]",
  "overTimeCalculator": "CalculatorB"
}

XML

{
  "data": "<SalaryCalculations><SalaryCalculation><FirstName>Ali</FirstName><LastName>Ahmadi</LastName><BasicSalary>1200000</BasicSalary><Allowance>400000</Allowance><Transportation>350000</Transportation><Date>14010801</Date></SalaryCalculation></SalaryCalculations>",
  "overTimeCalculator": "CalculatorB"
}

csv

{
  "data": "FirstName,LastName,BasicSalary,Allowance,Transportation,Date\nAli,Ahmadi,1200000,400000,350000,14010801",
  "overTimeCalculator": "CalculatorB"
}


Custom

{
  "data": "FirstName/LastName/BasicSalary/Allowance/Transportation/Date\nAli/Ahmadi/1200000/400000/350000/14010801",
  "overTimeCalculator": "CalculatorB"
}