# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia arquivos de csproj e restaura dependências
COPY ["PropostaService.API/PropostaService.API.csproj", "PropostaService.API/"]
COPY ["Proposta.Application/Proposta.Application.csproj", "Proposta.Application/"]
COPY ["Proposta.Domain/Proposta.Domain.csproj", "Proposta.Domain/"]
COPY ["Proposta.Infrastructure/Proposta.Infrastructure.csproj", "Proposta.Infrastructure/"]
RUN dotnet restore "PropostaService.API/PropostaService.API.csproj"

# Copia todo o código e compila
COPY . .
WORKDIR "/src/PropostaService.API"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PropostaService.API.dll"]