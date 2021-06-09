#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#这种模式是直接在构建镜像的内部编译发布dotnet项目。
#注意下容器内输出端口是8081
#如果你想先手动dotnet build成可执行的二进制文件，然后再构建镜像，请看.Api层下的dockerfile。


FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Jom.Blog.Api/Jom.Blog.Api.csproj", "Jom.Blog.Api/"]
COPY ["Jom.Blog.Extensions/Jom.Blog.Extensions.csproj", "Jom.Blog.Extensions/"]
COPY ["Jom.Blog.Tasks/Jom.Blog.Tasks.csproj", "Jom.Blog.Tasks/"]
COPY ["Jom.Blog.IServices/Jom.Blog.IServices.csproj", "Jom.Blog.IServices/"]
COPY ["Jom.Blog.Model/Jom.Blog.Model.csproj", "Jom.Blog.Model/"]
COPY ["Jom.Blog.Common/Jom.Blog.Common.csproj", "Jom.Blog.Common/"]
COPY ["Jom.Blog.Services/Jom.Blog.Services.csproj", "Jom.Blog.Services/"]
COPY ["Jom.Blog.Repository/Jom.Blog.Repository.csproj", "Jom.Blog.Repository/"]
COPY ["Jom.Blog.EventBus/Jom.Blog.EventBus.csproj", "Jom.Blog.EventBus/"]
RUN dotnet restore "Jom.Blog.Api/Jom.Blog.Api.csproj"
COPY . .
WORKDIR "/src/Jom.Blog.Api"
RUN dotnet build "Jom.Blog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jom.Blog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8081 
ENTRYPOINT ["dotnet", "Jom.Blog.Api.dll"]