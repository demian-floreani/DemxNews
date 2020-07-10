FROM mcr.microsoft.com/dotnet/core/sdk:3.1

#COPY ./RNN/bin/Debug/netcoreapp3.1/publish /publish

WORKDIR /home/app

COPY . .

RUN export DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER=0

RUN dotnet restore

RUN dotnet publish -c Release ./RNN/RNN.csproj -o /publish/ 

WORKDIR /publish

#COPY ../uploads/. /publish/wwwroot/images/uploads/

ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet", "RNN.dll"]
