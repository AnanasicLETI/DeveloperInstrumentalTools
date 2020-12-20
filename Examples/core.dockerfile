FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build 
COPY ./ /core
WORKDIR /core
RUN dotnet restore
RUN dotnet publish -c Release -o build "SQL/WebApplication.EFCore/WebApplication.EFCore.csproj"
ENTRYPOINT ["dotnet", "build/WebApplication.EFCore.dll"]