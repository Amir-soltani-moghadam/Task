
اجرا برنامه 
---------------------------------------------------------
.NET 9 SDK
SQL Server
IDE = {Visual Studio 2022 - VS Code }
Test API = {Swagger UI - Postman - curl }
---------------------------------------------------------
ورژن پروژه :   ASP.NET Core 9
معماری : **CQRS**، **MediatR** و **Unit of Work**
ارتباط دیتابیس : EF Core و Dapper

---------------------------------------------------------

## ویژگی‌ها

- معماری **CQRS** با استفاده از **MediatR**  
- مدیریت تراکنش‌ها با **Unit of Work**  
- پشتیبانی از **Entity Framework Core** و **Dapper**  
- محاسبه اضافه‌کار با سه نوع **Calculator**:
  - `CalculatorA` → ضریب 10%  
  - `CalculatorB` → ضریب 15%  
  - `CalculatorC` → ضریب 20%  
- دریافت و ارسال داده‌ها به فرمت‌های: `JSON`, `XML`, `CSV`, `Custom`  
- مستند‌سازی API با **Swagger / NSwag**  
- استفاده از **AutoMapper** برای Map کردن DTO به Entity و بالعکس  
- اعتبارسنجی داده‌ها با **FluentValidation**  
- تنظیمات کانکشن دیتابیس از طریق **appsettings.json**

------------------------------------------------------------

## پکیج‌های استفاده شده

- MediatR 13.0.0  
- MediatR.Extensions.Microsoft.DependencyInjection 11.1.0  
- Microsoft.AspNetCore.OpenApi 9.0.6  
- Microsoft.EntityFrameworkCore.Design 9.0.9  
- Microsoft.EntityFrameworkCore.SqlServer 9.0.9  
- Microsoft.EntityFrameworkCore.Tools 9.0.9  
- NSwag.AspNetCore 14.5.0  
- NSwag.Generation.AspNetCore 14.5.0  
- AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.1  
- FluentValidation.DependencyInjectionExtensions 12.0.0  
- Dapper 2.1.66  
- Microsoft.Data.SqlClient 6.1.1  
- Microsoft.Extensions.Configuration.Abstractions 9.0.9  
- Microsoft.Extensions.Options.ConfigurationExtensions 9.0.9  

------------------------------------------------------------

