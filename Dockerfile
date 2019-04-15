FROM microsoft/dotnet:2.2-sdk-stretch
#ENV AppSettings_QueueHostName="my-rabbit"
WORKDIR /src
COPY ["QueuePublisher/QueuePublisher.csproj", "QueuePublisher/"]
COPY ["QueuePublisher.Service/QueuePublisher.Service.csproj", "QueuePublisher.Service/"]
COPY ["QueuePublisher.Infrastructure/QueuePublisher.Infrastructure.csproj", "QueuePublisher.Infrastructure/"]
COPY ["QueuePublisher.Interface/QueuePublisher.Interface.csproj", "QueuePublisher.Interface/"]
RUN dotnet restore "QueuePublisher/QueuePublisher.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "QueuePublisher/QueuePublisher.csproj" -c Release -o /app
RUN dotnet publish "QueuePublisher/QueuePublisher.csproj" -c Release -o /app
WORKDIR /app
ENTRYPOINT ["dotnet", "QueuePublisher.dll"]