# مرحله 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# کپی csproj های همه پروژه‌ها و فایل سولوشن
COPY *.sln . 
COPY Task.Api/*.csproj ./Task.Api/
COPY Task.Application/*.csproj ./Task.Application/
COPY Task.Domain/*.csproj ./Task.Domain/
COPY Task.Dapper/*.csproj ./Dapper/
COPY Task.Persistence/*.csproj ./Task.Persistence/
COPY Task.Shared/*.csproj ./Task.Shared/
COPY Task.UnitOfWork/*.csproj ./Task.UnitOfWork/

# restore پکیج‌ها
RUN dotnet restore

# کپی کل پروژه‌ها
COPY . .

# build و publish پروژه اصلی
WORKDIR /app/Task.Api
RUN dotnet publish -c Release -o out

# مرحله 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/Task.Api/out ./

# expose پورت‌ها
EXPOSE 8080
EXPOSE 8443

# دستور اجرای برنامه
ENTRYPOINT ["dotnet", "Task.Api.dll"]
