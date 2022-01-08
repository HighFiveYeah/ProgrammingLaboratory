FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN apt-get update && apt-get install -y libgdiplus && ln -s /usr/lib/libgdiplus.so /usr/lib/gdiplus.dll
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS publish
RUN apt-get update && apt-get install -y --no-install-recommends gss-ntlmssp
COPY ["ProgrammingLaboratory/", "/src/"]
WORKDIR /src
RUN dotnet restore ProgrammingLaboratory.PracowniaProgramowania.Api/ProgrammingLaboratory.PracowniaProgramowania.Api.csproj && dotnet publish ProgrammingLaboratory.PracowniaProgramowania.Api/ProgrammingLaboratory.PracowniaProgramowania.Api.csproj -o /publish -c Release

FROM base AS final
COPY --from=publish /publish .
ENTRYPOINT ["dotnet", "ProgrammingLaboratory.PracowniaProgramowania.Api.dll"]
