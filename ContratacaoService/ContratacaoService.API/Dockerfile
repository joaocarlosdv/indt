# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia arquivos de csproj e restaura dependências
COPY ["ContratacaoService.API/ContratacaoService.API.csproj", "ContratacaoService.API/"]
COPY ["Contratacao.Application/Contratacao.Application.csproj", "Contratacao.Application/"]
COPY ["Contratacao.Domain/Contratacao.Domain.csproj", "Contratacao.Domain/"]
COPY ["Contratacao.Infrastructure/Contratacao.Infrastructure.csproj", "Contratacao.Infrastructure/"]
RUN dotnet restore "ContratacaoService.API/ContratacaoService.API.csproj"

# Copia todo o código e compila
COPY . .
WORKDIR "/src/ContratacaoService.API"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ContratacaoService.API.dll"]