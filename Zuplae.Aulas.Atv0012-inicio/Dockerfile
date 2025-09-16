# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar os arquivos de projeto individualmente
COPY Zuplae.Aulas.Atv0012.Web/Zuplae.Aulas.Atv0012.Web.csproj Zuplae.Aulas.Atv0012.Web/
COPY Zuplae.Aulas.Atv0012.Data/Zuplae.Aulas.Atv0012.Data.csproj Zuplae.Aulas.Atv0012.Data/
COPY Zuplae.Aulas.Atv0012.Models/Zuplae.Aulas.Atv0012.Models.csproj Zuplae.Aulas.Atv0012.Models/
COPY Zuplae.Aulas.Atv0012.Servics/Zuplae.Aulas.Atv0012.Servics.csproj Zuplae.Aulas.Atv0012.Servics/
COPY Zuplae.Aulas.Atv0012.UserAccess/Zuplae.Aulas.Atv0012.UserAccess.csproj Zuplae.Aulas.Atv0012.UserAccess/

# Restaurar dependências
RUN dotnet restore Zuplae.Aulas.Atv0012.Web/Zuplae.Aulas.Atv0012.Web.csproj

# Copiar todo o conteúdo do projeto
COPY . .

# Publicar o projeto principal
RUN dotnet publish Zuplae.Aulas.Atv0012.Web/Zuplae.Aulas.Atv0012.Web.csproj -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expor porta
EXPOSE 8080

# Configurar para rodar na porta definida pelo Render
ENV ASPNETCORE_URLS=http://+:${PORT}

# Rodar o app
ENTRYPOINT ["dotnet", "Zuplae.Aulas.Atv0012.Web.dll"]

